using System.Transactions;

namespace LegacyApp;

public class FakeUserCreditService
{
    public UserCreditService _UserCreditService { get; }

    public FakeUserCreditService()
    {
        _UserCreditService = new UserCreditService();
    }
}