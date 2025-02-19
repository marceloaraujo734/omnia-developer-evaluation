using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;
using FluentAssertions;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;

public class ProductTests
{
    private readonly Faker _faker;

    public ProductTests() => _faker = new Faker("pt_BR");

    [Fact(DisplayName = "Should valid parameters when builder is called then should create product")]
    [Trait("Domains", "Domains Sales Tests")]
    public void Product_Should_ValidParameters_When_BuilderIsCalled_Then_ShouldCreateProduct()
    {
        // Given
        var productId = Guid.NewGuid();
        var quantity = _faker.Random.Decimal(1, 100);
        var price = _faker.Random.Decimal(1, 100);
        var total = quantity * price;

        // When
        var product = Product.Builder(productId, quantity, price, total);

        // Then
        product.Should().NotBeNull();
        product.ProductId.Should().Be(productId);
        product.Quantity.Should().Be(quantity);
        product.Price.Should().Be(price);
        product.Total.Should().Be(total);
        product.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
        product.Canceled.Should().BeFalse();
        product.Discount.Should().Be(0.0m);
    }

    [Fact(DisplayName = "Should product With Total when apply Discount is called then should apply discount correctly")]
    [Trait("Domains", "Domains Sales Tests")]
    public void Product_Should_ProductWithTotal_When_ApplyDiscountIsCalled_Then_ShouldApplyDiscountCorrectly()
    {
        // Given
        var id = _faker.Random.Guid();
        var quantity = Math.Round(_faker.Random.Decimal(10.000m, 20.000m), 3);
        var price = Math.Round(_faker.Random.Decimal(1.00m, 10.00m), 2);
        var total = quantity * price;

        var product = Product.Builder(id, quantity, price, total);
        var discount = 0.10m;
        var expectedTotal = total - (total * discount);

        // When
        product.ApplyDiscount(discount);

        // Then
        product.Discount.Should().Be(discount);
        product.Total.Should().Be(expectedTotal);
    }

    [Fact(DisplayName = "Should Product when change values is called then should update values correctly")]
    [Trait("Domains", "Domains Sales Tests")]
    public void Product_Should_Product_When_ChangeValuesIsCalled_Then_ShouldUpdateValuesCorrectly()
    {
        // Given
        var id = _faker.Random.Guid();
        
        var quantity = Math.Round(_faker.Random.Decimal(10.000m, 20.000m), 3);
        var price = Math.Round(_faker.Random.Decimal(1.00m, 10.00m), 2);
        var total = quantity * price;
        var originalProduct = Product.Builder(id, quantity, price, total);

        quantity = Math.Round(_faker.Random.Decimal(10.000m, 20.000m), 3);
        price = Math.Round(_faker.Random.Decimal(1.00m, 10.00m), 2);
        total = quantity * price;
        var updatedProduct = Product.Builder(id, quantity, price, total);

        // When
        originalProduct.ChangeValues(updatedProduct);

        // Then
        originalProduct.Quantity.Should().Be(updatedProduct.Quantity);
        originalProduct.Price.Should().Be(updatedProduct.Price);
        originalProduct.Total.Should().Be(updatedProduct.Total);
        originalProduct.Discount.Should().Be(0.00m);
    }

    [Fact(DisplayName = "Should product when change to cancelled is called then should set canceled to true")]
    [Trait("Domains", "Domains Sales Tests")]
    public void Product_Should_Product_When_ChangeToCancelledIsCalled_Then_ShouldSetCanceledToTrue()
    {
        // Given
        var id = _faker.Random.Guid();
        var quantity = Math.Round(_faker.Random.Decimal(10.000m, 20.000m), 3);
        var price = Math.Round(_faker.Random.Decimal(1.00m, 10.00m), 2);
        var total = quantity * price;
        var product = Product.Builder(id, quantity, price, total);

        // When
        product.ChangeToCancelled();

        // Then
        product.Canceled.Should().BeTrue();
    }
}
