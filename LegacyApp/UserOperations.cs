using System;
using System.Runtime.InteropServices.JavaScript;
using System.Text.RegularExpressions;

namespace LegacyApp;

public class UserOperations : IUserValidation
{
    public bool ValidationResult { get; }
    
    public UserOperations(string firstName, string lastName, string email, DateTime dateOfBirth)
    {
        ValidationResult = IsNull(firstName, lastName) && DoesNotContain(email) && IsAgeAtLeast21(dateOfBirth);
    }
    

    /**
    * method returns true if given strings (first name and last name) are null or empty
    */
    public bool IsNull(string fname, string lname)
    {
        return !string.IsNullOrEmpty(fname) && !string.IsNullOrEmpty(lname);
    }
    
    /**
     * method returns true if given string (email) contains '@' or '.'
     */ 
    public bool DoesNotContain(string email)
    {
        return Regex.IsMatch(email, "[@.]");
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
    public bool IsAgeAtLeast21(DateTime dateOfBirth)
    {
        var now = DateTime.Now;
        int age = now.Year - dateOfBirth.Year;
        CheckMonthAndDay(age, dateOfBirth, now);
        return age >= 21;
    }
    
    
}