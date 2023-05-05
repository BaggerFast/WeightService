// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace WsStorageCore.TableScaleFkModels.PlusBundlesFks;

/// <summary>
/// SQL-помощник табличных записей таблицы PLUS_BUNDLES_FK.
/// Клиентский слой доступа к БД.
/// </summary>
public sealed class WsSqlPluBundleFkController
{
    #region Design pattern "Lazy Singleton"

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private static WsSqlPluBundleFkController _instance;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public static WsSqlPluBundleFkController Instance => LazyInitializer.EnsureInitialized(ref _instance);

    #endregion

    #region Public and private fields, properties, constructor

    private WsSqlAccessItemHelper AccessItem => WsSqlAccessItemHelper.Instance;
    private WsSqlContextListHelper ContextList => WsSqlContextListHelper.Instance;
    private WsSqlContextBundleHelper ContextBundle => WsSqlContextBundleHelper.Instance;
    private WsSqlPluController ContextPlu => WsSqlPluController.Instance;

    #endregion

    #region Public and private methods

    public WsSqlPluBundleFkModel GetNewItem()
    {
        WsSqlPluBundleFkModel item = AccessItem.GetItemNewEmpty<WsSqlPluBundleFkModel>();
        item.Plu = ContextPlu.GetNewItem();
        item.Bundle = ContextBundle.GetNewItem();
        return item;
    }

    public List<WsSqlPluBundleFkModel> GetList() => ContextList.GetListNotNullablePlusBundlesFks(new());

    #endregion
}