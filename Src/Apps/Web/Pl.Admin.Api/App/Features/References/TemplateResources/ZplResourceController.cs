using Pl.Admin.Api.App.Features.References.TemplateResources.Common;
using Pl.Admin.Models.Features.References.TemplateResources.Commands;
using Pl.Admin.Models.Features.References.TemplateResources.Queries;

namespace Pl.Admin.Api.App.Features.References.TemplateResources;

[ApiController]
[Route(ApiEndpoints.TemplateResources)]
public sealed class ZplResourceController(IZplResourceService zplResourceService)
{
    #region Queries

    [Authorize(PolicyEnum.Support)]
    [HttpGet]
    public Task<TemplateResourceDto[]> GetAll() =>
        zplResourceService.GetAllAsync();

    [Authorize(PolicyEnum.Support)]
    [HttpGet("{id:guid}")]
    public Task<TemplateResourceDto> GetById([FromRoute] Guid id) =>
        zplResourceService.GetByIdAsync(id);

    [Authorize(PolicyEnum.Support)]
    [HttpGet("{id:guid}/body")]
    public Task<TemplateResourceBodyDto> GetBodyById([FromRoute] Guid id) =>
        zplResourceService.GetBodyByIdAsync(id);

    #endregion

    #region Commands

    [Authorize(PolicyEnum.Developer)]
    [HttpPost]
    public Task<TemplateResourceDto> Create([FromBody] ZplResourceCreateDto dto) =>
        zplResourceService.CreateAsync(dto);

    [Authorize(PolicyEnum.Developer)]
    [HttpPut("{id:guid}")]
    public Task<TemplateResourceDto> Update([FromRoute] Guid id, [FromBody] ZplResourceUpdateDto dto) =>
        zplResourceService.UpdateAsync(id, dto);

    [Authorize(PolicyEnum.Developer)]
    [HttpDelete("{id:guid}")]
    public Task Delete([FromRoute] Guid id) =>
        zplResourceService.DeleteAsync(id);

    #endregion
}