﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using BlazorCore.Razors;

namespace BlazorDeviceControl.Razors.ItemComponents.Plus;

public partial class ItemPluPackage : RazorComponentItemBase<PluPackageModel>
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
                SqlItemCast = DataContext.GetItemNotNull<PluPackageModel>(IdentityUid);
                DataContext.GetListNotNull<PluModel>();
				DataContext.GetListNotNull<PackageModel>();
                
				if (SqlItemCast.IdentityIsNew)
                {
	                SqlItem = SqlItemNew<PluPackageModel>();
                    if (DataContext.Plus.Any())
						SqlItemCast.Plu = DataContext.Plus.First();
                    if (DataContext.Packages.Any())
						SqlItemCast.Package = DataContext.Packages.First();
                }

	            ButtonSettings = new(false, false, false, false, false, true, true);
            }
        });
    }

    #endregion
}
