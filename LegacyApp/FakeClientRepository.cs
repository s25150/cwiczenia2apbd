namespace LegacyApp;

public class FakeClientRepository
{
    public ClientRepository _clientRepository { get; }
    public FakeClientRepository()
    {
        _clientRepository = new ClientRepository();
    }
}