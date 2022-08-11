﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore;
using DataCore.Models;
using DataCore.Sql.Models;
using DataCore.Sql.TableScaleModels;
using static DataCore.ShareEnums;

namespace BlazorDeviceControl.Shared.Item;

public partial class ItemTaskModule
{
	#region Public and private fields, properties, constructor

	private TaskEntity ItemCast { get => Item == null ? new() : (TaskEntity)Item; set => Item = value; }

	#endregion

	#region Public and private methods

	protected override void OnInitialized()
	{
		base.OnInitialized();

		Table = new TableSystemEntity(ProjectsEnums.TableSystem.Tasks);
		ItemCast = new();
	}

	protected override void OnParametersSet()
	{
		base.OnParametersSet();

		RunActions(new()
		{
			() =>
			{
				ItemCast = AppSettings.DataAccess.Crud.GetEntity<TaskEntity>(
					new FilterListEntity(new() { new(DbField.IdentityUid, DbComparer.Equal, IdentityUid) }));
				if (IdentityId != null && TableAction == DbTableAction.New)
					ItemCast.IdentityId = (long)IdentityId;
				ButtonSettings = new(false, false, false, false, false, true, true);
			}
		});
	}

	#endregion
}
