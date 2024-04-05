using LegacyApp;

namespace LegacyAppTests;

public class UserServiceTests
{
    [Fact]
    public void AddUser_Should_Return_False_When_Without_At_And_Dot()
    {
        //Arrange
        string firstName = "Matheo";
        string lastName = "Clark";
        string email = "matclark";
        DateTime birthDate = new DateTime(2001, 2, 12);
        int clientId = 6;
        var service = new UserService();
        
        //Act
        bool result = service.AddUser(firstName, lastName, email, birthDate, clientId);
        
        //Assert
        Assert.False(result);
    }

    [Fact]
    public void AddUser_Should_Return_False_When_firstName_Is_Empty()
    {
        string firstName = "";
        string lastName = "Clark";
        string email = "mat@clark.";
        DateTime birthDate = new DateTime(2001, 2, 12);
        int clientId = 6;
        var service = new UserService();
        
        bool result = service.AddUser(firstName, lastName, email, birthDate, clientId);
        
        Assert.False(result);
    }

    [Fact] 
    public void AddUser_Should_Return_False_When_lastName_Is_Empty()
    {
        string firstName = "Matt";
        string lastName = "";
        string email = "mat@clark.";
        DateTime birthDate = new DateTime(2001, 2, 12);
        int clientId = 6;
        var service = new UserService();
        
        bool result = service.AddUser(firstName, lastName, email, birthDate, clientId);
        
        Assert.False(result);
    }
    [Fact] 
    public void AddUser_Should_Return_False_When_firstName_And_lastName_Is_Empty()
    {
        string firstName = "";
        string lastName = "";
        string email = "mat@clark.";
        DateTime birthDate = new DateTime(2001, 2, 12);
        int clientId = 6;
        var service = new UserService();
        
        bool result = service.AddUser(firstName, lastName, email, birthDate, clientId);
        
        Assert.False(result);
    }
    
    [Fact]
    public void AddUser_Should_Return_False_When_firstName_Is_Null()
    {
        string firstName = null;
        string lastName = "Clark";
        string email = "mat@clark.";
        DateTime birthDate = new DateTime(2001, 2, 12);
        int clientId = 6;
        var service = new UserService();
        
        bool result = service.AddUser(firstName, lastName, email, birthDate, clientId);
        
        Assert.False(result);
    }

    [Fact] 
    public void AddUser_Should_Return_False_When_lastName_Is_Null()
    {
        string firstName = "Matt";
        string lastName = null;
        string email = "mat@clark.";
        DateTime birthDate = new DateTime(2001, 2, 12);
        int clientId = 6;
        var service = new UserService();
        
        bool result = service.AddUser(firstName, lastName, email, birthDate, clientId);
        
        Assert.False(result);
    }
    [Fact] 
    public void AddUser_Should_Return_False_When_firstName_And_lastName_Is_Null()
    {
        string firstName = null;
        string lastName = null;
        string email = "mat@clark.";
        DateTime birthDate = new DateTime(2001, 2, 12);
        int clientId = 6;
        var service = new UserService();
        
        bool result = service.AddUser(firstName, lastName, email, birthDate, clientId);
        
        Assert.False(result);
    }
    
    [Fact]
    public void AddUser_Should_Return_False_When_Age_Lower_Than_21()
    {
        //Arrange
        string firstName = "Matt";
        string lastName = "Clark";
        string email = "mat.clar@k";
        DateTime birthDate = new DateTime(2020, 2, 12);
        int clientId = 6;
        var service = new UserService();
        
        //Act
        bool result = service.AddUser(firstName, lastName, email, birthDate, clientId);
        
        //Assert
        Assert.False(result);
    }
    
    //if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;
    /*[Fact]
    public void AddUser_Should_Decrement_Age_When_Month_Is_Lower_Than_Birth_Month()
    {
        string firstName = "Matt";
        string lastName = "Clark";
        string email = "matclark";
        DateTime birthDate = new DateTime(2001, 12, 12);
        int clientId = 6;
        int age = DateTime.Now.Year - birthDate.Year;
        var service = new UserService();
        DateTime birthMonth = dateOfBirth.Month;
        
        bool result = service.AddUser(firstName, lastName, email, birthDate, clientId);
        
        Assert.Equal();
    }*/
}