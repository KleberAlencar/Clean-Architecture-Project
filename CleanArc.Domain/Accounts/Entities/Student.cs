using CleanArc.Domain.Accounts.Events;
using CleanArc.Domain.Shared.Entities;
using CleanArc.Domain.Shared.Abstractions;
using CleanArc.Domain.Accounts.ValueObjects;
using CleanArc.Domain.Shared.Aggregates.Abstractions;

namespace CleanArc.Domain.Accounts.Entities;

public sealed class Student : Entity, IAggregateRoot
{
    #region [ Constructors ]

    private Student() : base(Guid.CreateVersion7())
    {
    }
    
    private Student(
        Name name, 
        Email email, 
        IDateTimeProvider dateTimeProvider) : base(Guid.CreateVersion7())
    {
        Name = name;
        Email = email;
        Tracker = Tracker.Create(dateTimeProvider);       
    }    
    
    private Student(
        string firstName, 
        string lastName, 
        string email, 
        IDateTimeProvider dateTimeProvider) : base(Guid.CreateVersion7())
    {
        Name = Name.Create(firstName, lastName);
        Email = Email.Create(email);
        Tracker = Tracker.Create(dateTimeProvider);       
    }
    
    #endregion

    #region [ Factory Methods ]

    public static Student Create(Name name, Email email, IDateTimeProvider dateTimeProvider)
    {
        var student = new Student(name, email, dateTimeProvider);
        student.RaiseEvent(new OnStudentCreatedEvent(student.Id, student.Name, student.Email));
        return student;
    }

    public static Student Create(string firstName, string lastName, string email, IDateTimeProvider dateTimeProvider)
    {
        var student = new Student(firstName, lastName, email, dateTimeProvider);
        student.RaiseEvent(new OnStudentCreatedEvent(student.Id, student.Name, student.Email));       
        return student;       
    }

    #endregion
    
    #region [ Properties ]

    public Name Name { get; } = null!;

    public Email Email { get; } = null!;

    public Tracker Tracker { get; set; } = null!;

    #endregion
    
    #region [ Overrides ]
    
    public override string ToString() => Name;
    
    #endregion
}