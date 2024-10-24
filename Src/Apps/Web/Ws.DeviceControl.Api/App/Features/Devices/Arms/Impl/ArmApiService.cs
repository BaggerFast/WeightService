using Ws.Database.Entities.Ref.Lines;
using Ws.Database.Entities.Ref.Printers;
using Ws.Database.Entities.Ref.Warehouses;
using Ws.Database.Entities.Ref1C.Plus;
using Ws.DeviceControl.Api.App.Features.Devices.Arms.Common;
using Ws.DeviceControl.Api.App.Features.Devices.Arms.Impl.Expressions;
using Ws.DeviceControl.Api.App.Features.Devices.Arms.Impl.Extensions;
using Ws.DeviceControl.Api.App.Features.Devices.Arms.Impl.Validators;
using Ws.DeviceControl.Models.Features.Devices.Arms.Commands;
using Ws.DeviceControl.Models.Features.Devices.Arms.Queries;

namespace Ws.DeviceControl.Api.App.Features.Devices.Arms.Impl;

internal sealed class ArmApiService(
    WsDbContext dbContext,
    ArmCreateApiValidator createValidator,
    ArmUpdateApiValidator updateValidator,
    UserHelper userHelper,
    ErrorHelper errorHelper
    ) : ApiService, IArmService
{
    #region Queries

    public Task<List<ArmDto>> GetAllByProductionSiteAsync(Guid productionSiteId)
    {
        return dbContext.Lines
            .AsNoTracking()
            .Where(i => i.Warehouse.ProductionSite.Id == productionSiteId)
            .Select(ArmExpressions.ToDto)
            .OrderBy(i => i.Name)
            .ToListAsync();
    }

    public async Task<ArmDto> GetByIdAsync(Guid id)
    {
        LineEntity entity = await dbContext.Lines.SafeGetById(id, errorHelper.Localize(ErrorType.NotFound, "Line"));
        return await GetArmDto(entity);
    }

    public async Task<List<PluArmDto>> GetArmPlus(Guid id)
    {
        LineEntity entity = await dbContext.Lines.SafeGetById(id, errorHelper.Localize(ErrorType.NotFound, "Line"));

        bool? isWeightFilter = entity.Type switch
        {
            ArmType.Pc => false,
            ArmType.Tablet => true,
            _ => null
        };

        List<Guid> linePluId = await dbContext.Lines
            .AsNoTracking()
            .Where(i => i.Id == id)
            .SelectMany(i => i.Plus)
            .Select(i => i.Id)
            .ToListAsync();

        return await dbContext.Plus
            .AsNoTracking()
            .IfWhere(isWeightFilter != null, p => p.IsWeight == isWeightFilter)
            .OrderBy(i => i.Number)
            .Select(ArmExpressions.ToPluDto(linePluId))
            .ToListAsync();
    }

    #endregion

    #region Commands

    public async Task<ArmDto> CreateAsync(ArmCreateDto dto)
    {
        await createValidator.ValidateAsync(dbContext.Lines, dto);

        PrinterEntity printer = await dbContext.Printers.SafeGetById(dto.PrinterId, errorHelper.Localize(ErrorType.NotFound, "Printer"));
        WarehouseEntity warehouse = await dbContext.Warehouses.SafeGetById(dto.WarehouseId, errorHelper.Localize(ErrorType.NotFound, "Warehouse"));

        LineEntity entity = dto.ToEntity(warehouse, printer);

        await userHelper.CanUserWorkWithProductionSiteAsync(warehouse.ProductionSiteId);

        await dbContext.Lines.AddAsync(entity);
        await dbContext.SaveChangesAsync();

        return await GetArmDto(entity);
    }

    public async Task<ArmDto> UpdateAsync(Guid id, ArmUpdateDto dto)
    {
        await updateValidator.ValidateAsync(dbContext.Lines, dto, id);

        LineEntity entity = await dbContext.Lines.SafeGetById(id, errorHelper.Localize(ErrorType.NotFound, "Line"));
        PrinterEntity printer = await dbContext.Printers.SafeGetById(dto.PrinterId, errorHelper.Localize(ErrorType.NotFound, "Printer"));
        WarehouseEntity warehouse = await dbContext.Warehouses.SafeGetById(dto.WarehouseId, errorHelper.Localize(ErrorType.NotFound, "Warehouse"));

        await userHelper.CanUserWorkWithProductionSiteAsync(warehouse.ProductionSiteId);

        dto.UpdateEntity(entity, printer, warehouse);
        await dbContext.SaveChangesAsync();

        return await GetArmDto(entity);
    }

    public async Task DeletePluAsync(Guid armId, Guid pluId)
    {
        LineEntity line = await dbContext.Lines
          .Include(l => l.Plus)
          .FirstOrDefaultAsync(l => l.Id == armId)
                ?? throw new("АРМ не найдено");

        PluEntity plu = await dbContext.Plus.SafeGetById(pluId, "ПЛУ не найдено");
        line.Plus.Remove(plu);
        await dbContext.SaveChangesAsync();
    }

    public async Task AddPluAsync(Guid armId, Guid pluId)
    {
        LineEntity line = await dbContext.Lines
          .Include(l => l.Plus)
          .FirstOrDefaultAsync(l => l.Id == armId)
                ?? throw new("АРМ не найдено");

        PluEntity plu = await dbContext.Plus.SafeGetById(pluId, "ПЛУ не найдено");

        if (line.Plus.Any(i => i.Id == pluId))
            return;

        line.Plus.Add(plu);

        await dbContext.SaveChangesAsync();
    }

    public Task DeleteAsync(Guid id) => dbContext.Lines.SafeDeleteAsync(i => i.Id == id);

    #endregion

    #region Private

    private async Task<ArmDto> GetArmDto(LineEntity entity)
    {
        await dbContext.Entry(entity).Reference(e => e.Printer).LoadAsync();
        await dbContext.Entry(entity).Reference(e => e.Warehouse).LoadAsync();
        await dbContext.Entry(entity.Warehouse).Reference(e => e.ProductionSite).LoadAsync();

        return ArmExpressions.ToDto.Compile().Invoke(entity);
    }

    #endregion
}