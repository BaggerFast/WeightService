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

	private List<PrinterModel> Printers { get; set; }
	private List<TemplateModel> Templates { get; set; }
	private List<WorkShopModel> WorkShops { get; set; }
	private List<TypeModel<string>> ComPorts { get; set; }
	private List<HostModel> Hosts { get; set; }
	
	public ItemScale()
	{
		Printers = new();
		ComPorts = new();
		Hosts = new();
		WorkShops = new();
		Templates = new();
		RazorComponentConfig.IsShowFilterAdditional = true;
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
				SqlItemCast = AppSettings.DataAccess.GetItemByIdNotNull<ScaleModel>(IdentityId);
				SqlItemCast.Host ??= new() { Name = LocaleCore.Table.FieldNull };
				SqlItemCast.PrinterMain ??= new() { Name = LocaleCore.Table.FieldNull };
				SqlItemCast.PrinterShipping ??= new() { Name = LocaleCore.Table.FieldNull };
				SqlItemCast.TemplateDefault ??= new() { Title = LocaleCore.Table.FieldNull };
				SqlItemCast.TemplateSeries ??= new() { Title = LocaleCore.Table.FieldNull };
				SqlItemCast.WorkShop ??= new() { Name = LocaleCore.Table.FieldNull };

			    // ComPorts
			    ComPorts = SerialPortsUtils.GetListTypeComPorts(LangEnum.English);
			    // ScaleFactor
			    SqlItemCast.ScaleFactor ??= 1000;
				Hosts = AppSettings.DataAccess.GetListHosts(false, false, true);
			    Printers = AppSettings.DataAccess.GetListPrinters(false, false, true);
			    Templates = AppSettings.DataAccess.GetListTemplates(false, false, true);
			    WorkShops = AppSettings.DataAccess.GetListWorkShops(false, false, true);
			}
		});
	}

	#endregion
}