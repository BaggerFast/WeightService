namespace Ws.Shared.Web.Extensions;

public static class ClaimsPrincipalExtensions
{
    [Pure]
    public static Guid GetGuidFromClaim(this ClaimsPrincipal principal, string claimType) =>
        Guid.TryParse(principal.FindFirst(claimType)?.Value, out Guid result) ? result : Guid.Empty;
}