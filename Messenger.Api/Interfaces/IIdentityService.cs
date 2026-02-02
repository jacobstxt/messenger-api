namespace Messenger.Api.Interfaces;

public interface IIdentityService
{
    Task<long> GetUserIdAsync();
}
