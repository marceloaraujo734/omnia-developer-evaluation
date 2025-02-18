using Ambev.DeveloperEvaluation.Application.Sales.Commands.CancelSaleProduct;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Application.Sales.Fixture.Repositories;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales.Commands.CancelSaleProduct;

public class CancelSaleProductHandlerTest
{
    private readonly IProductRepository _repositoryMock;
    private readonly IPublishEvent _publishEventMock;
    private readonly ILogger<CancelSaleProductHandler> _loggerMock;

    private readonly CancelSaleProductHandler _handler;

    public CancelSaleProductHandlerTest()
    {
        _repositoryMock = Substitute.For<IProductRepository>();
        _publishEventMock = Substitute.For<IPublishEvent>();
        _loggerMock = Substitute.For<ILogger<CancelSaleProductHandler>>();

        _handler = new CancelSaleProductHandler(_repositoryMock, _publishEventMock, _loggerMock);
    }

    [Fact(DisplayName = "Should cancel sale product with successfully")]
    [Trait("Application", "Application Sales Tests")]
    public async Task Handler_ValidRequest_ReturnSuccessResponse()
    {
        //Given
        const int once = 1;
        var command = CancelSaleProductCommandMock.Builder();
        var productMock = ProductRepositoryMock.GetProduct();

        _repositoryMock.GetByKeysAsync(Arg.Any<Guid>(), Arg.Any<Guid>(), Arg.Any<CancellationToken>()).Returns(productMock);

        //When
        var response = await _handler.Handle(command, new CancellationToken());

        //Then
        response.Should().BeOfType<CancelSaleProductResult>();
        response.Success.Should().BeTrue();

        await _repositoryMock.Received(once).GetByKeysAsync(Arg.Any<Guid>(), Arg.Any<Guid>(), Arg.Any<CancellationToken>());
        await _repositoryMock.Received(once).UpdateAsync(Arg.Any<Product>(), Arg.Any<CancellationToken>());
    }

    [Fact(DisplayName = "Should return error sale product not found")]
    [Trait("Application", "Application Sales Tests")]
    public async Task Handler_ValidRequest_ReturnErrorNotFound()
    {
        //Given
        const int once = 1;
        const int never = 0;

        var command = CancelSaleProductCommandMock.Builder();
        var message = $"Product with this id: {command.ProductId} in this sale: {command.SaleId}, not found!";

        //When
        var response = async () => await _handler.Handle(command, new CancellationToken());

        //Then
        response?.Should().ThrowAsync<KeyNotFoundException>().WithMessage(message);

        await _repositoryMock.Received(once).GetByKeysAsync(Arg.Any<Guid>(), Arg.Any<Guid>(), Arg.Any<CancellationToken>());
        await _repositoryMock.Received(never).UpdateAsync(Arg.Any<Product>(), Arg.Any<CancellationToken>());
    }
}
