﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace BlazorDeviceControl.Razors.Items;

public partial class ItemBarCodeType : BlazorCore.Models.RazorBase
{
	#region Public and private fields, properties, constructor

	private BarCodeTypeEntity ItemCast { get => Item == null ? new() : (BarCodeTypeEntity)Item; set => Item = value; }

	#endregion

	#region Public and private methods

	protected override void OnInitialized()
	{
		base.OnInitialized();

		Table = new TableScaleEntity(ProjectsEnums.TableScale.BarCodeTypes);
		ItemCast = new();
	}

	protected override void OnParametersSet()
	{
		base.OnParametersSet();

		RunActions(new()
		{
			() =>
			{
				switch (TableAction)
				{
					case DbTableAction.New:
						ItemCast = new();
						ItemCast.ChangeDt = ItemCast.CreateDt = DateTime.Now;
						ItemCast.IsMarked = false;
						ItemCast.Name = "NEW BARCODE_TYPE";
						break;
					default:
						ItemCast = AppSettings.DataAccess.Crud.GetEntity<BarCodeTypeEntity>(
							new(new() { new(DbField.IdentityUid, DbComparer.Equal, IdentityUid) }));
						break;
				}

				ButtonSettings = new(false, false, false, false, false, true, true);
			}
		});
	}

	#endregion
}
