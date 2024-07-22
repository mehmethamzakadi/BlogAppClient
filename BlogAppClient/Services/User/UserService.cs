
using Blazored.LocalStorage;
using BlogAppClient.Models.Common;
using BlogAppClient.Models.User;
using BlogAppClient.States.Authentication;

namespace BlogAppClient.Services.User;
public class UserService(HttpClient httpClient, ILocalStorageService localStorageService) : IUserService
{
    public async Task<Result<string>> CreateUser(RegisterRequest registerRequest)
    {
        var response = await httpClient
                 .PostAsync("user",
                 AuthGenerics.GenerateStringContent(
                 AuthGenerics.SerializeObj(registerRequest)));

        //Read Response
        if (!response.IsSuccessStatusCode)
            return new Result<string> { Data = null, Success = false, Message = "Bir hata oluştu. Tekrar deneyiniz." };

        var apiResponse = await response.Content.ReadAsStringAsync();
        return AuthGenerics.DeserializeJsonString<Result<string>>(apiResponse);
    }

    public async Task<Result<LoginResponse>> LoginUser(LoginRequest loginRequest)
    {
        var response = await httpClient
               .PostAsync("auth/login",
               AuthGenerics.GenerateStringContent(
               AuthGenerics.SerializeObj(loginRequest)));

        //Read Response
        if (!response.IsSuccessStatusCode)
            return new Result<LoginResponse> { Data = null, Success = false, Message = "Bir hata oluştu. Tekrar deneyiniz." };

        var apiResponse = await response.Content.ReadAsStringAsync();

        var loginResponse = AuthGenerics.DeserializeJsonString<Result<LoginResponse>>(apiResponse);
        if (loginResponse.Success)
        {
            await localStorageService.SetItemAsStringAsync("token", loginResponse.Data.Token);
        }
        else
        {
            await localStorageService.RemoveItemAsync("token");
        }

        return loginResponse;
    }
}
