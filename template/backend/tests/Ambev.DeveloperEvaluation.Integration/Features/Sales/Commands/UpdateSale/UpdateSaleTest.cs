using Ambev.DeveloperEvaluation.Application.Sales.Commands.UpdateSale;
using Ambev.DeveloperEvaluation.Integration.Abstractions;
using Ambev.DeveloperEvaluation.Integration.Features.Sales.Commands.CreateSale;
using FluentAssertions;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Integration.Features.Sales.Commands.UpdateSale;

public class UpdateSaleTest(IntegrationTestWebAppFactory factory) : BaseIntegrationTest(factory)
{
    [Fact(DisplayName = "Should update sale with successfully")]
    [Trait("Integration", "Integration Sales Tests")]
    public async Task Handler_ValidRequest_ReturnSuccessResponse()
    {
        //Given
        var createCommand = CreateSaleCommandMock.Builder();
        var result = await Sender.Send(createCommand);

        var command = UpdateSaleCommandMock.Builder(result.Id);

        var count = result.Products.Count + command.Products.Count;

        //When
        var response = await Sender.Send(command, new CancellationToken());

        //Then
        response.Should().BeOfType<UpdateSaleResult>();
        response.CustomerName.Should().NotBe(result.CustomerName);
        response.BranchName.Should().NotBe(result.BranchName);
        response.Products.Should().HaveCount(count);
    }

    [Fact(DisplayName = "Invalid command must occur error")]
    [Trait("Integration", "Integration Sales Tests")]
    public async Task Handler_InvalidRequest_ReturnValidationError()
    {
        //Given
        var command = UpdateSaleCommandMock.BuilderEmpty();

        //When
        var response = async () => await Sender.Send(command, new CancellationToken());

        //Then
        await response.Should().ThrowAsync<ValidationException>();        
    }

    [Fact(DisplayName = "Should return error sale not found")]
    [Trait("Integration", "Integration Sales Tests")]
    public async Task Handler_ValidRequest_ReturnErrorNotFound()
    {
        //Given
        var command = UpdateSaleCommandMock.Builder(Guid.NewGuid());
        var message = $"Sale Id: {command.Id}, not found!";

        //When
        var response = async () => await Sender.Send(command, new CancellationToken());

        //Then
        await response.Should().ThrowAsync<KeyNotFoundException>().WithMessage(message);
    }

    [Fact(DisplayName = "Invalid sale must occur error by quantity invalid")]
    [Trait("Integration", "Integration Sales Tests")]
    public async Task Handler_InvalidSale_ReturnValidationError()
    {
        //Given
        var createCommand = CreateSaleCommandMock.Builder();
        var result = await Sender.Send(createCommand);

        var command = UpdateSaleCommandMock.Builder(result.Id, quantityInvalid: true);

        //When
        var response = async () => await Sender.Send(command, new CancellationToken());

        //Then
        await response.Should().ThrowAsync<ValidationException>();
    }
}
