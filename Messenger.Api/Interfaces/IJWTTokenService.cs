using Messenger.Api.Entities.Identity;

namespace Messenger.Api.Interfaces;

public interface IJWTTokenService
{
    Task<string> CreateTokenAsync(UserEntity user);
}
