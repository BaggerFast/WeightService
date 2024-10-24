using Ws.Database.Entities.Ref.ProductionSites;
using Ws.DeviceControl.Api.App.Features.References.ProductionSites.Common;
using Ws.DeviceControl.Api.App.Features.References.ProductionSites.Impl.Expressions;
using Ws.DeviceControl.Api.App.Features.References.ProductionSites.Impl.Extensions;
using Ws.DeviceControl.Api.App.Features.References.ProductionSites.Impl.Validators;
using Ws.DeviceControl.Models.Features.References.ProductionSites.Commands;
using Ws.DeviceControl.Models.Features.References.ProductionSites.Queries;

namespace Ws.DeviceControl.Api.App.Features.References.ProductionSites.Impl;

internal sealed class ProductionSiteApiService(
    WsDbContext dbContext,
    UserHelper userHelper,
    ProductionSiteCreateApiValidator createValidator,
    ProductionSiteUpdateApiValidator updateValidator
    ) : IProductionSiteService
{
    #region Queries

    public async Task<ProxyDto> GetProxyByUser()
    {
        ProxyDto? data = await userHelper.GetUserProductionSiteAsync();
        if (data == null) throw new ApiInternalException
        {
            ErrorDisplayMessage = "Площадка не установлена",
            StatusCode = HttpStatusCode.NotFound
        };
        return data;
    }

    public async Task<List<ProxyDto>> GetProxiesAsync()
    {
        bool seniorSupport = await userHelper.ValidatePolicyAsync(PolicyEnum.SeniorSupport);
        if (seniorSupport)
        {
            bool developer = await userHelper.ValidatePolicyAsync(PolicyEnum.Developer);
            return await dbContext.ProductionSites
                .AsNoTracking()
                .IfWhere(!developer, entity => entity.Id != DefaultTypes.GuidMax)
                .Select(ProductionSiteCommonExpressions.ToProxy)
                .OrderBy(i => i.Name)
                .ToListAsync();
        }
        ProxyDto? userProductionSite = await userHelper.GetUserProductionSiteAsync();
        return userProductionSite != null ? [userProductionSite] : [];
    }

    public async Task<ProductionSiteDto> GetByIdAsync(Guid id) =>
        ProductionSiteExpressions.ToDto.Compile().Invoke(await dbContext.ProductionSites.SafeGetById(id, "Не найдено"));

    public Task<List<ProductionSiteDto>> GetAllAsync() => dbContext.ProductionSites
        .AsNoTracking().Select(ProductionSiteExpressions.ToDto)
        .OrderBy(i => i.Name)
        .ToListAsync();

    #endregion

    #region Commands

    public async Task<ProductionSiteDto> CreateAsync(ProductionSiteCreateDto dto)
    {
        await createValidator.ValidateAsync(dbContext.ProductionSites, dto);

        ProductionSiteEntity entity = dto.ToEntity();

        await dbContext.ProductionSites.AddAsync(entity);
        await dbContext.SaveChangesAsync();

        return ProductionSiteExpressions.ToDto.Compile().Invoke(entity);
    }

    public async Task<ProductionSiteDto> UpdateAsync(Guid id, ProductionSiteUpdateDto dto)
    {
        await updateValidator.ValidateAsync(dbContext.ProductionSites, dto, id);

        ProductionSiteEntity entity = await dbContext.ProductionSites.SafeGetById(id, "Не найдено");
        dto.UpdateEntity(entity);
        await dbContext.SaveChangesAsync();

        return ProductionSiteExpressions.ToDto.Compile().Invoke(entity);
    }

    public Task DeleteAsync(Guid id) => dbContext.ProductionSites.SafeDeleteAsync(i => i.Id == id);

    #endregion
}