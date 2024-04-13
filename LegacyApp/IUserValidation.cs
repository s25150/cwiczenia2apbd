

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
    protected bool IsNull(User user);


    /**
     * method checks if string contains
     */
    protected bool DoesNotContain(User user);
    
    /**
     * method checks if age is at least 21
     */
    protected bool IsAgeAtLeast21(User user);

    /**
     * method checks credit limit of client
     */
    protected bool CheckClientCreditLimit(User user);

}