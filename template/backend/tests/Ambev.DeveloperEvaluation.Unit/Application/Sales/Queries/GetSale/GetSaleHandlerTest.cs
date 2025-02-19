using Ambev.DeveloperEvaluation.Application.Sales.Queries.GetSale;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Application.Sales.Fixture.Repositories;
using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales.Queries.GetSale;

public class GetSaleHandlerTest
{
    private readonly ISaleRepository _repositoryMock;
    private readonly IMapper _mapperMock;
    private readonly ILogger<GetSaleHandler> _loggerMock;

    private readonly GetSaleHandler _handler;

    public GetSaleHandlerTest()
    {
        _repositoryMock = Substitute.For<ISaleRepository>();
        _mapperMock = Substitute.For<IMapper>();
        _loggerMock = Substitute.For<ILogger<GetSaleHandler>>();

        _handler = new GetSaleHandler(_repositoryMock, _mapperMock, _loggerMock);
    }

    [Fact(DisplayName = "Should get sale with successfully")]
    [Trait("Application", "Application Sales Tests")]
    public async Task Handler_ValidRequest_ReturnSuccessResponse()
    {
        //Given
        const int once = 1;
        var query = GetSaleQueryMock.Builder();
        var saleMock = SaleRepositoryMock.GetSale();
        var resultMock = GetSaleResultMock.Builder(saleMock);

        _repositoryMock.GetByIdAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>()).Returns(saleMock);

        _mapperMock.Map<GetSaleResult>(saleMock).Returns(resultMock);

        //When
        var response = await _handler.Handle(query, new CancellationToken());

        //Then
        response.Should().BeOfType<GetSaleResult>();
        response.Id.Should().Be(saleMock.Id);

        await _repositoryMock.Received(once).GetByIdAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>());
    }

    [Fact(DisplayName = "Should return error sale not found")]
    [Trait("Application", "Application Sales Tests")]
    public async Task Handler_ValidRequest_ReturnErrorNotFound()
    {
        //Given
        const int once = 1;
        var query = GetSaleQueryMock.Builder();
        var message = $"Sale Id: {query.Id} not found!";

        //When
        var response = async () => await _handler.Handle(query, new CancellationToken());

        //Then
        await response.Should().ThrowAsync<KeyNotFoundException>().WithMessage(message);

        await _repositoryMock.Received(once).GetByIdAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>());
    }
}
