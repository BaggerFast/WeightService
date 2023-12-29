using DeviceControl.Features.Shared.DataGrid;
using DeviceControl.Features.Shared.Modal;
using DeviceControl.Resources;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Ws.StorageCore.Utils;

namespace DeviceControl.Features.Sections.Diagnostics.Logs1C;

public sealed partial class Logs1CDataGrid: SectionDataGridBase<SqlLogWebEntity>
{
    [Inject] private IStringLocalizer<ApplicationResources> Localizer { get; set; } = null!;
    private SqlLogWebRepository SqlLogWebRepository { get; } = new();
    
    protected override void SetSqlSectionCast() =>
        SectionItems = SqlLogWebRepository.GetList(new()).ToList();
}