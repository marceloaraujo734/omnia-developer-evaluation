using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;
using FluentAssertions;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;

public class SaleTests
{
    private readonly Faker _faker;

    public SaleTests() => _faker = new Faker("pt_BR");

    [Fact(DisplayName = "Should successfully create the sale to created")]
    [Trait("Domains", "Domains Sales Tests")]
    public async Task Sale_Should_Successfully_Create_The_Sale_To_Created()
    {
        //Given
        var id = _faker.Random.Uuid();
        var number = _faker.Random.String(3, 50);
        var openDate = _faker.Date.Past();
        var customerId = _faker.Random.Uuid();
        var customerName = _faker.Person.FullName;
        var branchId = _faker.Random.Uuid();
        var branchName = _faker.Person.FullName;

        var products = CreateProducts();
        var total = products.Sum(opt => opt.Total);
        var count = products.Count;

        var sale = new Sale()
        {
            Id = id,
            Number = number,
            OpenDate = openDate,
            CreatedAt = DateTime.UtcNow,
        };

        sale.ChangeCustomer(customerId, customerName);
        sale.ChangeBranch(branchId, branchName);
        sale.SetTotalValue(total);
        sale.ChangeProducts(products);

        //When
        var result = await sale.Validate(new CancellationToken());

        //Then
        result.IsValid.Should().BeTrue();

        sale.Should().BeOfType<Sale>();
        sale.Canceled.Should().BeFalse();

        sale.Products.Should().HaveCount(count);
    }

    [Fact(DisplayName = "Should successfully create the sale and apply discounts")]
    [Trait("Domains", "Domains Sales Tests")]
    public async Task Sale_Should_Successfully_Create_And_Apply_Discounts()
    {
        //Given
        var fake = new Faker("pt_BR");

        var id = fake.Random.Uuid();
        var number = fake.Random.String(3, 50);
        var openDate = fake.Date.Past();
        var customerId = fake.Random.Uuid();
        var customerName = fake.Person.FullName;
        var branchId = fake.Random.Uuid();
        var branchName = fake.Person.FullName;

        var products = CreateProducts();
        var total = products.Sum(opt => opt.Total);
        var count = products.Count;

        var sale = new Sale()
        {
            Id = id,
            Number = number,
            OpenDate = openDate,
            CreatedAt = DateTime.UtcNow,
        };

        sale.ChangeCustomer(customerId, customerName);
        sale.ChangeBranch(branchId, branchName);
        sale.SetTotalValue(total);
        sale.ChangeProducts(products);

        //When
        var result = await sale.Validate(new CancellationToken());

        sale.ApplyDiscounts();

        //Then
        result.IsValid.Should().BeTrue();

        sale.TotalValue.Should().NotBe(total);
        sale.Canceled.Should().BeFalse();
        
        sale.Products.Should().HaveCount(count);
    }

    [Fact(DisplayName = "Should successfully create the sale and change cancelled")]
    [Trait("Domains", "Domains Sales Tests")]
    public async Task Sale_Should_Successfully_Create_And_Change_Cancelled()
    {
        //Given
        var id = _faker.Random.Uuid();
        var number = _faker.Random.String(3, 50);
        var openDate = _faker.Date.Past();
        var customerId = _faker.Random.Uuid();
        var customerName = _faker.Person.FullName;
        var branchId = _faker.Random.Uuid();
        var branchName = _faker.Person.FullName;

        var products = CreateProducts();
        var total = products.Sum(opt => opt.Total);
        var count = products.Count;

        var sale = new Sale()
        {
            Id = id,
            Number = number,
            OpenDate = openDate,
            CreatedAt = DateTime.UtcNow,
        };

        sale.ChangeCustomer(customerId, customerName);
        sale.ChangeBranch(branchId, branchName);
        sale.SetTotalValue(total);
        sale.ChangeProducts(products);

        //When
        var result = await sale.Validate(new CancellationToken());

        sale.ChangeToCancelled();

        //Then
        result.IsValid.Should().BeTrue();

        sale.TotalValue.Should().Be(total);
        sale.Canceled.Should().BeTrue();

        sale.Products.Should().HaveCount(count);
    }

    private static List<Product> CreateProducts()
    {
        return new Faker<Product>("pt_BR")
            .RuleFor(item => item.ProductId, fake => fake.Random.Uuid())
            .RuleFor(item => item.Quantity, fake => Math.Round(fake.Random.Decimal(0.001m, 20.000m), 3))
            .RuleFor(item => item.Price, fake => Math.Round(fake.Random.Decimal(0.01m, 100.00m), 2))
            .RuleFor(item => item.Total, (_, item) => Math.Round(item.Quantity * item.Price, 2))
            .Generate(2);
    }
}
