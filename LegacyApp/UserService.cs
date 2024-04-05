using System;

namespace LegacyApp
{
    public class UserService
    {
        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            //bl
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                return false;
            }
            //bl
            if (!email.Contains("@") && !email.Contains("."))
            {
                return false;
            }
            //bl
            var now = DateTime.Now;
            int age = now.Year - dateOfBirth.Year;
            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;
            //bl
            if (age < 21)
            {
                return false;
            }
            //infrastruktura
            var clientRepository = new ClientRepository();
            var client = clientRepository.GetById(clientId);
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
                using (var userCreditService = new UserCreditService())
                {
                    
                    int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                    creditLimit = creditLimit * 2;
                    user.CreditLimit = creditLimit;
                }
            }
            else
            {
                user.HasCreditLimit = true;
                //infrastruktura
                using (var userCreditService = new UserCreditService())
                {
                    int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
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
