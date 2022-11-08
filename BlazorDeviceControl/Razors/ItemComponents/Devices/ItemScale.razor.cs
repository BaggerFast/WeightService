﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using BlazorCore.Razors;

namespace BlazorDeviceControl.Razors.ItemComponents.Devices;

/// <summary>
/// Scale item page.
/// </summary>
public partial class ItemScale : RazorComponentItemBase<ScaleModel>
{
	#region Public and private fields, properties, constructor

	private List<TypeModel<string>> ComPorts { get; set; }

	public ItemScale()
	{
		SqlCrudConfigItem.IsGuiShowItemsCount = true;
		SqlCrudConfigItem.IsGuiShowFilterAdditional = true;
		SqlCrudConfigItem.IsGuiShowFilterMarked = true;
		ComPorts = new();
		ButtonSettings = new(false, false, false, false, false, true, true);
	}

	#endregion

	#region Public and private methods

	protected override void OnParametersSet()
	{
		RunActionsParametersSet(new()
		{
			() =>
			{
				DataContext.GetListNotNull<DeviceModel>(SqlCrudConfigList);
				DataContext.GetListNotNull<DeviceTypeModel>(SqlCrudConfigList);
				DataContext.GetListNotNull<PrinterModel>(SqlCrudConfigList);
				DataContext.GetListNotNull<TemplateModel>(SqlCrudConfigList);
				DataContext.GetListNotNull<WorkShopModel>(SqlCrudConfigList);

				SqlItemCast = DataContext.GetItemNotNull<ScaleModel>(IdentityId);
				SqlItemCast.PrinterMain ??= DataAccess.GetItemNew<PrinterModel>();
				SqlItemCast.PrinterShipping ??= DataAccess.GetItemNew<PrinterModel>();
				SqlItemCast.TemplateDefault ??= DataAccess.GetItemNew<TemplateModel>();
				SqlItemCast.TemplateSeries ??= DataAccess.GetItemNew<TemplateModel>();
				SqlItemCast.WorkShop ??= DataAccess.GetItemNew<WorkShopModel>();
				//SqlItemCast.Device = DataAccess.GetItemDeviceNotNull(SqlItemCast);
				SqlItemCast.Device = DataAccess.GetItemNew<DeviceModel>();

			    // ComPorts
			    ComPorts = SerialPortsUtils.GetListTypeComPorts(LangEnum.English);
			    // ScaleFactor
			    SqlItemCast.ScaleFactor ??= 1000;
			}
		});
	}

	#endregion
}
