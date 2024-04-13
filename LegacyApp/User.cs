using System;

namespace LegacyApp
{
    //bl
    public class User(object client, DateTime dateOfBirth, string emailAddress, string firstName, string lastName)
    {
        public object Client { get; internal set; } = client;
        public DateTime DateOfBirth { get; } = dateOfBirth;
        public string EmailAddress { get; } = emailAddress;
        public string FirstName { get; } = firstName;
        public string LastName { get; } = lastName;
        public bool HasCreditLimit { get; internal set; }
        public int CreditLimit { get; internal set; }
    }
}