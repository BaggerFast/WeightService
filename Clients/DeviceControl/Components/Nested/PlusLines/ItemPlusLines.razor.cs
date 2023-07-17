// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using WsStorageCore.Helpers;
using WsStorageCore.Tables.TableScaleModels.PlusScales;

namespace DeviceControl.Components.Nested.PlusLines;

public sealed partial class ItemPlusLines : ItemBase<WsSqlPluScaleModel>
{
    
    private static WsSqlContextCacheHelper ContextCache => WsSqlContextCacheHelper.Instance;
    
    #region Public and private methods

    // TODO: Fix long loading
    protected override void SetSqlItemCast()
    {
        base.SetSqlItemCast();
        // Обновить кэш.
        ContextCache.Load(WsSqlEnumTableName.Plus);
        ContextCache.Load(WsSqlEnumTableName.Lines);
    }

    #endregion
}