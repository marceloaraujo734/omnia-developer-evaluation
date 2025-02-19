using Ambev.DeveloperEvaluation.Domain.Events;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Bus.Events.Sales;

public class PublishEvent(ILogger<PublishEvent> _logger) : IPublishEvent
{
    public async Task SendMessage(string message)
    {
        await Task.CompletedTask;

        _logger.LogInformation(message);
    }
}
