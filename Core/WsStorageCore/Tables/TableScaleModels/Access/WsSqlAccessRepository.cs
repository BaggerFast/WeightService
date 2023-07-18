// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace WsStorageCore.Tables.TableScaleModels.Access;

/// <summary>
/// SQL-контроллер таблицы ACCESS.
/// Клиентский слой доступа к БД.
/// </summary>
public sealed class WsSqlAccessRepository : WsSqlTableRepositoryBase<WsSqlAccessModel>
{
    #region Design pattern "Lazy Singleton"

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private static WsSqlAccessRepository _instance;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public static WsSqlAccessRepository Instance => LazyInitializer.EnsureInitialized(ref _instance);

    #endregion

    #region Public and private methods

    public WsSqlAccessModel GetNewItem() => SqlCore.GetItemNewEmpty<WsSqlAccessModel>();

    public WsSqlAccessModel GetItem(Guid uid) => SqlCore.GetItemNotNullable<WsSqlAccessModel>(uid);

    public List<WsSqlAccessModel> GetList() => ContextList.GetListNotNullableAccesses(SqlCrudConfig);

    public List<WsSqlAccessModel> GetList(WsSqlEnumIsMarked isMarked) =>
        ContextList.GetListNotNullableAccesses(new() { IsMarked = isMarked, IsResultOrder = true });

    #endregion
}