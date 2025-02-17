using Ambev.DeveloperEvaluation.Application.Sales.CancelSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Application.Sales.Fixture.Repositories;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales.CancelSale;

public class CancelSaleHandlerTest
{
    private readonly ISaleRepository _repositoryMock;
    private readonly ILogger<CancelSaleHandler> _loggerMock;

    private readonly CancelSaleHandler _handler;

    public CancelSaleHandlerTest()
    {
        _repositoryMock = Substitute.For<ISaleRepository>();
        _loggerMock = Substitute.For<ILogger<CancelSaleHandler>>();

        _handler = new CancelSaleHandler(_repositoryMock, _loggerMock);
    }

    [Fact(DisplayName = "Should cancel sale with successfully")]
    [Trait("Application", "Application Sales Tests")]
    public async Task Handler_ValidRequest_ReturnSuccessResponse()
    {
        //Given
        const int once = 1;
        var command = CancelSaleCommandMock.Builder();
        var saleMock = SaleRepositoryMock.GetSale();

        _repositoryMock.GetByIdAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>()).Returns(saleMock);

        //When
        var response = await _handler.Handle(command, new CancellationToken());

        //Then
        response.Should().BeOfType<CancelSaleResult>();
        response.Success.Should().BeTrue();

        await _repositoryMock.Received(once).GetByIdAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>());
        await _repositoryMock.Received(once).UpdateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>());
    }

    [Fact(DisplayName = "Should return error sale not found")]
    [Trait("Application", "Application Sales Tests")]
    public async Task Handler_ValidRequest_ReturnErrorNotFound()
    {
        //Given
        const int once = 1;
        const int never = 0;
        var command = CancelSaleCommandMock.Builder();
        var message = $"Sale Id: {command.Id}, not found!";

        //When
        var response = async () => await _handler.Handle(command, new CancellationToken());

        //Then
        response?.Should().ThrowAsync<KeyNotFoundException>().WithMessage(message);

        await _repositoryMock.Received(once).GetByIdAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>());
        await _repositoryMock.Received(never).UpdateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>());
    }
}
