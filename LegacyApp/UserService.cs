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
            var client = _clientRepository.GetById(clientId);
            var user = new User(client, dateOfBirth, email, firstName, lastName);
            var operations = new UserOperations(user);
            var result = operations.ValidationResult;
            if (!result)
            {
                return result;
            }
            
            operations.CheckClientImportancy(client, user, _userCreditService);
            UserDataAccess.AddUser(user);
            return true;
        }
    }
}
