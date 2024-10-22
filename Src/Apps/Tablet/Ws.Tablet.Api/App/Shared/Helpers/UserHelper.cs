using Ws.Shared.Web.Extensions;

namespace Ws.Tablet.Api.App.Shared.Helpers;

public sealed class UserHelper(IHttpContextAccessor httpContextAccessor)
{
    #region Private

    public Guid UserId => User.GetGuidFromClaim(ClaimTypes.NameIdentifier);
    public Guid WarehouseId => User.GetGuidFromClaim(ClaimTypes.StreetAddress);

    private ClaimsPrincipal User => httpContextAccessor.HttpContext!.User;

    #endregion
}