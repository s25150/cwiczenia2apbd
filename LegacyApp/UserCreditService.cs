using System;
using System.Threading;

namespace LegacyApp
{
    public class UserCreditService : IDisposable
    {
        private static readonly DatabaseSimulation _database = new DatabaseSimulation();

        public void Dispose()
        {
            //Simulating disposing of resources
        }

        /// <summary>
        /// This method is simulating contact with remote service which is used to get info about someone's credit limit
        /// </summary>
        /// <returns>Client's credit limit</returns>
        internal int GetCreditLimit(string lastName, DateTime dateOfBirth)
        {
            int randomWaitingTime = new Random().Next(3000);
            Thread.Sleep(randomWaitingTime);

            if (_database._usersdatabase.ContainsKey(lastName))
                return _database._usersdatabase[lastName];

            throw new ArgumentException($"Client {lastName} does not exist");
        }
    }
}