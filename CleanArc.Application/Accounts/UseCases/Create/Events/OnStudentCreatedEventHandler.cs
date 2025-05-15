using MediatR;
using CleanArc.Domain.Accounts.Events;

namespace CleanArc.Application.Accounts.UseCases.Create.Events;

public class OnStudentCreatedEventHandler : INotificationHandler<OnStudentCreatedEvent>
{
    public Task Handle(OnStudentCreatedEvent notification, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Student {notification.Name} created - {notification.Email}");
        return Task.CompletedTask;
    }
}