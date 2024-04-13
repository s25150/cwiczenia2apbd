using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace LegacyApp
{
    public class UserService
    {
        private FakeClientRepository _fakeClientRepository = new FakeClientRepository();
        private FakeUserCreditService _fakeUserCreditService = new FakeUserCreditService();
        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            var client = _fakeClientRepository._clientRepository.GetById(clientId);
            var user = new User(client, dateOfBirth, email, firstName, lastName);
            var operations = new UserOperations(user);
            var result = operations.ValidationResult;
            if (!result)
            {
                return result;
            }
            
            operations.CheckClientImportancy(client, user, _fakeUserCreditService._UserCreditService);
            UserDataAccess.AddUser(user);
            return true;
        }
    }
}
