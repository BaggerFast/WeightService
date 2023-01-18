﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore.Enums;
using DataCore.Sql.TableScaleModels.BarCodes;
using WsStorageCore.Models.Tables.BarCodes;

namespace BlazorDeviceControl.Razors.ItemComponents.Others;

public partial class ItemBarCode : RazorComponentItemBase<BarCodeModel>
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
                SqlItemCast = DataContext.GetItemNotNullable<BarCodeModel>(IdentityUid);
                if (SqlItemCast.IsNew)
                {
                    SqlItemCast = SqlItemNew<BarCodeModel>();
                }

                ButtonSettings = new(false, false, false, false, false, false, true);
            }
        });
    }

    private string GetBarcodeTop(FormatType formatType)
    {
        BarcodeTopModel barcodeTop = new(SqlItemCast.ValueTop, false);
        return DataFormatUtils.GetContent<BarcodeTopModel>(barcodeTop, formatType, true);
    }

    private string GetBarcodeRight(FormatType formatType)
    {
        BarcodeRightModel barcodeRight = new(SqlItemCast.ValueRight);
        return DataFormatUtils.GetContent<BarcodeRightModel>(barcodeRight, formatType, true);
    }

    private string GetBarcodeBottom(FormatType formatType)
    {
        BarcodeBottomModel barcodeBottom = new(SqlItemCast.ValueBottom);
        return DataFormatUtils.GetContent<BarcodeBottomModel>(barcodeBottom, formatType, true);
    }

    #endregion
}