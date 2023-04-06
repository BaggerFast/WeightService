﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore.Sql.TableScaleFkModels.PlusBundlesFks;
using DataCore.Sql.TableScaleModels.Bundles;
using DataCore.Sql.TableScaleModels.Plus;

namespace BlazorDeviceControl.Pages.Menu.References1C.SectionPlusBundlesFks;

public sealed partial class ItemPluBundleFk : RazorComponentItemBase<PluBundleFkModel>
{
    #region Public and private fields, properties, constructor

    private PluModel _plu;
    private PluModel Plu { get => _plu; set { _plu = value; SqlLinkedItems = new() { _plu, _bundle }; } }

    private BundleModel _bundle;
    private BundleModel Bundle { get => _bundle; set { _bundle = value; SqlLinkedItems = new() { _plu, _bundle }; } }

    public ItemPluBundleFk() : base()
    {
        _plu = SqlItemNewEmpty<PluModel>();
        _bundle = SqlItemNewEmpty<BundleModel>();
    }

    #endregion

    #region Public and private methods

    protected override void OnParametersSet()
    {
        RunActionsParametersSetJustOne(
            () =>
            {
                SqlItemCast = DataAccess.GetItemNotNullable<PluBundleFkModel>(IdentityUid);
                DataContext.GetListNotNullable<PluModel>(WsSqlCrudConfigUtils.GetCrudConfigComboBox());
                DataContext.GetListNotNullable<BundleModel>(WsSqlCrudConfigUtils.GetCrudConfigComboBox());

                if (SqlItemCast.IsNew)
                {
                    Plu = DataContext.Plus.FirstOrDefault(item => item.IsNew) ?? SqlItemNewEmpty<PluModel>();
                    Bundle = DataContext.Bundles.FirstOrDefault(item => item.IsNew) ?? SqlItemNewEmpty<BundleModel>();
                    SqlItemCast = SqlItemNew<PluBundleFkModel>();
                    SqlItemCast.Plu = Plu;
                    SqlItemCast.Bundle = Bundle;
                }
                else
                {
                    Plu = SqlItemCast.Plu;
                    Bundle = SqlItemCast.Bundle;
                }
            }
        );
    }

    #endregion
}