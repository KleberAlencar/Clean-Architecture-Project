using CleanArc.Domain.Accounts.ValueObjects;
using CleanArc.Domain.Accounts.ValueObjects.Exceptions;

namespace CleanArc.Domain.Test.Accounts.ValueObjects;

public class NameTest
{
    private readonly Name _name = Name.Create("Kleber", "Santos");
    
    [Fact]
    public void Should_Override_ToString()
    {
        Assert.Equal("Kleber Santos", _name.ToString());
    }
    
    [Fact]
    public void Should_Implicit_Convert_ToString()
    {
        string data = _name;
        Assert.Equal("Kleber Santos", data);
    }
    
    [Fact]
    public void Should_Create_New_Name()
    {
        var name = Name.Create("Kleber", "Santos");
        Assert.Equal("Kleber Santos", name.ToString());
    }
    
    [Fact]
    public void Should_Fail_If_First_Name_Lenght_Is_Not_Valid()
    {
        Assert.Throws<InvalidFirstNameLengthException>(() =>
        {
            var name = Name.Create("K", "Santos");
        });
    }    
    
    [Fact]
    public void Should_Fail_If_Last_Name_Lenght_Is_Not_Valid()
    {
        Assert.Throws<InvalidLastNameLengthException>(() =>
        {
            var name = Name.Create("Kleber", "S");
        });
    }        
}