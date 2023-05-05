// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace WsStorageCore.TableScaleFkModels.PlusStorageMethodsFks;

/// <summary>
/// SQL-помощник табличных записей таблиц PLUS_STORAGE_METHODS, PLUS_STORAGE_METHODS_FK.
/// Клиентский слой доступа к БД.
/// </summary>
public sealed class WsSqlPluStorageMethodFkController
{
    #region Design pattern "Lazy Singleton"

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private static WsSqlPluStorageMethodFkController _instance;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public static WsSqlPluStorageMethodFkController Instance => LazyInitializer.EnsureInitialized(ref _instance);

    #endregion

    #region Public and private fields, properties, constructor

    private static WsSqlAccessManagerHelper AccessManager => WsSqlAccessManagerHelper.Instance;
    private static WsSqlContextListHelper ContextList => WsSqlContextListHelper.Instance;

    #endregion

    #region Public and private methods

    /// <summary>
    /// Force update list PluStorageMethodFks.
    /// </summary>
    /// <param name="sqlCrudConfig"></param>
    /// <param name="pluStorageMethodsFks"></param>
    public List<WsSqlPluStorageMethodFkModel> UpdatePluStorageMethodFks(WsSqlCrudConfigModel sqlCrudConfig) =>
        ContextList.GetListNotNullablePlusStoragesMethodsFks(sqlCrudConfig);

    /// <summary>
    /// Get item PluStorageMethod by Plu.
    /// Use UpdatePluStorageMethodFks for force update.
    /// </summary>
    /// <param name="plu"></param>
    /// <param name="pluStorageMethodsFks"></param>
    /// <returns></returns>
    public WsSqlPluStorageMethodModel GetPluStorageMethod(WsSqlPluModel plu, List<WsSqlPluStorageMethodFkModel> pluStorageMethodsFks)
    {
        WsSqlPluStorageMethodFkModel pluStorageMethodFk = new();
        if (pluStorageMethodsFks.Exists(item => Equals(item.Plu, plu)))
            pluStorageMethodFk = pluStorageMethodsFks.Find(item => Equals(item.Plu, plu));
        return pluStorageMethodFk.Method;
    }

    /// <summary>
    /// Get item PluStorageMethod by Plu.
    /// Use UpdatePluStorageMethodFks for force update.
    /// </summary>
    /// <param name="plu"></param>
    /// <param name="pluStorageMethodsFks"></param>
    /// <returns></returns>
    public WsSqlTemplateResourceModel GetPluStorageResource(WsSqlPluModel plu, List<WsSqlPluStorageMethodFkModel> pluStorageMethodsFks)
    {
        WsSqlPluStorageMethodFkModel pluStorageMethodFk = new();
        if (pluStorageMethodsFks.Exists(item => Equals(item.Plu.Identity, plu.Identity)))
            pluStorageMethodFk = pluStorageMethodsFks.Find(
                item => Equals(item.Plu.Identity, plu.Identity));
        return pluStorageMethodFk.Resource;
    }

    /// <summary>
    /// Get item PluStorageMethodFk by Plu.
    /// Use UpdatePluStorageMethodFks for force update.
    /// </summary>
    /// <param name="plu"></param>
    /// <param name="pluStorageMethodsFks"></param>
    /// <returns></returns>
    public WsSqlPluStorageMethodFkModel GetPluStorageMethodFk(WsSqlPluModel plu, List<WsSqlPluStorageMethodFkModel> pluStorageMethodsFks)
    {
        WsSqlPluStorageMethodFkModel pluStorageMethodFk = new();
        if (pluStorageMethodsFks.Exists(item => Equals(item.Plu, plu)))
            pluStorageMethodFk = pluStorageMethodsFks.Find(item => Equals(item.Plu, plu));
        return pluStorageMethodFk;
    }

    #endregion
}