﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore.Sql.TableDwhModels;
using DataCore.Sql.TableScaleModels;
using DataCore.Sql.DataModels;
using DataCore.Sql.Models;
using FluentNHibernate.Conventions;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using static DataCore.ShareEnums;

namespace DataCore.Sql.Controllers
{
    public class CrudController
    {
        #region Public and private fields and properties

        public DataAccessHelper DataAccess { get; private set; } = DataAccessHelper.Instance;
        public DataConfigurationEntity DataConfig { get; private set; }
        public delegate void ExecCallback(ISession session);

        #endregion

        #region Constructor and destructor

        public CrudController()
        {
            DataConfig = new DataConfigurationEntity();
        }

        #endregion

        #region Public and private methods

        public T[] GetEntitiesWithConfig<T>(string filePath, int lineNumber, string memberName) where T : BaseEntity, new()
        {
            T[]? result = new T[0];
            ExecuteTransaction((session) =>
            {
                if (DataConfig != null)
                {
                    result = DataConfig.OrderAsc
                        ? session.Query<T>()
                        .OrderBy(ent => ent)
                        .Skip(DataConfig.PageNo * DataConfig.PageSize)
                        .Take(DataConfig.PageSize)
                        .ToArray()
                        : session.Query<T>()
                            .OrderByDescending(ent => ent)
                            .Skip(DataConfig.PageNo * DataConfig.PageSize)
                            .Take(DataConfig.PageSize)
                            .ToArray()
                        ;
                }
            }, filePath, lineNumber, memberName);
            return result;
        }

        private ICriteria GetCriteria<T>(ISession session, FieldListEntity? fieldList, FieldOrderEntity? order, int maxResults)
            where T : BaseEntity, new()
        {
            Type type = typeof(T);
            ICriteria criteria = session.CreateCriteria(type);
            if (maxResults > 0)
            {
                criteria.SetMaxResults(maxResults);
            }
            if (fieldList is { Use: true, Fields: { } })
            {
                AbstractCriterion fieldsWhere = Restrictions.AllEq(fieldList.Fields);
                criteria.Add(fieldsWhere);
            }
            if (order != null && order is { Use: true })
            {
                Order fieldOrder = order.Direction == DbOrderDirection.Asc
                    ? Order.Asc(order.Name.ToString()) : Order.Desc(order.Name.ToString());
                criteria.AddOrder(fieldOrder);
            }
            return criteria;
        }

        public void ExecuteTransaction(ExecCallback callback,
            string filePath, int lineNumber, string memberName, bool isException = false)
        {
            using ISession? session = DataAccess.SessionFactory.OpenSession();
            Exception? exception = null;
            if (session != null)
            {
                using ITransaction? transaction = session.BeginTransaction();
                try
                {
                    callback?.Invoke(session);
                    session.Flush();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    exception = ex;
                    //throw;
                }
                finally
                {
                    transaction.Dispose();
                    session.Disconnect();
                    session.Close();
                    session.Dispose();
                }
            }
            if (!isException && exception != null)
            {
                DataAccess.Log.LogError(exception, null, null, filePath, lineNumber, memberName);
            }
        }

        //public string GetSqlStringFieldsSelect(string[] fieldsSelect)
        //{
        //    var result = string.Empty;
        //    foreach (var field in fieldsSelect)
        //    {
        //        result += $"[{field}], ";
        //    }
        //    return result[0..^2];
        //}

        //public string GetSqlStringValuesParams(object[] valuesParams)
        //{
        //    var result = string.Empty;
        //    foreach (var value in valuesParams)
        //    {
        //        result += value switch
        //        {
        //            int _ or decimal _ => $"{value}, ",
        //            _ => $"'{value}', ",
        //        };
        //    }
        //    return result[0..^2];
        //}

        //public ISQLQuery GetSqlQuery<T>(ISession session, string from, string[] fieldsSelect, object[] valuesParams)
        //{
        //    if (string.IsNullOrEmpty(from) || fieldsSelect == null || fieldsSelect.Length == 0 ||
        //        valuesParams == null || valuesParams.Length == 0)
        //        return null;

        //    var sqlQuery = $"select {GetSqlStringFieldsSelect(fieldsSelect)} from {from} ({GetSqlStringValuesParams(valuesParams)})";
        //    var result = session.CreateSQLQuery(sqlQuery).AddEntity(typeof(T));
        //    return result;
        //}

        public ISQLQuery? GetSqlQuery(ISession session, string query)
        {
            if (string.IsNullOrEmpty(query))
                return null;

            return session.CreateSQLQuery(query);
        }

        public T[]? GetEntitiesWithoutReferences<T>(FieldListEntity? fieldList, FieldOrderEntity? order, int maxResults,
            string filePath, int lineNumber, string memberName) where T : BaseEntity, new()
        {
            T[]? result = new T[0];
            ExecuteTransaction((session) =>
            {
                result = GetCriteria<T>(session, fieldList, order, maxResults).List<T>().ToArray();
            }, filePath, lineNumber, memberName);
            return result;
        }

        //public T[] GetEntitiesNative<T>(string[] fieldsSelect, string from, object[] valuesParams,
        //    string filePath, int lineNumber, string memberName) where T : class
        //{
        //    var result = new T[0];
        //    using var session = GetSession();
        //    if (session != null)
        //    {
        //        using var transaction = session.BeginTransaction();
        //        try
        //        {
        //            var query = GetSqlQuery<T>(session, from, fieldsSelect, valuesParams);
        //            query.AddEntity(typeof(TU));
        //            if (items != null)
        //            {
        //                List<T> listEntities = items.List<T>();
        //                result = new T[listEntities.Count];
        //                for (int i = 0; i < result.Length; i++)
        //                {
        //                    result[i] = (T)listEntities[i];
        //                }
        //            }

        //            session.Flush();
        //            transaction.Commit();
        //        }
        //        catch (Exception ex)
        //        {
        //            transaction.Rollback();
        //            LogException(ex, filePath, lineNumber, memberName);
        //            throw;
        //        }
        //        finally
        //        {
        //            session.Disconnect();
        //        }
        //    }
        //    return result;
        //}

        #endregion

        #region Public and private methods

        public void FillReferences<T>(T? item) where T : BaseEntity, new()
        {
            FillReferencesSystem(item);
            FillReferencesDatas(item);
            FillReferencesScales(item);
            FillReferencesDwh(item);
        }

        private void FillReferencesSystem<T>(T? item) where T : BaseEntity, new()
        {
            if (item == null) return;
            switch (item)
            {
                case AccessEntity access:
                    if (!access.EqualsEmpty())
                    {
                        //
                    }
                    break;
                case AppEntity app:
                    if (!app.EqualsEmpty())
                    {
                        //
                    }
                    break;
                case ErrorEntity error:
                    if (!error.EqualsEmpty())
                    {
                        //
                    }
                    break;
                case HostEntity host:
                    if (!host.EqualsEmpty())
                    {
                        //
                    }
                    break;
                case LogEntity log:
                    if (!log.EqualsEmpty())
                    {
                        log.App = log.App?.IdentityUid == null ? new() : GetEntity<AppEntity>(log.App.IdentityUid);
                        log.Host = log.Host?.IdentityId == null ? new() : GetEntity<HostEntity>(log.Host.IdentityId);
                        log.LogType = log.LogType?.IdentityUid == null ? new() : GetEntity<LogTypeEntity>(log.LogType.IdentityUid);
                    }
                    break;
                case LogTypeEntity logType:
                    if (!logType.EqualsEmpty())
                    {
                        //
                    }
                    break;
            }
        }

        private void FillReferencesDatas<T>(T? item) where T : BaseEntity, new()
        {
            if (item == null) return;
            switch (item)
            {
                case DeviceEntity device:
                    if (!device.EqualsEmpty())
                    {
                        device.Scales = device.Scales?.IdentityId == null ? new() : GetEntity<ScaleEntity>(device.Scales.IdentityId);
                    }
                    break;
            }
        }

        private void FillReferencesScales<T>(T? item) where T : BaseEntity, new()
        {
            if (item == null) return;
            switch (item)
            {
                case BarCodeEntityV2 barcode:
                    {
                        if (!barcode.EqualsEmpty())
                        {
                            barcode.BarcodeType = barcode.BarcodeType?.IdentityUid == null ? null : GetEntity<BarCodeTypeEntityV2>(barcode.BarcodeType.IdentityUid);
                            barcode.Contragent = barcode.Contragent?.IdentityUid == null ? null : GetEntity<ContragentEntityV2>(barcode.Contragent.IdentityUid);
                            barcode.Nomenclature = barcode.Nomenclature?.IdentityId == null ? null : GetEntity<TableScaleModels.NomenclatureEntity>(barcode.Nomenclature.IdentityId);
                        }
                        break;
                    }
                case BarCodeTypeEntityV2 barcodeType:
                    {
                        if (!barcodeType.EqualsEmpty())
                        {
                            //
                        }
                        break;
                    }
                case ContragentEntityV2 contragent:
                    {
                        if (!contragent.EqualsEmpty())
                        {
                            //
                        }
                        break;
                    }
                case LabelEntity label:
                    if (!label.EqualsEmpty())
                    {
                        label.WeithingFact = GetEntity<WeithingFactEntity>(label.WeithingFact.IdentityId);
                    }
                    break;
                case TableScaleModels.NomenclatureEntity nomenclature:
                    if (!nomenclature.EqualsEmpty())
                    {
                        //
                    }
                    break;
                case OrderEntity order:
                    if (!order.EqualsEmpty())
                    {
                        order.OrderTypes = GetEntity<OrderTypeEntity>(order.OrderTypes.IdentityId);
                        order.Scales = GetEntity<ScaleEntity>(order.Scales.IdentityId);
                        //order.Plu = order.Plu?.IdentityId == null ? new() : GetEntity<PluEntity>(order.Plu.IdentityId);
                        order.Plu = GetEntity<PluEntity>(
                            new FieldListEntity(new Dictionary<DbField, object?> { { DbField.Plu, (int)order.Plu.IdentityId } }));
                        order.Templates = GetEntity<TemplateEntity>(order.Templates.IdentityId);
                    }
                    break;
                case OrderStatusEntity orderStatus:
                    if (!orderStatus.EqualsEmpty())
                    {
                        //
                    }
                    break;
                case OrderTypeEntity orderType:
                    if (!orderType.EqualsEmpty())
                    {
                        //
                    }
                    break;
                case OrganizationEntity organization:
                    if (!organization.EqualsEmpty())
                    {
                        //
                    }
                    break;
                case PluEntity plu:
                    if (!plu.EqualsEmpty())
                    {
                        plu.Template = GetEntity<TemplateEntity>(plu.Template.IdentityId);
                        plu.Scale = GetEntity<ScaleEntity>(plu.Scale.IdentityId);
                        plu.Nomenclature = GetEntity<TableScaleModels.NomenclatureEntity>(plu.Nomenclature.IdentityId);
                    }
                    break;
                case PrinterEntity printer:
                    if (!printer.EqualsEmpty())
                    {
                        printer.PrinterType = GetEntity<PrinterTypeEntity>(printer.PrinterType.IdentityId);
                    }
                    break;
                case PrinterResourceEntity printerResource:
                    if (!printerResource.EqualsEmpty())
                    {
                        printerResource.Printer = GetEntity<PrinterEntity>(printerResource.Printer.IdentityId);
                        printerResource.Resource = GetEntity<TemplateResourceEntity>(printerResource.Resource.IdentityId);
                        if (string.IsNullOrEmpty(printerResource.Resource.Description))
                            printerResource.Resource.Description = printerResource.Resource.Name;
                    }
                    break;
                case PrinterTypeEntity printerType:
                    if (!printerType.EqualsEmpty())
                    {
                        //
                    }
                    break;
                case ProductionFacilityEntity ProductionFacility:
                    if (!ProductionFacility.EqualsEmpty())
                    {
                        //
                    }
                    break;
                case ProductSeriesEntity product:
                    if (!product.EqualsEmpty())
                    {
                        product.Scale = GetEntity<ScaleEntity>(product.Scale.IdentityId);
                    }
                    break;
                case ScaleEntity scale:
                    if (!scale.EqualsEmpty())
                    {
                        scale.TemplateDefault = scale.TemplateDefault?.IdentityId == null ? null : GetEntity<TemplateEntity>(scale.TemplateDefault.IdentityId);
                        scale.TemplateSeries = scale.TemplateSeries?.IdentityId == null ? null : GetEntity<TemplateEntity>(scale.TemplateSeries.IdentityId);
                        scale.WorkShop = GetEntity<WorkShopEntity>(scale.WorkShop.IdentityId);
                        scale.PrinterMain = scale.PrinterMain?.IdentityId == null ? null : GetEntity<PrinterEntity>(scale.PrinterMain.IdentityId);
                        scale.PrinterShipping = scale.PrinterShipping?.IdentityId == null ? null : GetEntity<PrinterEntity>(scale.PrinterShipping.IdentityId);
                        scale.Host = scale.Host?.IdentityId == null ? null : GetEntity<HostEntity>(scale.Host.IdentityId);
                    }
                    break;
                case TaskEntity task:
                    if (!task.EqualsEmpty())
                    {
                        task.TaskType = GetEntity<TaskTypeEntity>(task.TaskType.IdentityUid);
                        task.Scale = GetEntity<ScaleEntity>(task.Scale.IdentityId);
                    }
                    break;
                case TaskTypeEntity taskType:
                    if (!taskType.EqualsEmpty())
                    {
                        //
                    }
                    break;
                case TemplateEntity template:
                    if (!template.EqualsEmpty())
                    {
                        //
                    }
                    break;
                case TemplateResourceEntity templateResource:
                    if (!templateResource.EqualsEmpty())
                    {
                        //
                    }
                    break;
                case WeithingFactEntity weithingFact:
                    if (!weithingFact.EqualsEmpty())
                    {
                        weithingFact.Plu = GetEntity<PluEntity>(
                            new FieldListEntity(new Dictionary<DbField, object?> { { DbField.IdentityId, (long)weithingFact.Plu.IdentityId } }));
                        weithingFact.Scale = GetEntity<ScaleEntity>(weithingFact.Scale.IdentityId);
                        weithingFact.Serie = weithingFact.Serie?.IdentityId == null ? null : GetEntity<ProductSeriesEntity>(weithingFact.Serie.IdentityId);
                        weithingFact.Order = weithingFact.Order?.IdentityId == null ? null : GetEntity<OrderEntity>(weithingFact.Order.IdentityId);
                    }
                    break;
                case WorkShopEntity workshop:
                    if (!workshop.EqualsEmpty())
                    {
                        workshop.ProductionFacility = GetEntity<ProductionFacilityEntity>(workshop.ProductionFacility.IdentityId);
                    }
                    break;
            }
        }

        private void FillReferencesDwh<T>(T? item) where T : BaseEntity, new()
        {
            if (item == null) return;
            switch (item)
            {
                case BrandEntity brand:
                    if (!brand.EqualsEmpty())
                    {
                        brand.InformationSystem = brand.InformationSystem?.IdentityId == null ? new() : GetEntity<InformationSystemEntity>(brand.InformationSystem.IdentityId);
                    }
                    break;
                case InformationSystemEntity informationSystem:
                    if (!informationSystem.EqualsEmpty())
                    {
                        //
                    }
                    break;
                case TableDwhModels.NomenclatureEntity nomenclature:
                    if (!nomenclature.EqualsEmpty())
                    {
                        //if (nomenclatureEntity.BrandBytes != null && nomenclatureEntity.BrandBytes.Length > 0)
                        //    nomenclatureEntity.Brand = GetEntity(DbField.CodeInIs, nomenclatureEntity.BrandBytes);
                        //if (nomenclatureEntity.InformationSystem?.IdentityId != null)
                        //    nomenclatureEntity.InformationSystem = GetEntity(nomenclatureEntity.InformationSystem.Id);
                        //if (nomenclatureEntity.NomenclatureGroupCostBytes != null && nomenclatureEntity.NomenclatureGroupCostBytes.Length > 0)
                        //    nomenclatureEntity.NomenclatureGroupCost = GetEntity(DbField.CodeInIs, nomenclatureEntity.NomenclatureGroupCostBytes);
                        //if (nomenclatureEntity.NomenclatureGroupBytes != null && nomenclatureEntity.NomenclatureGroupBytes.Length > 0)
                        //    nomenclatureEntity.NomenclatureGroup = GetEntity(DbField.CodeInIs, nomenclatureEntity.NomenclatureGroupBytes);
                        //if (nomenclatureEntity.NomenclatureTypeBytes != null && nomenclatureEntity.NomenclatureTypeBytes.Length > 0)
                        //    nomenclatureEntity.NomenclatureType = GetEntity(DbField.CodeInIs, nomenclatureEntity.NomenclatureTypeBytes);
                        nomenclature.Status = nomenclature.Status?.IdentityId == null ? new() : GetEntity<StatusEntity>(nomenclature.Status.IdentityId);
                    }
                    break;
                case NomenclatureGroupEntity nomenclatureGroup:
                    if (!nomenclatureGroup.EqualsEmpty())
                    {
                        nomenclatureGroup.InformationSystem = nomenclatureGroup.InformationSystem?.IdentityId == null ? new() : GetEntity<InformationSystemEntity>(nomenclatureGroup.InformationSystem.IdentityId);
                    }
                    break;
                case NomenclatureLightEntity nomenclatureLight:
                    if (!nomenclatureLight.EqualsEmpty())
                    {
                        nomenclatureLight.InformationSystem = nomenclatureLight.InformationSystem?.IdentityId == null ? new() : GetEntity<InformationSystemEntity>(nomenclatureLight.InformationSystem.IdentityId);
                    }
                    break;
                case NomenclatureParentEntity:
                    //
                    break;
                case NomenclatureTypeEntity nomenclatureType:
                    if (!nomenclatureType.EqualsEmpty())
                    {
                        nomenclatureType.InformationSystem = nomenclatureType.InformationSystem?.IdentityId == null ? new() : GetEntity<InformationSystemEntity>(nomenclatureType.InformationSystem.IdentityId);
                    }
                    break;
                case StatusEntity status:
                    if (!status.EqualsEmpty())
                    {
                        //
                    }
                    break;
            }
        }

        public T GetEntity<T>(FieldListEntity? fieldList, FieldOrderEntity? order = null,
            [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string memberName = "")
            where T : BaseEntity, new()
        {
            T? item = new();
            ExecuteTransaction((session) =>
            {
                ICriteria criteria = GetCriteria<T>(session, fieldList, order, 1);
                IList<T>? list = criteria?.List<T>();
                item = list == null ? new T() : list.FirstOrDefault() ?? new T();
            }, filePath, lineNumber, memberName);
            FillReferences(item);
            return item;
        }

        public T GetEntity<T>(long? id) where T : BaseEntity, new()
        {
            return GetEntity<T>(
                new FieldListEntity(new Dictionary<string, object?> { { DbField.IdentityId.ToString(), id } }),
                new FieldOrderEntity(DbField.IdentityId, DbOrderDirection.Desc));
        }

        public T GetEntity<T>(Guid? uid) where T : BaseEntity, new()
        {
            return GetEntity<T>(
                new FieldListEntity(new Dictionary<string, object?> { { DbField.IdentityUid.ToString(), uid } }),
                new FieldOrderEntity(DbField.IdentityUid, DbOrderDirection.Desc));
        }

        public T[]? GetEntities<T>(FieldListEntity? fieldList, FieldOrderEntity? order, int maxResults = 0,
            [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string memberName = "")
            where T : BaseEntity, new()
        {
            T[]? items = GetEntitiesWithoutReferences<T>(fieldList, order, maxResults, filePath, lineNumber, memberName);
            if (items != null)
            {
                foreach (T? item in items)
                {
                    FillReferences(item);
                }
            }
            return items;
        }

        //public T[] GetEntitiesNative(string[] fieldsSelect, string from, object[] valuesParams,
        //    [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string memberName = "")
        //{
        //    return DataAccess.GetEntitiesNative<T>(fieldsSelect, from, valuesParams, filePath, lineNumber, memberName);
        //}

        public T[] GetEntitiesNativeMappingInside<T>(string query, string filePath, int lineNumber, string memberName) where T : BaseEntity, new()
        {
            T[]? result = new T[0];
            ExecuteTransaction((session) =>
            {
                ISQLQuery? sqlQuery = GetSqlQuery(session, query);
                if (sqlQuery != null)
                {
                    sqlQuery.AddEntity(typeof(T));
                    System.Collections.IList? listEntities = sqlQuery.List();
                    result = new T[listEntities.Count];
                    for (int i = 0; i < result.Length; i++)
                    {
                        result[i] = (T)listEntities[i];
                    }
                }
            }, filePath, lineNumber, memberName);
            return result;
        }

        public T[] GetEntitiesNativeMapping<T>(string query,
            [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string memberName = "")
            where T : BaseEntity, new()
            => GetEntitiesNativeMappingInside<T>(query, filePath, lineNumber, memberName);

        public object[] GetEntitiesNativeObject(string query,
            [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string memberName = "")
        {
            object[]? result = new object[0];
            ExecuteTransaction((session) =>
            {
                ISQLQuery? sqlQuery = GetSqlQuery(session, query);
                if (sqlQuery != null)
                {
                    System.Collections.IList? listEntities = sqlQuery.List();
                    result = new object[listEntities.Count];
                    for (int i = 0; i < result.Length; i++)
                    {
                        if (listEntities[i] is object[] records)
                            result[i] = records;
                        else
                            result[i] = listEntities[i];
                    }
                }
            }, filePath, lineNumber, memberName);
            return result;
        }

        public int ExecQueryNativeInside(string query, Dictionary<string, object> parameters, string filePath, int lineNumber, string memberName)
        {
            int result = 0;
            ExecuteTransaction((session) =>
            {
                ISQLQuery? sqlQuery = GetSqlQuery(session, query);
                if (sqlQuery != null && parameters != null)
                {
                    foreach (KeyValuePair<string, object> parameter in parameters)
                    {
                        if (parameter.Value is byte[] imagedata)
                            sqlQuery.SetParameter(parameter.Key, imagedata);
                        else
                            sqlQuery.SetParameter(parameter.Key, parameter.Value);
                    }
                    result = sqlQuery.ExecuteUpdate();
                }
            }, filePath, lineNumber, memberName);
            return result;
        }

        public int ExecQueryNative(string query, Dictionary<string, object> parameters,
            [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string memberName = "")
            => ExecQueryNativeInside(query, parameters, filePath, lineNumber, memberName);

        public void SaveEntity<T>(T? item,
            [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string memberName = "")
            where T : BaseEntity, new()
        {
            switch (item)
            {
                case ContragentEntityV2 contragent:
                    throw new Exception($"{nameof(SaveEntity)} for {nameof(ContragentEntityV2)} is deny!");
                case TableScaleModels.NomenclatureEntity nomenclature:
                    throw new Exception($"{nameof(SaveEntity)} for {nameof(TableScaleModels.NomenclatureEntity)} is deny!");
                default:
                    ExecuteTransaction((session) => { session.Save(item); }, filePath, lineNumber, memberName);
                    break;
            }
        }

        public void UpdateEntity<T>(T? item,
            [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string memberName = "")
            where T : BaseEntity, new()
        {
            if (item == null || item.EqualsEmpty()) return;
            item.ChangeDt = DateTime.Now;
            ExecuteTransaction((session) => { session.SaveOrUpdate(item); }, filePath, lineNumber, memberName);
        }

        public void DeleteEntity<T>(T? item,
            [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string memberName = "")
            where T : BaseEntity
        {
            if (item == null || item.EqualsEmpty()) return;
            ExecuteTransaction((session) => { session.Delete(item); }, filePath, lineNumber, memberName);
        }

        public void MarkedEntity<T>(T? item,
            [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string memberName = "")
            where T : BaseEntity
        {
            if (item == null || item.EqualsEmpty()) return;
            switch (item)
            {
                case AccessEntity access:
                    ExecuteTransaction((session) => { session.SaveOrUpdate(access); }, filePath, lineNumber, memberName);
                    break;
                case AppEntity app:
                    ExecuteTransaction((session) => { session.SaveOrUpdate(app); }, filePath, lineNumber, memberName);
                    break;
                case ErrorEntity error:
                    ExecuteTransaction((session) => { session.SaveOrUpdate(error); }, filePath, lineNumber, memberName);
                    break;
                case HostEntity host:
                    host.IsMarked = true;
                    ExecuteTransaction((session) => { session.SaveOrUpdate(host); }, filePath, lineNumber, memberName);
                    break;
                case LogEntity log:
                    ExecuteTransaction((session) => { session.SaveOrUpdate(log); }, filePath, lineNumber, memberName);
                    break;
                case LogTypeEntity logType:
                    ExecuteTransaction((session) => { session.SaveOrUpdate(logType); }, filePath, lineNumber, memberName);
                    break;
                case BarCodeTypeEntityV2 barcodeType:
                    ExecuteTransaction((session) => { session.SaveOrUpdate(barcodeType); }, filePath, lineNumber, memberName);
                    break;
                case ContragentEntityV2 contragent:
                    contragent.IsMarked = true;
                    ExecuteTransaction((session) => { session.SaveOrUpdate(contragent); }, filePath, lineNumber, memberName);
                    break;
                case LabelEntity label:
                    ExecuteTransaction((session) => { session.SaveOrUpdate(label); }, filePath, lineNumber, memberName);
                    break;
                case OrderEntity order:
                    ExecuteTransaction((session) => { session.SaveOrUpdate(order); }, filePath, lineNumber, memberName);
                    break;
                case OrderStatusEntity orderStatus:
                    ExecuteTransaction((session) => { session.SaveOrUpdate(orderStatus); }, filePath, lineNumber, memberName);
                    break;
                case OrderTypeEntity orderType:
                    ExecuteTransaction((session) => { session.SaveOrUpdate(orderType); }, filePath, lineNumber, memberName);
                    break;
                case PluEntity plu:
                    plu.IsMarked = true;
                    ExecuteTransaction((session) => { session.SaveOrUpdate(plu); }, filePath, lineNumber, memberName);
                    break;
                case ProductionFacilityEntity productionFacility:
                    productionFacility.IsMarked = true;
                    ExecuteTransaction((session) => { session.SaveOrUpdate(productionFacility); }, filePath, lineNumber, memberName);
                    break;
                case ProductSeriesEntity productSeries:
                    ExecuteTransaction((session) => { session.SaveOrUpdate(productSeries); }, filePath, lineNumber, memberName);
                    break;
                case ScaleEntity scale:
                    scale.IsMarked = true;
                    ExecuteTransaction((session) => { session.SaveOrUpdate(scale); }, filePath, lineNumber, memberName);
                    break;
                case TemplateResourceEntity templateResource:
                    templateResource.IsMarked = true;
                    ExecuteTransaction((session) => { session.SaveOrUpdate(templateResource); }, filePath, lineNumber, memberName);
                    break;
                case TemplateEntity template:
                    template.IsMarked = true;
                    ExecuteTransaction((session) => { session.SaveOrUpdate(template); }, filePath, lineNumber, memberName);
                    break;
                case WeithingFactEntity weithingFact:
                    ExecuteTransaction((session) => { session.SaveOrUpdate(weithingFact); }, filePath, lineNumber, memberName);
                    break;
                case WorkShopEntity workshop:
                    workshop.IsMarked = true;
                    ExecuteTransaction((session) => { session.SaveOrUpdate(workshop); }, filePath, lineNumber, memberName);
                    break;
                case PrinterEntity printer:
                    printer.IsMarked = true;
                    ExecuteTransaction((session) => { session.SaveOrUpdate(printer); }, filePath, lineNumber, memberName);
                    break;
                case PrinterResourceEntity printerResource:
                    ExecuteTransaction((session) => { session.SaveOrUpdate(printerResource); }, filePath, lineNumber, memberName);
                    break;
                case PrinterTypeEntity printerType:
                    ExecuteTransaction((session) => { session.SaveOrUpdate(printerType); }, filePath, lineNumber, memberName);
                    break;
                case BrandEntity brand:
                    ExecuteTransaction((session) => { session.SaveOrUpdate(brand); }, filePath, lineNumber, memberName);
                    break;
                case InformationSystemEntity informationSystem:
                    ExecuteTransaction((session) => { session.SaveOrUpdate(informationSystem); }, filePath, lineNumber, memberName);
                    break;
                case TableDwhModels.NomenclatureEntity nomenclature:
                    ExecuteTransaction((session) => { session.SaveOrUpdate(nomenclature); }, filePath, lineNumber, memberName);
                    break;
                case NomenclatureGroupEntity nomenclatureGroup:
                    ExecuteTransaction((session) => { session.SaveOrUpdate(nomenclatureGroup); }, filePath, lineNumber, memberName);
                    break;
                case NomenclatureLightEntity nomenclatureLight:
                    ExecuteTransaction((session) => { session.SaveOrUpdate(nomenclatureLight); }, filePath, lineNumber, memberName);
                    break;
                case NomenclatureTypeEntity nomenclatureType:
                    ExecuteTransaction((session) => { session.SaveOrUpdate(nomenclatureType); }, filePath, lineNumber, memberName);
                    break;
                case StatusEntity status:
                    ExecuteTransaction((session) => { session.SaveOrUpdate(status); }, filePath, lineNumber, memberName);
                    break;
                default:
                    ExecuteTransaction((session) => { session.SaveOrUpdate(item); }, filePath, lineNumber, memberName);
                    break;
            }
        }

        public bool ExistsEntityInside<T>(T? item, string filePath, int lineNumber, string memberName) where T : BaseEntity, new()
        {
            if (item == null || item.EqualsEmpty()) return false;
            bool result = false;
            ExecuteTransaction((session) =>
            {
                result = session.Query<T>().Any(x => x.IsAny(item));
            }, filePath, lineNumber, memberName);
            return result;
        }

        public bool ExistsEntity<T>(T? item,
            [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string memberName = "")
            where T : BaseEntity, new()
        {
            if (item == null || item.EqualsEmpty()) return false;
            return ExistsEntityInside(item, filePath, lineNumber, memberName);
        }

        public bool ExistsEntityInside<T>(FieldListEntity fieldList, FieldOrderEntity? order,
            string filePath, int lineNumber, string memberName) where T : BaseEntity, new()
        {
            bool result = false;
            ExecuteTransaction((session) =>
            {
                result = GetCriteria<T>(session, fieldList, order, 1).List<T>().Count > 0;
            }, filePath, lineNumber, memberName);
            return result;
        }

        public bool ExistsEntity<T>(FieldListEntity fieldList, FieldOrderEntity? order,
            [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string memberName = "")
            where T : BaseEntity, new()
        {
            //return DataAccess.ExistsEntity<T>(fieldList, order, filePath, lineNumber, memberName);
            return ExistsEntityInside<T>(fieldList, order, filePath, lineNumber, memberName);
        }

        #endregion
    }
}