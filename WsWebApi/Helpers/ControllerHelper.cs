﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore.Sql.TableScaleModels.PlusCharacteristics;
using DataCore.Sql.TableScaleModels.PlusGroups;
// ReSharper disable InconsistentNaming

namespace WsWebApi.Helpers;

/// <summary>
/// Web API Controller helper.
/// </summary>
public partial class ControllerHelper
{
    #region Design pattern "Lazy Singleton"

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private static ControllerHelper _instance;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public static ControllerHelper Instance => LazyInitializer.EnsureInitialized(ref _instance);

    #endregion

    #region Public and private fields, properties, constructor

    private DataContextModel DataContext { get; } = new();

    #endregion

    #region Public and private methods

    public ContentResult GetContentResult(Func<ContentResult> action, string format,
        [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string memberName = "")
    {
        try
        {
            return action();
        }
        catch (Exception ex)
        {
            filePath = Path.GetFileName(filePath);
            ServiceExceptionModel serviceException = new(filePath, lineNumber, memberName, ex);
            return DataFormatUtils.GetContentResult<ServiceExceptionModel>(serviceException, format, HttpStatusCode.OK);
        }
        finally
        {
            GC.Collect();
        }
    }

    private ContentResult NewResponse1cCore<T>(ISessionFactory sessionFactory, Action<T> action,
        string format, bool isTransaction, HttpStatusCode httpStatusCode = HttpStatusCode.OK) where T : SerializeBase, new()
    {
        T response = new();

        try
        {
            action(response);
        }
        catch (Exception ex)
        {
            httpStatusCode = HttpStatusCode.InternalServerError;
            if (response is Response1cModel response1c)
            {
                response1c.Errors.Add(new(ex));
            }
        }

        return DataFormatUtils.GetContentResult<T>(response, format, httpStatusCode);
    }

    public ContentResult NewResponse1cFromQuery(ISessionFactory sessionFactory, string query,
        SqlParameter? sqlParameter, string format, bool isTransaction)
    {
        return NewResponse1cCore<Response1cModel>(sessionFactory, response =>
        {
            if (!string.IsNullOrEmpty(query))
            {
                if (response.ResponseQuery is not null)
                    response.ResponseQuery.Query = query;
                ISQLQuery sqlQuery = DataContext.Session.CreateSQLQuery(query);
                if (sqlParameter is not null)
                {
                    if (response.ResponseQuery is not null)
                        response.ResponseQuery.Parameters.Add(new(sqlParameter));
                    sqlQuery.SetParameter(sqlParameter.ParameterName, sqlParameter.Value);
                }

                IList? list = sqlQuery.List();
                object?[] result = new object?[list.Count];
                if (list.Count == 1 && list[0] is object[] records)
                {
                    result = records;
                }
                else
                {
                    for (int i = 0; i < result.Length; i++)
                    {
                        if (list[i] is object[] records2)
                            result[i] = records2;
                        else
                            result[i] = list[i];
                    }
                }
                string str = result[^1] as string ?? string.Empty;
                response.Infos.Add(new(str));
            }
            else
                response.Infos.Add(new("Empty query. Try to make some select from any table."));
        }, format, isTransaction);
    }

    /// <summary>
    /// Add error for response.
    /// </summary>
    /// <param name="response"></param>
    /// <param name="uid"></param>
    /// <param name="exceptionMessage"></param>
    /// <param name="innerExceptionMessage"></param>
    private void AddResponse1cException(Response1cShortModel response, Guid uid, string? exceptionMessage, string? innerExceptionMessage)
    {
        Response1cErrorModel responseRecord = new(uid,
            !string.IsNullOrEmpty(innerExceptionMessage) ? innerExceptionMessage : exceptionMessage ?? string.Empty);
        if (response.Errors.Select(item => item.Uid).Contains(uid))
        {
            if (response.Errors.Find(item => Equals(item.Uid, uid)) is { } error)
                error.Message += $" | {responseRecord}";
        }
        else
            response.Errors.Add(responseRecord);

        RemoveResponse1cErrorFromSuccess(response, responseRecord);
    }

    /// <summary>
    /// Remove error from success for resposne.
    /// </summary>
    /// <param name="response"></param>
    /// <param name="responseRecord"></param>
    private static void RemoveResponse1cErrorFromSuccess(Response1cShortModel response, Response1cErrorModel responseRecord)
    {
        bool isFind;
        do
        {
            isFind = false;
            foreach (Response1cSuccessModel success in response.Successes)
            {
                if (Equals(success.Uid, responseRecord.Uid))
                {
                    response.Successes.Remove(success);
                    isFind = true;
                    break;
                }
            }
        } while (isFind);
    }

    private void AddResponse1cException(Response1cShortModel response, BrandModel brand)
    {
        Response1cErrorModel responseRecord = new(brand.IdentityValueUid, brand.ParseResult.Exception ?? string.Empty);
        if (!string.IsNullOrEmpty(brand.ParseResult.InnerException))
            responseRecord.Message += " | " + brand.ParseResult.InnerException;
        if (response.Errors.Select(item => item.Uid).Contains(brand.Uid1c))
        {
            if (response.Errors.Find(item => Equals(item.Uid, brand.Uid1c)) is { } error)
                error.Message += $" | {responseRecord}";
        }
        else
            response.Errors.Add(responseRecord);
    }

    private void AddResponse1cException(Response1cShortModel response, Guid uid, Exception? ex) =>
        AddResponse1cException(response, uid, ex?.Message, ex?.InnerException?.Message);

    private void SetItemPropertyFromXmlAttribute<T>(XmlNode xmlNode, T item, string xmlPropertyName) where T : ISqlTable
    {
        SetItemPropertyFromXmlAttributeForBase(xmlNode, item, xmlPropertyName);
        switch (item)
        {
            case BrandModel brand:
                SetItemPropertyFromXmlAttributeForBrand(xmlNode, brand, xmlPropertyName);
                break;
            case PluModel plu:
                SetItemPropertyFromXmlAttributeForPlu(xmlNode, plu, xmlPropertyName);
                break;
            case PluGroupModel pluGroup:
                SetItemPropertyFromXmlAttributeForPluGroup(xmlNode, pluGroup, xmlPropertyName);
                break;
            case PluCharacteristicModel pluCharacteristic:
                SetItemPropertyFromXmlAttributeForPluCharacteristic(xmlNode, pluCharacteristic, xmlPropertyName);
                break;
        }
    }

    private void SetItemParseResultException<T>(T item, string xmlPropertyName) where T : ISqlTable
    {
        item.ParseResult.Status = ParseStatus.Error;
        item.ParseResult.Exception = string.IsNullOrEmpty(item.ParseResult.Exception)
            ? $"{xmlPropertyName} {LocaleCore.WebService.IsEmpty}!"
            : $"{item.ParseResult.Exception} | {xmlPropertyName} {LocaleCore.WebService.IsEmpty}!";

    }

    private void SetItemPropertyFromXmlAttributeForBase<T>(XmlNode xmlNode, T item, string xmlPropertyName) where T : ISqlTable
    {
        switch (xmlPropertyName.ToUpper())
        {
            case "GUID":
                item.IdentityValueUid = GetXmlAttributeGuid(xmlNode, item, xmlPropertyName);
                break;
            case "ISMARKED":
                item.IsMarked = GetXmlAttributeBool(xmlNode, item, xmlPropertyName);
                break;
            case "NAME":
                item.Name = GetXmlAttributeString(xmlNode, item, xmlPropertyName);
                break;
            case "DESCRIPTION":
                item.Description = GetXmlAttributeString(xmlNode, item, xmlPropertyName);
                break;
        }
    }

    private void SetItemPropertyFromXmlAttributeForBrand(XmlNode xmlNode, BrandModel item, string xmlPropertyName)
    {
        switch (xmlPropertyName.ToUpper())
        {
            case "GUID":
                item.Uid1c = GetXmlAttributeGuid(xmlNode, item, xmlPropertyName);
                break;
            case "CODE":
                item.Code = GetXmlAttributeString(xmlNode, item, xmlPropertyName);
                break;
        }
    }

    private void SetItemPropertyFromXmlAttributeForPlu(XmlNode xmlNode, PluModel item, string xmlPropertyName)
    {
        switch (xmlPropertyName.ToUpper())
        {
            case "GUID":
                item.Uid1c = GetXmlAttributeGuid(xmlNode, item, xmlPropertyName);
                break;
            case "ISGROUP":
                item.IsGroup = GetXmlAttributeBool(xmlNode, item, xmlPropertyName);
                break;
            case "FULLNAME":
                item.FullName = GetXmlAttributeString(xmlNode, item, xmlPropertyName);
                break;
            case "CODE":
                item.Code = GetXmlAttributeString(xmlNode, item, xmlPropertyName);
                break;
            case "MEASUREMENTTYPE":
                item.MeasurementType = GetXmlAttributeString(xmlNode, item, xmlPropertyName);
                item.IsCheckWeight = GetXmlAttributeBool(xmlNode, item, xmlPropertyName, "ШТ", "КГ");
                break;
            case "PLUNUMBER":
                item.Number = GetXmlAttributeShort(xmlNode, item, xmlPropertyName);
                break;
            case "SHELFLIFE":
                item.ShelfLifeDays = GetXmlAttributeByte(xmlNode, item, xmlPropertyName);
                break;
            case "PARENTGROUPGUID":
                item.ParentGuid = GetXmlAttributeGuid(xmlNode, item, xmlPropertyName);
                break;
            case "GROUPGUID":
                item.GroupGuid = GetXmlAttributeGuid(xmlNode, item, xmlPropertyName);
                break;
            case "CATEGORYGUID":
                item.CategoryGuid = GetXmlAttributeGuid(xmlNode, item, xmlPropertyName);
                break;
            case "BRANDGUID":
                item.BrandGuid = GetXmlAttributeGuid(xmlNode, item, xmlPropertyName);
                break;
            case "BOXTYPEGUID":
                item.BoxTypeGuid = GetXmlAttributeGuid(xmlNode, item, xmlPropertyName);
                break;
            case "BOXTYPENAME":
                item.BoxTypeName = GetXmlAttributeString(xmlNode, item, xmlPropertyName);
                break;
            case "BOXTYPEWEIGHT":
                item.BoxTypeWeight = GetXmlAttributeDecimal(xmlNode, item, xmlPropertyName);
                break;
            case "CLIPTYPEGUID":
                item.ClipTypeGuid = GetXmlAttributeGuid(xmlNode, item, xmlPropertyName);
                break;
            case "CLIPTYPENAME":
                item.ClipTypeName = GetXmlAttributeString(xmlNode, item, xmlPropertyName);
                break;
            case "CLIPTYPEWEIGHT":
                item.ClipTypeWeight = GetXmlAttributeDecimal(xmlNode, item, xmlPropertyName);
                break;
            case "PACKAGETYPEGUID":
                item.PackageTypeGuid = GetXmlAttributeGuid(xmlNode, item, xmlPropertyName);
                break;
            case "PACKAGETYPENAME":
                item.PackageTypeName = GetXmlAttributeString(xmlNode, item, xmlPropertyName);
                break;
            case "PACKAGETYPEWEIGHT":
                item.PackageTypeWeight = GetXmlAttributeDecimal(xmlNode, item, xmlPropertyName);
                break;
            case "ATTACHMENTSCOUNT":
                item.AttachmentsCount = GetXmlAttributeShort(xmlNode, item, xmlPropertyName);
                break;
        }
    }

    private void SetItemPropertyFromXmlAttributeForPluGroup(XmlNode xmlNode, PluGroupModel item, string xmlPropertyName)
    {
        switch (xmlPropertyName.ToUpper())
        {
            case "GUID":
                item.Uid1c = GetXmlAttributeGuid(xmlNode, item, xmlPropertyName);
                break;
            case "ISGROUP":
                item.IsGroup = GetXmlAttributeBool(xmlNode, item, xmlPropertyName);
                break;
            case "CODE":
                item.Code = GetXmlAttributeString(xmlNode, item, xmlPropertyName);
                break;
            case "GROUPGUID":
                item.ParentGuid = GetXmlAttributeGuid(xmlNode, item, xmlPropertyName);
                break;
        }
    }

    private void SetItemPropertyFromXmlAttributeForPluCharacteristic(XmlNode xmlNode, PluCharacteristicModel item, string xmlPropertyName)
    {
        switch (xmlPropertyName.ToUpper())
        {
            case "GUID":
                item.Uid1c = GetXmlAttributeGuid(xmlNode, item, xmlPropertyName);
                break;
            case "NOMENCLATUREGUID":
                item.NomenclatureGuid = GetXmlAttributeGuid(xmlNode, item, xmlPropertyName);
                break;
            case "ATTACHMENTSCOUNT":
                item.AttachmentsCount = GetXmlAttributeDecimal(xmlNode, item, xmlPropertyName);
                break;
        }
    }

    private string GetXmlAttributeString<T>(XmlNode? xmlNode, T item, string attributeName) where T : ISqlTable
    {
        if (xmlNode?.Attributes is null) return string.Empty;
        foreach (XmlAttribute? attribute in xmlNode.Attributes)
        {
            if (attribute is not null)
            {
                if (attribute.Name.ToUpper().Equals(attributeName.ToUpper()))
                    return attribute.Value;
            }
        }
        SetItemParseResultException(item, attributeName);
        return string.Empty;
    }

    private bool GetXmlAttributeBool<T>(XmlNode? xmlNode, T item, string xmlPropertyName,
        List<string> valuesFalse, List<string> valuesTrue) where T : ISqlTable
    {
        string value = GetXmlAttributeString(xmlNode, item, xmlPropertyName).ToUpper();
        if (Enumerable.Contains(valuesFalse, value)) return false;
        if (Enumerable.Contains(valuesTrue, value)) return true;
        return default;
    }

    private bool GetXmlAttributeBool<T>(XmlNode? xmlNode, T item, string xmlPropertyName) where T : ISqlTable =>
        GetXmlAttributeBool(xmlNode, item, xmlPropertyName, new List<string> { "0", "FALSE" }, new() { "1", "TRUE" });

    private bool GetXmlAttributeBool<T>(XmlNode? xmlNode, T item, string xmlPropertyName,
        string valueFalse, string valueTrue) where T : ISqlTable =>
        GetXmlAttributeBool(xmlNode, item, xmlPropertyName, new List<string> { valueFalse }, new() { valueTrue });

    private Guid GetXmlAttributeGuid<T>(XmlNode? xmlNode, T item, string xmlPropertyName) where T : ISqlTable =>
        Guid.TryParse(GetXmlAttributeString(xmlNode, item, xmlPropertyName), out Guid uid) ? uid : Guid.Empty;

    private byte GetXmlAttributeByte<T>(XmlNode? xmlNode, T item, string xmlPropertyName) where T : ISqlTable =>
        byte.TryParse(GetXmlAttributeString(xmlNode, item, xmlPropertyName), out byte result) ? result : default;

    public ushort GetXmlAttributeUshort<T>(XmlNode? xmlNode, T item, string xmlPropertyName) where T : ISqlTable =>
        ushort.TryParse(GetXmlAttributeString(xmlNode, item, xmlPropertyName), out ushort result) ? result : default;

    private short GetXmlAttributeShort<T>(XmlNode? xmlNode, T item, string xmlPropertyName) where T : ISqlTable =>
        short.TryParse(GetXmlAttributeString(xmlNode, item, xmlPropertyName), out short result) ? result : default;

    private decimal GetXmlAttributeDecimal<T>(XmlNode? xmlNode, T item, string xmlPropertyName) where T : ISqlTable =>
        decimal.TryParse(GetXmlAttributeString(xmlNode, item, xmlPropertyName), out decimal result) ? result : default;

    private List<T> GetNodesListCore<T>(XElement xml, string nodeIdentity, Action<XmlNode, T> action) where T : ISqlTable, new()
    {
        List<T> itemsXml = new();
        XmlDocument xmlDocument = new();
        xmlDocument.LoadXml(xml.ToString());
        if (xmlDocument.DocumentElement is null) return itemsXml;

        XmlNodeList xmlNodes = xmlDocument.DocumentElement.ChildNodes;
        if (xmlNodes.Count <= 0) return itemsXml;
        foreach (XmlNode xmlNode in xmlNodes)
        {
            T itemXml = new() { ParseResult = { Status = ParseStatus.Success, Exception = string.Empty } };
            if (xmlNode.Name.Equals(nodeIdentity, StringComparison.InvariantCultureIgnoreCase))
            {
                try
                {
                    action(xmlNode, itemXml);
                    // Fix ParseResult.
                    itemXml.ParseResult.Message = string.IsNullOrEmpty(itemXml.ParseResult.Exception) ? "Is success" : itemXml.ParseResult.Exception;
                }
                catch (Exception ex)
                {
                    itemXml.ParseResult.Status = ParseStatus.Error;
                    itemXml.ParseResult.Exception = ex.Message;
                    if (ex.InnerException is not null)
                        itemXml.ParseResult.InnerException = ex.InnerException.Message;
                }
            }
            else
            {
                itemXml.ParseResult.Status = ParseStatus.Error;
                itemXml.ParseResult.Exception = 
                    $"{LocaleCore.WebService.Node} `{nodeIdentity}` {LocaleCore.WebService.With} `{xmlNode.Name}` {LocaleCore.WebService.IsNotIdent}!";
            }
            itemsXml.Add(itemXml);
        }
        return itemsXml;
    }

    public ContentResult NewResponseBarCodes(ISessionFactory sessionFactory, DateTime dtStart, DateTime dtEnd, string format)
    {
        return NewResponse1cCore<ResponseBarCodeListModel>(sessionFactory, response =>
        {
            List<SqlFieldFilterModel> sqlFilters = new()
            {
                new(nameof(BarCodeModel.CreateDt), SqlFieldComparerEnum.MoreOrEqual, dtStart),
                new(nameof(BarCodeModel.CreateDt), SqlFieldComparerEnum.LessOrEqual, dtEnd),
            };
            SqlCrudConfigModel sqlCrudConfig = new(sqlFilters, true, false, false, true);
            List<BarCodeModel> barcodesDb = DataContext.GetListNotNullable<BarCodeModel>(sqlCrudConfig);
            response.ResponseBarCodes = WebResponseUtils.CastBarCodes(barcodesDb);
            response.StartDate = dtStart;
            response.EndDate = dtEnd;
            response.Count = response.ResponseBarCodes.Count;
        }, format, false);
    }

    /// <summary>
    /// New response 1C.
    /// </summary>
    /// <param name="sessionFactory"></param>
    /// <param name="version"></param>
    /// <param name="format"></param>
    /// <returns></returns>
    public ContentResult NewResponse1cIsNotFound(ISessionFactory sessionFactory, string version, string format) =>
        NewResponse1cCore<Response1cModel>(sessionFactory, response =>
        {
            response.Infos.Add(new($"Version {version} {LocaleCore.WebService.IsNotFound}!"));
        }, format, false, HttpStatusCode.NotFound);

    #endregion
}