using Ambev.DeveloperEvaluation.Application.Extensions;
using Ambev.DeveloperEvaluation.Application.Sales.Commands.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentAssertions;
using FluentValidation;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales.Commands.CreateSale;

public class CreateSaleHandlerTest
{
    private readonly ISaleRepository _repositoryMock;
    private readonly IMapper _mapperMock;
    private readonly IPublishEvent _publishEventMock;
    private readonly ILogger<CreateSaleHandler> _loggerMock;

    private readonly CreateSaleHandler _handler;

    public CreateSaleHandlerTest()
    {
        _repositoryMock = Substitute.For<ISaleRepository>();
        _mapperMock = Substitute.For<IMapper>();
        _publishEventMock = Substitute.For<IPublishEvent>();
        _loggerMock = Substitute.For<ILogger<CreateSaleHandler>>();

        _handler = new CreateSaleHandler(_repositoryMock, _mapperMock, _publishEventMock, _loggerMock);
    }

    [Fact(DisplayName = "Should create sale with successfully")]
    [Trait("Application", "Application Sales Tests")]
    public async Task Handler_ValidRequest_ReturnSuccessResponse()
    {
        //Given
        const int once = 1;
        var command = CreateSaleCommandMock.Builder();
        var saleMock = CreateSaleMapperMock.CommandToEntity(command);
        var resultMock = CreateSaleMapperMock.EntityToResult(saleMock);

        _mapperMock.Map<Sale>(command).Returns(saleMock);

        _repositoryMock.CreateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>()).Returns(saleMock);

        _mapperMock.Map<CreateSaleResult>(saleMock).Returns(resultMock);

        //When
        var response = await _handler.Handle(command, new CancellationToken());

        //Then
        response.Should().BeOfType<CreateSaleResult>();
        response.Id.Should().Be(saleMock.Id);

        await _repositoryMock.Received(once).CreateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>());
    }

    [Fact(DisplayName = "Invalid command must occur")]
    [Trait("Application", "Application Sales Tests")]
    public async Task Handler_InvalidRequest_ReturnValidationError()
    {
        //Given
        const int never = 0;

        var command = CreateSaleCommandMock.BuilderEmpty();

        //When
        var response = async () => await _handler.Handle(command, new CancellationToken());

        //Then
        await response.Should().ThrowAsync<ValidationException>()
            .WithMessage("*The number is required!*")
            .WithMessage("*The sale date is required!*")
            .WithMessage("*The customer id is required!*")
            .WithMessage("*The customer name is required!*")
            .WithMessage("*The branch id is required!*")
            .WithMessage("*The branch is required!*")
            .WithMessage("*The total sale value must be greater than zero!*")
            .WithMessage("*The sale must have at least one product.*");

        await _repositoryMock.Received(never).CreateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>());
    }

    [Fact(DisplayName = "Invalid sale must occur")]
    [Trait("Application", "Application Sales Tests")]
    public async Task Handler_InvalidSale_ReturnValidationError()
    {
        //Given
        const int never = 0;

        var command = CreateSaleCommandMock.Builder();
        var saleMock = CreateSaleMapperMock.CommandToEntityInvalid(command);

        _mapperMock.Map<Sale>(command).Returns(saleMock);

        //When
        var response = async () => await _handler.Handle(command, new CancellationToken());

        //Then
        await response.Should().ThrowExactlyAsync<ValidationException>();

        await _repositoryMock.Received(never).CreateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>());
    }
}
