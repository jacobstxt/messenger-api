using Messenger.Api.Models.Auth;

namespace Messenger.Api.Interfaces;

public interface IAuthService
{
    public Task<string> LoginAsync(LoginModel model);
    public Task<string> RegisterAsync(RegisterModel model);
}
