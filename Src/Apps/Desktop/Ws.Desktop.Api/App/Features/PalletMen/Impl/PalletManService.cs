using Microsoft.EntityFrameworkCore;
using Ws.Database.EntityFramework;
using Ws.Desktop.Api.App.Features.PalletMen.Common;
using Ws.Desktop.Models.Features.PalletMen;

namespace Ws.Desktop.Api.App.Features.PalletMen.Impl;

public class PalletManService(WsDbContext dbContext) : IPalletManService
{
    #region Queries

    public List<PalletMan> GetAllByArm(Guid armId)
    {
        Guid warehouse = dbContext.Lines.Where(i => i.Id == armId).Select(i => i.Warehouse.Id).Single();
        List<PalletMan> palletMen = dbContext.PalletMen
            .AsNoTracking()
            .Where(i => i.Warehouse.Id == warehouse)
            .Select(i => new PalletMan
            {
                Id = i.Id,
                Fio = new ()
                {
                    Name = i.Name,
                    Surname = i.Surname,
                    Patronymic = i.Patronymic
                },
                Password = i.Password
            })
            .ToList();
        return palletMen;
    }

    #endregion
}