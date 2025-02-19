namespace Ambev.DeveloperEvaluation.Domain.Events;

public interface IPublishEvent
{
    Task SendMessage(string message);
}
