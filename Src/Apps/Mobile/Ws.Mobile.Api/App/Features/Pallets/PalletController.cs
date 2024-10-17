using Ws.Mobile.Api.App.Features.Pallets.Common;
using Ws.Mobile.Models.Features.Pallets;

namespace Ws.Mobile.Api.App.Features.Pallets;

[ApiController]
[Route(ApiEndpoints.Pallets)]
public sealed class PalletController(IPalletService palletService)
{
    #region Commands

    [HttpPost]
    public void GetPluByCode([FromBody] PalletsMoveDto palletMoveDto) => palletService.Move(palletMoveDto);

    #endregion
}