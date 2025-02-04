// ReSharper disable ClassNeverInstantiated.Global
namespace Pl.Admin.Client.Source.Shared.Helpers;

public class UserHelper(
    ClaimsPrincipal user,
    IAuthorizationService authorizationService
)
{
    public async Task<bool> ValidatePolicyAsync(string policy) =>
        (await authorizationService.AuthorizeAsync(user, policy)).Succeeded;
}