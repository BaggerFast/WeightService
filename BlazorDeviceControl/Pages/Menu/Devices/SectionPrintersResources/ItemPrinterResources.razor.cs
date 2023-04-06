// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore.Sql.TableScaleFkModels.PrintersResourcesFks;
using DataCore.Sql.TableScaleModels.Printers;
using DataCore.Sql.TableScaleModels.TemplatesResources;

namespace BlazorDeviceControl.Pages.Menu.Devices.SectionPrintersResources;

/// <summary>
/// Item PrinterResource page.
/// </summary>
public sealed partial class ItemPrinterResources : RazorComponentItemBase<PrinterResourceFkModel>
{
	#region Public and private fields, properties, constructor

	//

	#endregion

	#region Public and private methods

	protected override void OnParametersSet()
	{
		RunActionsParametersSet(new()
		{
			() =>
			{
                SqlItemCast = DataContext.GetItemNotNullable<PrinterResourceFkModel>(IdentityId);
                if (SqlItemCast.IsNew)
				{
					SqlItemCast = SqlItemNew<PrinterResourceFkModel>();
				}
				DataContext.GetListNotNullable<PrinterModel>(WsSqlCrudConfigUtils.GetCrudConfigComboBox());
				DataContext.GetListNotNullable<TemplateResourceModel>(WsSqlCrudConfigUtils.GetCrudConfigComboBox());
            }
		});
	}

	#endregion
}