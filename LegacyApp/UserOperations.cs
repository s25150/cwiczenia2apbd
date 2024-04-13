using System;
using System.Runtime.InteropServices.JavaScript;
using System.Text.RegularExpressions;

namespace LegacyApp;

public class UserOperations : IUserValidation
{
    public bool ValidationResult { get; }
    
    public UserOperations(User user)
    {
        ValidationResult = IsNull(user)
                           && DoesNotContain(user) 
                           && IsAgeAtLeast21(user)
                           && CheckClientCreditLimit(user);
    }
    

    /**
    * method returns true if given strings (first name and last name) are null or empty
    */
    public bool IsNull(User user)
    {
        return !string.IsNullOrEmpty(user.FirstName) && !string.IsNullOrEmpty(user.LastName);
    }
    
    /**
     * method returns true if given string (email) contains '@' or '.'
     */ 
    public bool DoesNotContain(User user)
    {
        return Regex.IsMatch(user.EmailAddress, "[@.]");
    }
    
    /**
     * method compares current month and day with month and day of birth
     * and based on that returns either the same or decremented age
     */
    private int CheckMonthAndDay(int age, DateTime dateOfBirth, DateTime now)
    {
        if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;
        return age;
    }
    
    
    /**
     * method returns true if age is at least 21
     */
    public bool IsAgeAtLeast21(User user)
    {
        var now = DateTime.Now;
        int age = now.Year - user.DateOfBirth.Year;
        CheckMonthAndDay(age, user.DateOfBirth, now);
        return age >= 21;
    }
    
    /**
     * method check if client has credit limit or credit limit equals at least 500
     */
    public bool CheckClientCreditLimit(User user)
    {
        return !user.HasCreditLimit || user.CreditLimit >= 500;
    }

    /**
     * method sets users credit limit information based on their importancy
     */
    public void CheckClientImportancy(Client client, User user, UserCreditService userCreditService)
    {
        if (client.Type == "VeryImportantClient")
        {
            user.HasCreditLimit = false;
        }
        else if (client.Type == "ImportantClient")
        { 
            int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
            user.CreditLimit = creditLimit * 2;
        }
        else
        {
            user.HasCreditLimit = true;
            int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
            user.CreditLimit = creditLimit;
        }
        
    }
    
    
}