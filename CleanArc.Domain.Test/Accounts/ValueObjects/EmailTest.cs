using CleanArc.Domain.Accounts.ValueObjects;
using CleanArc.Domain.Accounts.ValueObjects.Exceptions;

namespace CleanArc.Domain.Test.Accounts.ValueObjects;

public class EmailTest
{
    [Theory]
    [InlineData("kleber@outlook.com")]
    [InlineData("kleber@gmail.com")]
    [InlineData("kleber@hotmail.com")]
    public void Should_Create_New_Email(string address)
    {
        var email = Email.Create(address);
        Assert.Equal(email.Address, address);       
    }
    
    [Theory]
    [InlineData(" ")]
    [InlineData("")]
    public void Should_Fail_To_Create_New_Email(string address)
    {
        Assert.Throws<InvalidEmailLengthException>(() =>
        {
            var email = Email.Create(address);       
        });
    }
    
    [Theory]
    [InlineData("123456!@#")]
    [InlineData("teste_string_sem_valor")]
    public void Should_Fail_To_Create_New_Email_If_Address_Not_Valid(string address)
    {
        Assert.Throws<InvalidEmailException>(() =>
        {
            var email = Email.Create(address);       
        });
    }    
}