using Ws.PalychExchange.Api.App.Features.Plus.Common;
using Ws.PalychExchange.Api.App.Features.Plus.Dto;

namespace Ws.PalychExchange.Api.App.Features.Plus;

[ApiController]
[Route(ApiEndpoints.Plu)]
public sealed class PluController(IPluService pluService)
{
    [HttpPost("load")]
    public ResponseDto Load(PlusWrapper wrapper) => pluService.Load(wrapper.Plus);
}