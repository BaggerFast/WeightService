using Ws.DeviceControl.Api.App.Features.Admins.PalletMen.Common;
using Ws.DeviceControl.Models.Features.Admins.PalletMen.Commands.Create;
using Ws.DeviceControl.Models.Features.Admins.PalletMen.Commands.Update;
using Ws.DeviceControl.Models.Features.Admins.PalletMen.Queries;

namespace Ws.DeviceControl.Api.App.Features.Admins.PalletMen;

[ApiController]
[Route(RouteUtil.PalletMen)]
[Authorize(PolicyEnum.Support)]
public class PalletManController(IPalletManService palletManService)
{
    #region Queries

    [HttpGet]
    public Task<List<PalletManDto>> GetAllByProductionSite([FromQuery(Name = "productionSite")] Guid productionSiteId) =>
        palletManService.GetAllByProductionSiteAsync(productionSiteId);

    [HttpGet("{id:guid}")]
    public Task<PalletManDto> GetById([FromRoute] Guid id) =>
        palletManService.GetByIdAsync(id);

    #endregion

    #region Commands

    [HttpPut("{id:guid}")]
    public Task<PalletManDto> Update([FromRoute] Guid id, [FromBody] PalletManUpdateDto dto) =>
        palletManService.UpdateAsync(id, dto);

    [HttpPost]
    [Authorize(PolicyEnum.SeniorSupport)]
    public Task<PalletManDto> Create([FromBody] PalletManCreateDto dto) => palletManService.CreateAsync(dto);

    [HttpDelete("{id:guid}")]
    [Authorize(PolicyEnum.SeniorSupport)]
    public Task Delete([FromRoute] Guid id) => palletManService.DeleteAsync(id);

    #endregion
}