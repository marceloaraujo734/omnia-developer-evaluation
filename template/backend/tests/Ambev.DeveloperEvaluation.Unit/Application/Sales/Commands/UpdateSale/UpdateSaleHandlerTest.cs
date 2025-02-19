using Ambev.DeveloperEvaluation.Application.Extensions;
using Ambev.DeveloperEvaluation.Application.Sales.Commands.UpdateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentAssertions;
using FluentValidation;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales.Commands.UpdateSale;

public class UpdateSaleHandlerTest
{
    private readonly ISaleRepository _repositoryMock;
    private readonly IMapper _mapperMock;
    private readonly IPublishEvent _publishEventMock;
    private readonly ILogger<UpdateSaleHandler> _loggerMock;

    private readonly UpdateSaleHandler _handler;

    public UpdateSaleHandlerTest()
    {
        _repositoryMock = Substitute.For<ISaleRepository>();
        _mapperMock = Substitute.For<IMapper>();
        _publishEventMock = Substitute.For<IPublishEvent>();
        _loggerMock = Substitute.For<ILogger<UpdateSaleHandler>>();

        _handler = new UpdateSaleHandler(_repositoryMock, _mapperMock, _publishEventMock, _loggerMock);
    }

    [Fact(DisplayName = "Should update sale with successfully")]
    [Trait("Application", "Application Sales Tests")]
    public async Task Handler_ValidRequest_ReturnSuccessResponse()
    {
        //Given
        const int once = 1;
        var command = UpdateSaleCommandMock.Builder();
        var saleMock = UpdateSaleMapperMock.CommandToEntity(command);
        var resultMock = UpdateSaleMapperMock.EntityToResult(saleMock);

        _mapperMock.Map<Sale>(command).Returns(saleMock);

        _repositoryMock.GetByIdAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>()).Returns(saleMock);
        _repositoryMock.UpdateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>()).Returns(saleMock);

        _mapperMock.Map<UpdateSaleResult>(saleMock).Returns(resultMock);

        //When
        var response = await _handler.Handle(command, new CancellationToken());

        //Then
        response.Should().BeOfType<UpdateSaleResult>();
        response.Id.Should().Be(saleMock.Id);

        await _repositoryMock.Received(once).GetByIdAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>());
        await _repositoryMock.Received(once).UpdateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>());
    }

    [Fact(DisplayName = "Invalid command must occur error")]
    [Trait("Application", "Application Sales Tests")]
    public async Task Handler_InvalidRequest_ReturnValidationError()
    {
        //Given
        const int never = 0;

        var command = UpdateSaleCommandMock.BuilderEmpty();

        //When
        var response = async () => await _handler.Handle(command, new CancellationToken());

        //Then
        await response.Should().ThrowAsync<ValidationException>();

        await _repositoryMock.Received(never).GetByIdAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>());
        await _repositoryMock.Received(never).UpdateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>());
    }

    [Fact(DisplayName = "Should return error sale not found")]
    [Trait("Application", "Application Sales Tests")]
    public async Task Handler_ValidRequest_ReturnErrorNotFound()
    {
        //Given
        const int once = 1;
        const int never = 0;

        var command = UpdateSaleCommandMock.Builder();
        var message = $"Sale Id: {command.Id}, not found!";

        //When
        var response = async () => await _handler.Handle(command, new CancellationToken());

        //Then
        await response.Should().ThrowAsync<KeyNotFoundException>().WithMessage(message);

        await _repositoryMock.Received(once).GetByIdAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>());
        await _repositoryMock.Received(never).UpdateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>());
    }

    [Fact(DisplayName = "Invalid sale must occur error by quantity invalid")]
    [Trait("Application", "Application Sales Tests")]
    public async Task Handler_InvalidSale_ReturnValidationError()
    {
        //Given
        const int once = 1;
        const int never = 0;

        var command = UpdateSaleCommandMock.Builder();
        var saleMock = UpdateSaleMapperMock.CommandToEntityInvalid(command);

        _repositoryMock.GetByIdAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>()).Returns(saleMock);

        _mapperMock.Map<Sale>(command).Returns(saleMock);

        //When
        var response = async () => await _handler.Handle(command, new CancellationToken());

        //Then
        await response.Should().ThrowAsync<ValidationException>();

        await _repositoryMock.Received(once).GetByIdAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>());
        await _repositoryMock.Received(never).UpdateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>());
    }
}
