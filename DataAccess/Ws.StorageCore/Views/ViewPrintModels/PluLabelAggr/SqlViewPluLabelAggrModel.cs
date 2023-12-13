using System;

namespace Ws.StorageCore.Views.ViewPrintModels.PluLabelAggr;

[DebuggerDisplay("{ToString()}")]
public sealed record SqlViewPluLabelAggrModel
{
    #region Public and private fields, properties, constructor

    public DateTime CreateDt { get; init; }
    public int TotalCount { get; init; }
    public int WeightCount { get; init; }
    public int WithoutWeightCount{ get; init; }
    
    public SqlViewPluLabelAggrModel(DateTime createDt, int withoutWeightCount, int weightCount, int totalCount)
    {
        CreateDt = createDt;
        WithoutWeightCount = withoutWeightCount;
        WeightCount = weightCount;
        TotalCount = totalCount;
    }

    #endregion

    #region Public and private methods - override

    public override string ToString() => $"{TotalCount} {CreateDt:yyyy-MM-dd}";

    #endregion
}