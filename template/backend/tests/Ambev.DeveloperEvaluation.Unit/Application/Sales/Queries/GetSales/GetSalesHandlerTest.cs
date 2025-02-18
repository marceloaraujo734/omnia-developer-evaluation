using Ambev.DeveloperEvaluation.Application.Sales.Queries.GetSales;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Application.Sales.Fixture.Repositories;
using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales.Queries.GetSales;

public class GetSalesHandlerTest
{
    private readonly ISaleRepository _repositoryMock;
    private readonly IMapper _mapperMock;
    private readonly ILogger<GetSalesHandler> _loggerMock;

    private readonly GetSalesHandler _handler;

    public GetSalesHandlerTest()
    {
        _repositoryMock = Substitute.For<ISaleRepository>();
        _mapperMock = Substitute.For<IMapper>();
        _loggerMock = Substitute.For<ILogger<GetSalesHandler>>();

        _handler = new GetSalesHandler(_repositoryMock, _mapperMock, _loggerMock);
    }

    [Fact(DisplayName = "Should get sales with successfully")]
    [Trait("Application", "Application Sales Tests")]
    public async Task Handler_ValidRequest_ReturnSuccessResponse()
    {
        //Given
        const int once = 1;
        const int totalCount = 2;

        var command = GetSalesCommandMock.Builder();
        var salesMock = SaleRepositoryMock.GetSales();
        var resultsMock = GetSalesResultMock.Builder(salesMock);

        _repositoryMock.GetSalesAsync(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<string>(), Arg.Any<CancellationToken>()).Returns(salesMock);
        _repositoryMock.GetSalesTotal(Arg.Any<CancellationToken>()).Returns(salesMock.Count);

        _mapperMock.Map<GetSalesResult>(salesMock).Returns(resultsMock);

        //When
        var response = await _handler.Handle(command, new CancellationToken());

        //Then
        response.Should().BeOfType<GetSalesResult>();
        response.Sales.Should().HaveCount(totalCount);
        response.TotalCount.Should().Be(totalCount);

        await _repositoryMock.Received(once).GetSalesAsync(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<string>(), Arg.Any<CancellationToken>());
        await _repositoryMock.Received(once).GetSalesTotal(Arg.Any<CancellationToken>());
    }

    [Fact(DisplayName = "Should return error sale not found with result null")]
    [Trait("Application", "Application Sales Tests")]
    public async Task Handler_ValidRequest_ResultNull_ReturnErrorNotFound()
    {
        //Given
        const int once = 1;
        const int never = 0;
        var command = GetSalesCommandMock.Builder();
        var message = $"Sale not found!";

        //When
        var response = async () => await _handler.Handle(command, new CancellationToken());

        //Then
        response?.Should().ThrowAsync<KeyNotFoundException>().WithMessage(message);

        await _repositoryMock.Received(once).GetSalesAsync(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<string>(), Arg.Any<CancellationToken>());
        await _repositoryMock.Received(never).GetSalesTotal(Arg.Any<CancellationToken>());
    }

    [Fact(DisplayName = "Should return error sale not found with result count zero")]
    [Trait("Application", "Application Sales Tests")]
    public async Task Handler_ValidRequest_ResulCountZero_ReturnErrorNotFound()
    {
        //Given
        const int once = 1;
        const int never = 0;
        var command = GetSalesCommandMock.Builder();
        var salesMock = SaleRepositoryMock.GetSalesEmpty();
        var message = $"Sale not found!";

        _repositoryMock.GetSalesAsync(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<string>(), Arg.Any<CancellationToken>()).Returns(salesMock);

        //When
        var response = async () => await _handler.Handle(command, new CancellationToken());

        //Then
        response?.Should().ThrowAsync<KeyNotFoundException>().WithMessage(message);

        await _repositoryMock.Received(once).GetSalesAsync(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<string>(), Arg.Any<CancellationToken>());
        await _repositoryMock.Received(never).GetSalesTotal(Arg.Any<CancellationToken>());
    }
}
