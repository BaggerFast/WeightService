using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore.Storage;
using Ws.Database.EntityFramework.Entities.Ref1C.Brands;
using Ws.PalychExchange.Api.App.Features.Brands.Dto;

namespace Ws.PalychExchange.Api.App.Features.Brands.Impl;

internal partial class BrandApiService
{
    #region Resolve uniques db

    private void ResolveUniqueNameDb(HashSet<BrandDto> dtos)
    {
        HashSet<string> namesList = dtos.Select(dto => dto.Name).ToHashSet();
        HashSet<Guid> uidList = dtos.Select(dto => dto.Uid).ToHashSet();

        HashSet<string> existingNames = DbContext.Brands
            .Where(brand =>
                namesList.Any(name => name.Equals(brand.Name)) &&
                !uidList.Any(uid => uid.Equals(brand.Id))
            )
            .Select(brand => brand.Name)
            .ToHashSet();

        dtos.RemoveWhere(dto =>
        {
            if (!existingNames.Contains(dto.Name)) return false;
            OutputDto.AddError(dto.Uid, "Наименование не уникально (бд)");
            return true;
        });
    }

    #endregion

    private void SaveBrands(HashSet<BrandDto> validDtos)
    {
        DateTime updateDt = DateTime.UtcNow.AddHours(3);
        List<BrandEntity> brands = validDtos.Select(dto => dto.ToEntity(updateDt)).ToList();

        using IDbContextTransaction transaction = DbContext.Database.BeginTransaction();
        try
        {
            DbContext.BulkInsertOrUpdate(brands, options =>
            {
                options.UpdateByProperties = [nameof(BrandEntity.Id)];
                options.PropertiesToExcludeOnUpdate = [nameof(BrandEntity.CreateDt)];
            });

            transaction.Commit();

            OutputDto.AddSuccess(brands.Select(i => i.Id).ToList());
        }
        catch (Exception)
        {
            transaction.Rollback();
            OutputDto.AddError(brands.Select(i => i.Id).ToList(), "Не предвиденная ошибка");
        }
    }
}