using Ambev.DeveloperEvaluation.Application.Sales.Queries.GetSales;
using Ambev.DeveloperEvaluation.Integration.Abstractions;
using Ambev.DeveloperEvaluation.Integration.Features.Sales.Commands.CreateSale;
using FluentAssertions;

namespace Ambev.DeveloperEvaluation.Integration.Features.Sales.Queries.GetSales;

[TestCaseOrderer("Ambev.DeveloperEvaluation.Integration.Abstractions.SequentialOrderer", "Ambev.DeveloperEvaluation.Integration")]
public class GetSalesTest(IntegrationTestWebAppFactory factory) : BaseIntegrationTest(factory)
{
    [Fact(DisplayName = "Should return error sale not found with result null")]
    [Trait("Integration", "Integration Sales Tests")]
    [Order(1)]
    public async Task Handler_ValidRequest_ResultNull_ReturnErrorNotFound()
    {
        //Given
        const string message = "Sales not found!";

        var query = new GetSalesQuery(1, 10, "Number Asc");

        //When
        var response = async () => await Sender.Send(query, new CancellationToken());

        //Then
        await response.Should().ThrowAsync<KeyNotFoundException>().WithMessage(message);
    }

    [Fact(DisplayName = "Should get sales with successfully")]
    [Trait("Integration", "Integration Sales Tests")]
    [Order(2)]
    public async Task Handler_ValidRequest_ReturnSuccessResponse()
    {
        //Given
        var count = 1;
        
        var createCommand = CreateSaleCommandMock.Builder();
        await Sender.Send(createCommand);

        var query = new GetSalesQuery(1, 10, "Number Asc");
        
        //When
        var response = await Sender.Send(query, new CancellationToken());

        //Then
        response.Should().BeOfType<GetSalesResult>();
        response.Sales.Should().HaveCount(count);
        response.TotalCount.Should().Be(count);
    }    
}
