using Ambev.DeveloperEvaluation.Application.Sales.Commands.CancelSale;
using Ambev.DeveloperEvaluation.Integration.Abstractions;
using Ambev.DeveloperEvaluation.Integration.Features.Sales.Commands.CreateSale;
using FluentAssertions;

namespace Ambev.DeveloperEvaluation.Integration.Features.Sales.Commands.CancelSale;

public class CancelSaleTest(IntegrationTestWebAppFactory factory) : BaseIntegrationTest(factory)
{
    [Fact(DisplayName = "Should cancel sale with successfully")]
    [Trait("Integration", "Integration Sales Tests")]
    public async Task Handler_ValidRequest_ReturnSuccessResponse()
    {
        //Given
        var createCommand = CreateSaleCommandMock.Builder();
        var result = await Sender.Send(createCommand);

        var command = new CancelSaleCommand(result.Id);

        //When
        var response = await Sender.Send(command, new CancellationToken());

        //Then
        response.Should().BeOfType<CancelSaleResult>();
        response.Success.Should().BeTrue();
    }

    [Fact(DisplayName = "Should return error sale not found")]
    [Trait("Integration", "Integration Sales Tests")]
    public async Task Handler_ValidRequest_ReturnErrorNotFound()
    {
        //Given
        var command = new CancelSaleCommand(Guid.NewGuid());
        var message = $"Sale Id: {command.Id}, not found!";

        //When
        var response = async () => await Sender.Send(command, new CancellationToken());

        //Then
        await response.Should().ThrowAsync<KeyNotFoundException>().WithMessage(message);        
    }
}
