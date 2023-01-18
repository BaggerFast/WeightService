﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore.Sql.TableScaleModels.PrintersTypes;

namespace BlazorDeviceControl.Razors.ItemComponents.Printers;

public partial class ItemPrinterType : RazorComponentItemBase<PrinterTypeModel>
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
                SqlItemCast = DataAccess.GetItemNotNullable<PrinterTypeModel>(IdentityId);
                if (SqlItemCast.IsNew)
                {
					SqlItemCast = SqlItemNew<PrinterTypeModel>();
				}

				ButtonSettings = new(false, false, false, false, false, true, true);
			}
		});
	}

	#endregion
}
