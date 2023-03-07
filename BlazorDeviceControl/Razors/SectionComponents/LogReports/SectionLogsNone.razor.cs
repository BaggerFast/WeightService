﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace BlazorDeviceControl.Razors.SectionComponents.LogReports;
  
public partial class SectionLogsNone : RazorComponentSectionBase<LogModel>
{
	#region Public and private fields, properties, constructor

    #endregion

    #region Public and private methods

    protected override void OnParametersSet()
    {
        RunActionsParametersSet(new()
        {
            () =>
            {
	            SqlCrudConfigModel sqlCrudConfig = SqlCrudConfigUtils.GetCrudConfig(
		            nameof(LogTypeModel.Number), (byte)LogTypeEnum.None,
		            SqlCrudConfigItem.IsResultShowMarked, SqlCrudConfigItem.IsResultShowOnlyTop);
				SqlItem = DataAccess.GetItemNotNullable<LogTypeModel>(sqlCrudConfig);
                AutoShowFilterOnlyTopSetup();
            }
        });
    }

    #endregion
}