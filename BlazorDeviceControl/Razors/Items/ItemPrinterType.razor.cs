﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace BlazorDeviceControl.Razors.Items;

public partial class ItemPrinterType : RazorPageBase
{
	#region Public and private fields, properties, constructor

	private PrinterTypeModel ItemCast { get => Item is null ? new() : (PrinterTypeModel)Item; set => Item = value; }

	#endregion

	#region Public and private methods

	protected override void OnInitialized()
	{
		base.OnInitialized();

		RunActionsInitialized(new()
		{
			() =>
			{
				Table = new TableScaleModel(SqlTableScaleEnum.PrintersTypes);
				ItemCast = new();
			}
		});
	}

	protected override void OnParametersSet()
	{
		base.OnParametersSet();

		RunActionsParametersSet(new()
		{
			() =>
			{
				switch (TableAction)
				{
					case SqlTableActionEnum.New:
						ItemCast = new();
						ItemCast.SetDtNow();
						ItemCast.IsMarked = false;
						ItemCast.Name = "NEW PRINTER";
						break;
					default:
						ItemCast = AppSettings.DataAccess.GetItemByIdNotNull<PrinterTypeModel>(IdentityId);
						break;
				}

				if (TableAction == SqlTableActionEnum.New)
				{
					//ItemCast.Identity.Id = (long)IdentityId;
					ItemCast.Name = "NEW PRINTER_TYPE";
				}

				ButtonSettings = new(false, false, false, false, false, true, true);
			}
		});
	}

	#endregion
}
