using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace LegacyApp
{
    public class UserService
    {
        private ClientRepository _clientRepository = new ClientRepository();
        private UserCreditService _userCreditService = new UserCreditService();
        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            var operations = new UserOperations(firstName, lastName, email, dateOfBirth);
            var result = operations.ValidationResult;
            if (!result)
            {
                return result;
            }
            
            
            //infrastruktura
            //var clientRepository = new ClientRepository();
            var client = _clientRepository.GetById(clientId);
            
            
            //bl
            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };
            //bl + infrastruktura
            if (client.Type == "VeryImportantClient")
            {
                user.HasCreditLimit = false;
            }
            else if (client.Type == "ImportantClient")
            {
                //infrastruktura
                using (_userCreditService)
                {
                    
                    int creditLimit = _userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                    creditLimit = creditLimit * 2;
                    user.CreditLimit = creditLimit;
                }
            }
            else
            {
                user.HasCreditLimit = true;
                //infrastruktura
                using (_userCreditService)
                {
                    int creditLimit = _userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                    user.CreditLimit = creditLimit;
                }
            }
            //bl
            if (user.HasCreditLimit && user.CreditLimit < 500)
            {
                return false;
            }
            //infrastruktura
            UserDataAccess.AddUser(user);
            return true;
        }
    }
}
