﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace BlazorCore.Razors;

public partial class RazorComponentBase
{
	#region Public and private methods

	///// <summary>
	///// Write code for extension.
	///// </summary>
	//protected override void OnInitialized()
	//{
	//	//
	//}

	/// <summary>
	/// Write code for extension.
	/// </summary>
	protected override void OnParametersSet()
	{
        RunActionsParametersSet(new()
        {
            () =>
            {
                //
            }
        });
    }

    #endregion
}