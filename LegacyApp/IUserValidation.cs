

using System;

namespace LegacyApp;
/**
 * interface responsible for User validation
 */
public interface IUserValidation
{
    /**
     * method checks if one of two values are nulls
     */
    public bool IsNull(string fname, string lname);


    /**
     * method checks if string contains
     */
    public bool DoesNotContain(string email);
    
    /**
     * method checks if age is at least 21
     */
    public bool IsAgeAtLeast21(DateTime dateOfBirth);

}