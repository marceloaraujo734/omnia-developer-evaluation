using Ambev.DeveloperEvaluation.Application.Sales.Queries.GetSale;
using Ambev.DeveloperEvaluation.Integration.Abstractions;
using Ambev.DeveloperEvaluation.Integration.Features.Sales.Commands.CreateSale;
using FluentAssertions;

namespace Ambev.DeveloperEvaluation.Integration.Features.Sales.Queries.GetSale;

[TestCaseOrderer("Ambev.DeveloperEvaluation.Integration.Abstractions.SequentialOrderer", "Ambev.DeveloperEvaluation.Integration")]
public class GetSaleTest(IntegrationTestWebAppFactory factory) : BaseIntegrationTest(factory)
{
    [Fact(DisplayName = "Should get sale with successfully")]
    [Trait("Integration", "Integration Sales Tests")]    
    public async Task Handler_ValidRequest_ReturnSuccessResponse()
    {
        //Given
        var createCommand = CreateSaleCommandMock.Builder();
        var result = await Sender.Send(createCommand);

        var command = new GetSaleQuery(result.Id);

        //When
        var response = await Sender.Send(command, new CancellationToken());

        //Then
        response.Should().BeOfType<GetSaleResult>();
        response.Id.Should().NotBeEmpty();
    }

    [Fact(DisplayName = "Should return error sale not found")]
    [Trait("Integration", "Integration Sales Tests")]    
    public async Task Handler_ValidRequest_ReturnErrorNotFound()
    {
        //Given
        var command = new GetSaleQuery(Guid.NewGuid());
        var message = $"Sale Id: {command.Id} not found!";

        //When
        var response = async () => await Sender.Send(command, new CancellationToken());

        //Then
        await response.Should().ThrowAsync<KeyNotFoundException>().WithMessage(message);
    }
}
