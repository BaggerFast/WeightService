// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using WsStorageCore.Helpers;
using WsStorageCore.TableScaleFkModels.Aggregations;

namespace DeviceControl.Pages.Menu.Operations.PlusWeightingsAggr;

public sealed partial class PluWeightingsAggr : LayoutComponentBase
{
    #region Public and private fields, properties, constructor

    private bool IsShowPlu { get; set; }

    private string SqlListCountResult =>
        $"{LocaleCore.Strings.ItemsCount}: {PluWeightAggrs.Count:### ### ###}";

    private List<WsSqlPluAggrModel> PluWeightAggrs { get; set; }

    public PluWeightingsAggr()
    {
        PluWeightAggrs = new();
    }

    #endregion

    #region Public and private methods

    protected override void OnAfterRender(bool firstRender)
    {
        if (!firstRender)
        {
            base.OnAfterRender(firstRender);
            return;
        }

        GetSectionData();
    }

    private void GetSectionData()
    {
        PluWeightAggrs = new();
        object[] sql_objects =
            WsSqlContextManagerHelper.Instance.AccessManager.AccessList.GetArrayObjectsNotNullable(
                WsSqlQueriesScales.Tables.PluWeighings.GetWeighingsAggr(200)
            );
        foreach (object obj in sql_objects)
        {
            if (obj is object[] { Length: 4 } item)
            {
                PluWeightAggrs.Add(new(
                    Convert.ToDateTime(item[0]),
                    Convert.ToInt32(item[1]),
                    Convert.ToString(item[2]) ?? string.Empty,
                    Convert.ToString(item[3]) ?? string.Empty)
                );
            }
        }

        StateHasChanged();
    }

    #endregion
}