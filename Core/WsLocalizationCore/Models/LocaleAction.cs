// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using WsLocalizationCore.Common;

namespace WsLocalizationCore.Models;

public sealed class LocaleAction : WsLocalizationBase
{
    #region Design pattern "Lazy Singleton"

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private static LocaleAction _instance;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public static LocaleAction Instance => LazyInitializer.EnsureInitialized(ref _instance);

    #endregion

    #region Public and private fields, properties, constructor

    public string ActionAccessAllow => Lang == WsEnumLanguage.English ? "Access to actions allowed" : "Доступ к действиям разрешён";
    public string ActionAccessDeny => Lang == WsEnumLanguage.English ? "Access to actions denied" : "Доступ к действиям запрещён";
    public string ActionAccessNone => Lang == WsEnumLanguage.English ? "No access to the actions" : "Доступ к действиям не предусмотрен";
    public string ActionDataControl => Lang == WsEnumLanguage.English ? "Data control" : "Контроль данных";
    public string ActionInfo => Lang == WsEnumLanguage.English ? "Information" : "Информация";
    public string ActionSaveSuccess => Lang == WsEnumLanguage.English ? "Saving was successful" : "Сохранение выполнено успешно";
    public string ActionDataControlField => Lang == WsEnumLanguage.English ? "Need to fill in the field" : "Необходимо заполнить поле";
    public string ActionIsShowMarked => Lang == WsEnumLanguage.English ? "Archive records" : "Архивные записи";
    public string ActionIsSelectTopRowsCount(int count) => Lang == WsEnumLanguage.English ? $"First {count} records" : $"Первые {count} записей";
    public string ActionIsShowActivePlu => Lang == WsEnumLanguage.English ? $"Active plu" : $"Активные плу";
    public string ActionMethod => Lang == WsEnumLanguage.English ? "Method" : "Метод";

    #endregion
}