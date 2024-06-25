using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace BlogAppClient.States.Authentication;

public class CustomAuthenticationStateProvider(ILocalStorageService localStorageService) : AuthenticationStateProvider
{
    private ClaimsPrincipal anonymous = new(new ClaimsIdentity());
    public async override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        try
        {
            string stringToken = await localStorageService.GetItemAsStringAsync("token");

            if (string.IsNullOrWhiteSpace(stringToken))
                return await Task.FromResult(new AuthenticationState(anonymous));

            var claims = AuthGenerics.GetClaimsFromToken(stringToken);

            var claimsPrincipal = AuthGenerics.SetClaimPrincipal(claims);
            return await Task.FromResult(new AuthenticationState(claimsPrincipal));
        }
        catch
        {
            return await Task.FromResult(new AuthenticationState(anonymous));
        }
    }

    public async Task UpdateAuthenticationState(string? token)
    {
        ClaimsPrincipal claimsPrincipal = new();
        if (!string.IsNullOrWhiteSpace(token))
        {
            var userSession = AuthGenerics.GetClaimsFromToken(token);
            claimsPrincipal = AuthGenerics.SetClaimPrincipal(userSession);
            await localStorageService.SetItemAsStringAsync("token", token);
        }
        else
        {
            claimsPrincipal = anonymous;
            await localStorageService.RemoveItemAsync("token");
        }
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
    }
}
