using Microsoft.EntityFrameworkCore.Storage;
using Ws.Database.EntityFramework.Entities.Ref1C.Bundles;
using Ws.PalychExchange.Api.App.Features.Bundles.Dto;

namespace Ws.PalychExchange.Api.App.Features.Bundles.Impl;

internal partial class BundleApiService
{
    private void SaveBundles(HashSet<BundleDto> validDtos)
    {
        DateTime updateDt = DateTime.UtcNow.AddHours(3);
        List<BundleEntity> bundles = validDtos.Select(dto => dto.ToEntity(updateDt)).ToList();

        using IDbContextTransaction transaction = DbContext.Database.BeginTransaction();
        try
        {
            DbContext.BulkMerge(bundles, options =>
            {
                options.InsertIfNotExists = true;
                options.IgnoreOnMergeInsertExpression = c => new { c.CreateDt, c.ChangeDt };
                options.IgnoreOnMergeUpdateExpression = c => new { c.CreateDt };
            });
            transaction.Commit();
            OutputDto.AddSuccess(bundles.Select(i => i.Id).ToList());
        }
        catch (Exception)
        {
            transaction.Rollback();
            OutputDto.AddError(bundles.Select(i => i.Id).ToList(), "Не предвиденная ошибка");
        }
    }
}