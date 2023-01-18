﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace BlazorDeviceControl.Razors.SectionComponents.LogReports;

public partial class SectionLogsErrors : RazorComponentSectionBase<LogModel, LogTypeModel>
{
	#region Public and private fields, properties, constructor

    public SectionLogsErrors() : base()
    {
	    ButtonSettings = new(false, true, false, false, false, false, false);
    }

	#endregion

	#region Public and private methods

	protected override void OnParametersSet()
	{
		RunActionsParametersSet(new()
		{
			() =>
			{
				SqlCrudConfigModel sqlCrudConfig = SqlCrudConfigUtils.GetCrudConfig(
					nameof(LogTypeModel.Number), (byte)LogTypeEnum.Error,
					SqlCrudConfigSection.IsResultShowMarked, SqlCrudConfigSection.IsResultShowOnlyTop);
				SqlItem = BlazorAppSettings.DataAccess.GetItemNotNullable<LogTypeModel>(sqlCrudConfig);
			}
		});
	}

    #endregion
}