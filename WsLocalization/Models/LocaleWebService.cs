﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace WsLocalization.Models;

public class LocaleWebService
{
    #region Design pattern "Lazy Singleton"

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private static LocaleWebService _instance;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public static LocaleWebService Instance => LazyInitializer.EnsureInitialized(ref _instance);

    #endregion

    public Lang Lang { get; set; } = Lang.Russian;

    #region Public and private fields, properties, constructor

    public string Dublicate => Lang == Lang.English ? "Dublicate" : "Дубликат";
    public string FieldBrand => Lang == Lang.English ? "Brand" : "Бренд";
    public string FieldBundle => Lang == Lang.English ? "Bundle" : "Пакет";
    public string FieldClip => Lang == Lang.English ? "Clip" : "Клипса";
    public string FieldCode => Lang == Lang.English ? "code" : "код";
    public string FieldGroup => Lang == Lang.English ? "Group" : "Группа";
    public string FieldGroup1Level => Lang == Lang.English ? "Level 1 group" : "Группа 1 уровня";
    public string FieldGuid => Lang == Lang.English ? "GUID" : "ГУИД";
    public string FieldNomenclatureCharacteristic => Lang == Lang.English ? "Nomeclature characteristic" : "Номенклатурная характеристика";
    public string FieldNomenclature => Lang == Lang.English ? "Nomenclature" : "Номенклатура";
    public string FieldNomenclatureGroup => Lang == Lang.English ? "Nomenclature group" : "Номенклатурная группа";
    public string FieldNomenclatureParent => Lang == Lang.English ? "Parent nomenclature" : "Родительская номенклатура";
    public string FieldPluNumber => Lang == Lang.English ? "PLU number" : "Номер ПЛУ";
    public string ForDbRecord => Lang == Lang.English ? "for DB record" : "для записи БД";
    public string IsEmpty => Lang == Lang.English ? "is empty value" : "пустое значение";
    public string IsFound => Lang == Lang.English ? "is found" : "найдено";
    public string IsNotFound => Lang == Lang.English ? "is not found" : "не найдено";
    public string IsNotIdent => Lang == Lang.English ? "is not ident" : "не определено";
    public string IsStatusSuccess => Lang == Lang.English ? "Done successfully" : "Выполнено успешно";
    public string Node => Lang == Lang.English ? "node" : "узел";
    public string With => Lang == Lang.English ? "with" : "с";
    public string XmlItemBrand => "Brand";
    public string XmlItemCharacteristic => "Characteristic";
    public string XmlItemNomenclature => "Nomenclature";
    public string XmlItemNomenclatureGroup => "NomenclatureGroup";

    #endregion
}