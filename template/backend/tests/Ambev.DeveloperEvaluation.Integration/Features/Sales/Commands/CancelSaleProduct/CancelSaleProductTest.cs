using Ambev.DeveloperEvaluation.Application.Sales.Commands.CancelSaleProduct;
using Ambev.DeveloperEvaluation.Integration.Abstractions;
using Ambev.DeveloperEvaluation.Integration.Features.Sales.Commands.CreateSale;
using FluentAssertions;

namespace Ambev.DeveloperEvaluation.Integration.Features.Sales.Commands.CancelSaleProduct;

public class CancelSaleProductTest(IntegrationTestWebAppFactory factory) : BaseIntegrationTest(factory)
{
    [Fact(DisplayName = "Should cancel sale product with successfully")]
    [Trait("Integration", "Integration Sales Tests")]
    public async Task Handler_ValidRequest_ReturnSuccessResponse()
    {
        //Given
        var createCommand = CreateSaleCommandMock.Builder();
        var result = await Sender.Send(createCommand);
        var productId = result.Products.First().ProductId;

        var command = new CancelSaleProductCommand { SaleId = result.Id, ProductId = productId };

        //When
        var response = await Sender.Send(command, new CancellationToken());

        //Then
        response.Should().BeOfType<CancelSaleProductResult>();
        response.Success.Should().BeTrue();
    }

    [Fact(DisplayName = "Should return error sale product not found")]
    [Trait("Integration", "Integration Sales Tests")]
    public async Task Handler_ValidRequest_ReturnErrorNotFound()
    {
        //Given
        var command = new CancelSaleProductCommand { SaleId = Guid.NewGuid(), ProductId = Guid.NewGuid() };
        var message = $"Product with this id: {command.ProductId} in this sale: {command.SaleId}, not found!";

        //When
        var response = async () => await Sender.Send(command, new CancellationToken());

        //Then
        await response.Should().ThrowAsync<KeyNotFoundException>().WithMessage(message);
    }
}
