using CleanArc.Domain.Test.Mocks;
using CleanArc.Domain.Accounts.Entities;
using CleanArc.Domain.Shared.Abstractions;
using CleanArc.Domain.Accounts.ValueObjects;

namespace CleanArc.Domain.Test.Accounts.Entities;

public class StudentTest
{
    private readonly IDateTimeProvider _dateTimeProvider = new FakeDateTimeProvider();
    
    [Fact]
    public void Should_Raise_OnStudentCreatedEvent_Primitive_Constructor()
    {
        var student = Student.Create("Kleber", "Santos", "kleber@outlook.com", _dateTimeProvider);
        Assert.Single(student.GetDomainEvents);
    } 
    
    [Fact]
    public void Should_Raise_OnStudentCreatedEvent()
    {
        var name = Name.Create("Kleber", "Santos");
        var email = Email.Create("kleber@outlook.com");
        var student = Student.Create(name, email, _dateTimeProvider);
        Assert.Single(student.GetDomainEvents);
    }     
}