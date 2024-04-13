using System.Collections.Generic;

namespace LegacyApp;

public class DatabaseSimulation
{
    /// <summary>
    /// Simulating database
    /// </summary>
    public readonly Dictionary<string, int> _usersdatabase =
        new Dictionary<string, int>()
        {
            {"Kowalski", 200},
            {"Malewski", 20000},
            {"Smith", 10000},
            {"Doe", 3000},
            {"Kwiatkowski", 1000}
        };
    
    //could add methods for checking if database contains lastname
}