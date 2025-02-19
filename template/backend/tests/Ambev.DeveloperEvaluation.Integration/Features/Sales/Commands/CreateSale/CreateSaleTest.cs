using Ambev.DeveloperEvaluation.Integration.Abstractions;
using FluentAssertions;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Integration.Features.Sales.Commands.CreateSale;

public class CreateSaleTest(IntegrationTestWebAppFactory factory) : BaseIntegrationTest(factory)
{
    [Fact(DisplayName = "Should create sale with successfully")]
    [Trait("Integration", "Integration Sales Tests")]
    public async Task CreateSale_Should_CreateSale_WhenCommandIsValid()
    {
        //Given
        var command = CreateSaleCommandMock.Builder();

        //When
        var result = await Sender.Send(command);

        //Then
        result.Id.Should().NotBeEmpty();
        result.Canceled.Should().BeFalse();
    }

    [Fact(DisplayName = "Invalid command must occur")]
    [Trait("Integration", "Integration Sales Tests")]
    public async Task CreateSale_InvalidCommand_ReturnValidationError()
    {
        //Given
        var command = CreateSaleCommandMock.BuilderEmpty();        

        //When
        var response = async () => await Sender.Send(command, new CancellationToken());

        //Then
        await response.Should().ThrowExactlyAsync<ValidationException>()
            .WithMessage("*The number is required!*")
            .WithMessage("*The sale date is required!*")
            .WithMessage("*The customer id is required!*")
            .WithMessage("*The customer name is required!*")
            .WithMessage("*The branch id is required!*")
            .WithMessage("*The branch is required!*")
            .WithMessage("*The total sale value must be greater than zero!*")
            .WithMessage("*The sale must have at least one product.*");
    }

    [Fact(DisplayName = "Invalid sale must occur error by quantity invalid")]
    [Trait("Integration", "Integration Sales Tests")]
    public async Task CreateSale_InvalidSale_ReturnValidationError_QuantityInvalid()
    {
        //Given
        var command = CreateSaleCommandMock.Builder(quantityInvalid: true);

        //When
        var response = async () => await Sender.Send(command, new CancellationToken());

        //Then
        await response.Should().ThrowAsync<ValidationException>();
    }
}
