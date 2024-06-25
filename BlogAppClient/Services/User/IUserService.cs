using BlogAppClient.Models.Common;
using BlogAppClient.Models.User;

namespace BlogAppClient.Services.User;

public interface IUserService
{
    Task<Result<string>> CreateUser(RegisterRequest registerRequest);
    Task<Result<LoginResponse>> LoginUser(LoginRequest loginRequest);
}
