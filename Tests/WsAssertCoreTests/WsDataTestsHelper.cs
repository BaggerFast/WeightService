// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace WsAssertCoreTests;

public class WsDataTestsHelper
{
    #region Design pattern "Lazy Singleton"

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private static WsDataTestsHelper _instance;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public static WsDataTestsHelper Instance => LazyInitializer.EnsureInitialized(ref _instance);

    #endregion

    #region Public and private fields, properties, constructor

    public WsSqlContextCacheHelper ContextCache => WsSqlContextCacheHelper.Instance;
    public WsSqlContextManagerHelper ContextManager => WsSqlContextManagerHelper.Instance;
    private WsJsonSettingsHelper JsonSettings => WsJsonSettingsHelper.Instance;

    #endregion

    #region Public and private methods

    public void SetupDevelopAleksandrov(bool isShowSql)
    {
        ContextManager.SetupJsonTestsDevelopAleksandrov(Directory.GetCurrentDirectory(),
            MdNetUtils.GetLocalDeviceName(true), nameof(WsAssertCoreTests), isShowSql);
        TestContext.WriteLine($"{nameof(JsonSettings.IsRemote)}: {JsonSettings.IsRemote}");
        TestContext.WriteLine(JsonSettings.IsRemote ? JsonSettings.Remote : JsonSettings.Local);
    }

    public void SetupDevelopMorozov(bool isShowSql)
    {
        ContextManager.SetupJsonTestsDevelopMorozov(Directory.GetCurrentDirectory(),
            MdNetUtils.GetLocalDeviceName(true), nameof(WsAssertCoreTests), isShowSql);
        TestContext.WriteLine($"{nameof(JsonSettings.IsRemote)}: {JsonSettings.IsRemote}");
        TestContext.WriteLine(JsonSettings.IsRemote ? JsonSettings.Remote : JsonSettings.Local);
    }

    public void SetupDevelopVs(bool isShowSql)
    {
        ContextManager.SetupJsonTestsDevelopVs(Directory.GetCurrentDirectory(),
            MdNetUtils.GetLocalDeviceName(true), nameof(WsAssertCoreTests), isShowSql);
        TestContext.WriteLine($"{nameof(JsonSettings.IsRemote)}: {JsonSettings.IsRemote}");
        TestContext.WriteLine(JsonSettings.IsRemote ? JsonSettings.Remote : JsonSettings.Local);
    }

    private void SetupReleaseAleksandrov(bool isShowSql)
    {
        ContextManager.SetupJsonTestsReleaseAleksandrov(Directory.GetCurrentDirectory(),
            MdNetUtils.GetLocalDeviceName(true), nameof(WsAssertCoreTests), isShowSql);
        TestContext.WriteLine($"{nameof(JsonSettings.IsRemote)}: {JsonSettings.IsRemote}");
        TestContext.WriteLine(JsonSettings.IsRemote ? JsonSettings.Remote : JsonSettings.Local);
    }

    private void SetupReleaseMorozov(bool isShowSql)
    {
        ContextManager.SetupJsonTestsReleaseMorozov(Directory.GetCurrentDirectory(),
            MdNetUtils.GetLocalDeviceName(true), nameof(WsAssertCoreTests), isShowSql);
        TestContext.WriteLine($"{nameof(JsonSettings.IsRemote)}: {JsonSettings.IsRemote}");
        TestContext.WriteLine(JsonSettings.IsRemote ? JsonSettings.Remote : JsonSettings.Local);
    }

    private void SetupReleaseVs(bool isShowSql)
    {
        ContextManager.SetupJsonTestsReleaseVs(Directory.GetCurrentDirectory(),
            MdNetUtils.GetLocalDeviceName(true), nameof(WsAssertCoreTests), isShowSql);
        TestContext.WriteLine($"{nameof(JsonSettings.IsRemote)}: {JsonSettings.IsRemote}");
        TestContext.WriteLine(JsonSettings.IsRemote ? JsonSettings.Remote : JsonSettings.Local);
    }

    public void AssertAction(Action action, bool isShowSql, List<WsEnumConfiguration> publishTypes)
    {
        Assert.DoesNotThrow(() =>
        {
            if (publishTypes.Contains(WsEnumConfiguration.DevelopAleksandrov))
            {
                SetupDevelopAleksandrov(isShowSql);
                action();
                TestContext.WriteLine();
            }
            if (publishTypes.Contains(WsEnumConfiguration.DevelopMorozov))
            {
                SetupDevelopMorozov(isShowSql);
                action();
                TestContext.WriteLine();
            }
            if (publishTypes.Contains(WsEnumConfiguration.DevelopVS))
            {
                SetupDevelopVs(isShowSql);
                action();
                TestContext.WriteLine();
            }
            if (publishTypes.Contains(WsEnumConfiguration.ReleaseAleksandrov))
            {
                SetupReleaseAleksandrov(isShowSql);
                action();
                TestContext.WriteLine();
            }
            if (publishTypes.Contains(WsEnumConfiguration.ReleaseMorozov))
            {
                SetupReleaseMorozov(isShowSql);
                action();
                TestContext.WriteLine();
            }
            if (publishTypes.Contains(WsEnumConfiguration.ReleaseVS))
            {
                SetupReleaseVs(isShowSql);
                action();
                TestContext.WriteLine();
            }
        });
    }

    public void FailureWriteLine(ValidationResult result)
    {
        switch (result.IsValid)
        {
            case false:
            {
                foreach (ValidationFailure failure in result.Errors)
                {
                    TestContext.WriteLine($"{WsLocaleCore.Validator.Property} {failure.PropertyName} {WsLocaleCore.Validator.FailedValidation}. {WsLocaleCore.Validator.Error}: {failure.ErrorMessage}");
                }
                break;
            }
        }
    }

    public void AssertSqlDbContentValidate<T>(WsSqlEnumIsMarked isMarked = WsSqlEnumIsMarked.ShowAll) where T : WsSqlTableBase, new()
    {
        AssertAction(() =>
        {
            WsSqlCrudConfigModel sqlCrudConfig = WsSqlCrudConfigUtils.GetCrudConfigSection(isMarked);
            List<T> items = ContextManager.ContextList.GetListNotNullable<T>(sqlCrudConfig);
            Assert.IsTrue(items.Any());
            PrintTopRecords(items, 0, true);
        }, false, new() { WsEnumConfiguration.DevelopVS, WsEnumConfiguration.ReleaseVS });
    }

    public void AssertSqlValidate<T>(T item, bool assertResult) where T : WsSqlTableBase, new() =>
        AssertSqlTablesValidate(item, assertResult);

    public void AssertSqlDbContentSerialize<T>(WsSqlEnumIsMarked isMarked = WsSqlEnumIsMarked.ShowAll) where T : WsSqlTableBase, new()
    {
        AssertAction(() =>
        {
            WsSqlCrudConfigModel sqlCrudConfig = WsSqlCrudConfigUtils.GetCrudConfigSection(isMarked);
            List<T> items = ContextManager.ContextList.GetListNotNullable<T>(sqlCrudConfig);
            Assert.IsTrue(items.Any());
            PrintTopRecords(items, 10, true, true);
        }, false, new() { WsEnumConfiguration.DevelopVS, WsEnumConfiguration.ReleaseVS });
    }

    public void AssertSqlTablesValidate<T>(T item, bool assertResult) where T : class, new()
    {
        Assert.DoesNotThrow(() =>
        {
            ValidationResult validationResult = WsSqlValidationUtils.GetValidationResult(item);
            FailureWriteLine(validationResult);
            // Assert.
            switch (assertResult)
            {
                case true:
                    Assert.IsTrue(validationResult.IsValid);
                    break;
                default:
                    Assert.IsFalse(validationResult.IsValid);
                    break;
            }
        });
    }
    
    public object? GetSqlPropertyValue<T>(bool isNotDefault, string propertyName) where T : WsSqlTableBase, new()
    {
        // Arrange
        T item = CreateNewSubstitute<T>(isNotDefault);
        // Act.
        object? value = item.GetPropertyAsObject(propertyName);
        TestContext.WriteLine($"{typeof(T)}. {propertyName}: {value}");
        return value;
    }

    public void AssertSqlPropertyCheckDt<T>(string propertyName) where T : WsSqlTableBase, new()
    {
        // Arrange & Act.
        object? value = GetSqlPropertyValue<T>(true, propertyName);
        if (value is DateTime dtValue)
        {
            // Assert.
            Assert.IsNotNull(dtValue);
            Assert.AreNotEqual(DateTime.MinValue, dtValue);
        }
    }

    public void AssertSqlPropertyCheckBool<T>(string propertyName) where T : WsSqlTableBase, new()
    {
        // Arrange & Act.
        object? value = GetSqlPropertyValue<T>(true, propertyName);
        if (value is bool isValue)
        {
            // Assert.
            Assert.IsNotNull(isValue);
            Assert.IsFalse(isValue);
        }
    }

    public void AssertSqlPropertyCheckString<T>(string propertyName) where T : WsSqlTableBase, new()
    {
        // Arrange & Act.
        object? value = GetSqlPropertyValue<T>(true, propertyName);
        if (value is string strValue)
        {
            // Assert.
            Assert.IsNotEmpty(strValue);
            Assert.IsNotNull(strValue);
        }
    }

    public void AssertGetList<T>(WsSqlCrudConfigModel sqlCrudConfig, List<WsEnumConfiguration> publishTypes, bool isGreater = true)
        where T : WsSqlTableBase, new()
    {
        AssertAction(() =>
        {
            List<T> items = ContextManager.ContextList.GetListNotNullable<T>(sqlCrudConfig);
            TestContext.WriteLine($"Found {nameof(items.Count)}: {items.Count}");
            if (isGreater)
                Assert.Greater(items.Count, 0);
            foreach (T item in items)
            {
                Assert.IsNotEmpty(item.ToString());
                ValidationResult validationResult = WsSqlValidationUtils.GetValidationResult(item);
                if (!validationResult.IsValid)
                {
                    TestContext.WriteLine($"{item}");
                    TestContext.WriteLine($"{nameof(validationResult)}: {validationResult}");
                }
                if (!validationResult.IsValid)
                    TestContext.WriteLine($"{item} | {validationResult.Errors}");
                Assert.IsTrue(validationResult.IsValid);
            }
        }, false, publishTypes);
    }

    public T CreateNewSubstitute<T>(bool isNotDefault) where T : WsSqlTableBase, new()
    {
        WsSqlFieldIdentityModel fieldIdentity = Substitute.For<WsSqlFieldIdentityModel>(WsSqlEnumFieldIdentity.Empty);
        fieldIdentity.Name.Returns(WsSqlEnumFieldIdentity.Test);
        fieldIdentity.Uid.Returns(Guid.NewGuid());
        fieldIdentity.Id.Returns(-1);

        T item = Substitute.For<T>();
        if (!isNotDefault) return item;

        item.Identity.Returns(fieldIdentity);
        item.CreateDt.Returns(DateTime.Now);
        item.ChangeDt.Returns(DateTime.Now);
        item.IsMarked.Returns(false);
        item.Description.Returns(WsLocaleCore.Sql.SqlItemFieldDescription);

        switch (item)
        {
            case WsSqlAccessModel access:
                access.Name.Returns(WsLocaleCore.Sql.SqlItemFieldName);
                access.Rights.Returns((byte)WsEnumAccessRights.None);
                access.LoginDt.Returns(DateTime.Now);
                break;
            case WsSqlAppModel app:
                app.Name.Returns(WsLocaleCore.Sql.SqlItemFieldName);
                break;
            case WsSqlBarCodeModel barCode:
                barCode.TypeTop.Returns(WsSqlBarcodeType.Default.ToString());
                barCode.ValueTop.Returns(WsLocaleCore.Sql.SqlItemFieldValue);
                barCode.TypeRight.Returns(WsSqlBarcodeType.Default.ToString());
                barCode.ValueRight.Returns(WsLocaleCore.Sql.SqlItemFieldValue);
                barCode.TypeBottom.Returns(WsSqlBarcodeType.Default.ToString());
                barCode.ValueBottom.Returns(WsLocaleCore.Sql.SqlItemFieldValue);
                break;
            case WsSqlBoxModel box:
                box.Name.Returns(WsLocaleCore.Sql.SqlItemFieldName);
                box.Weight.Returns(3);
                break;
            case WsSqlBrandModel brand:
                brand.Name.Returns(WsLocaleCore.Sql.SqlItemFieldName);
                brand.Code.Returns(WsLocaleCore.Sql.SqlItemFieldCode);
                break;
            case WsSqlBundleModel bundle:
                bundle.Name.Returns(WsLocaleCore.Sql.SqlItemFieldName);
                bundle.Weight.Returns(3);
                break;
            case WsSqlClipModel clip:
                clip.Name.Returns(WsLocaleCore.Sql.SqlItemFieldName);
                clip.Weight.Returns(2);
                break;
            case WsSqlContragentModel contragent:
                contragent.Name.Returns(WsLocaleCore.Sql.SqlItemFieldName);
                break;
            case WsSqlDeviceModel device:
                device.LoginDt.Returns(DateTime.Now);
                device.LogoutDt.Returns(DateTime.Now);
                device.Name.Returns(WsLocaleCore.Sql.SqlItemFieldName);
                device.PrettyName.Returns(WsLocaleCore.Sql.SqlItemFieldPrettyName);
                device.Ipv4.Returns(WsLocaleCore.Sql.SqlItemFieldIp);
                device.MacAddressValue.Returns(WsLocaleCore.Sql.SqlItemFieldMac);
                break;
            case WsSqlDeviceTypeModel deviceType:
                deviceType.Name.Returns(WsLocaleCore.Sql.SqlItemFieldName);
                deviceType.PrettyName.Returns(WsLocaleCore.Sql.SqlItemFieldPrettyName);
                break;
            case WsSqlDeviceTypeFkModel deviceTypeFk:
                deviceTypeFk.Device = CreateNewSubstitute<WsSqlDeviceModel>(isNotDefault);
                deviceTypeFk.Type = CreateNewSubstitute<WsSqlDeviceTypeModel>(isNotDefault);
                break;
            case WsSqlDeviceScaleFkModel deviceScaleFk:
                deviceScaleFk.Device = CreateNewSubstitute<WsSqlDeviceModel>(isNotDefault);
                deviceScaleFk.Scale = CreateNewSubstitute<WsSqlScaleModel>(isNotDefault);
                break;
            case WsSqlLogModel log:
                log.Version.Returns(WsLocaleCore.Sql.SqlItemFieldVersion);
                log.File.Returns(WsLocaleCore.Sql.SqlItemFieldFile);
                log.Line.Returns(1);
                log.Member.Returns(WsLocaleCore.Sql.SqlItemFieldMember);
                log.LogType = CreateNewSubstitute<WsSqlLogTypeModel>(isNotDefault);
                log.Message.Returns(WsLocaleCore.Sql.SqlItemFieldMessage);
                break;
            case WsSqlLogTypeModel logType:
                logType.Icon.Returns(WsLocaleCore.Sql.SqlItemFieldIcon);
                break;
            case WsSqlLogWebModel logWeb:
                logWeb.StampDt.Returns(DateTime.Now);
                logWeb.Version.Returns(WsLocaleCore.Sql.SqlItemFieldVersion);
                logWeb.Direction.Returns((byte)0);
                logWeb.Url.Returns(WsLocaleCore.Sql.SqlItemFieldUrl);
                logWeb.Params.Returns(string.Empty);
                logWeb.Headers.Returns(string.Empty);
                logWeb.DataString.Returns(string.Empty);
                logWeb.DataType.Returns((byte)0);
                logWeb.CountAll.Returns(2);
                logWeb.CountSuccess.Returns(1);
                logWeb.CountErrors.Returns(1);
                break;
            case WsSqlLogWebFkModel logWebFk:
                logWebFk.LogWebRequest = CreateNewSubstitute<WsSqlLogWebModel>(isNotDefault);
                logWebFk.LogWebResponse = CreateNewSubstitute<WsSqlLogWebModel>(isNotDefault);
                logWebFk.LogWebResponse.Direction.Returns((byte)1);
                logWebFk.App = CreateNewSubstitute<WsSqlAppModel>(isNotDefault);
                logWebFk.LogType = CreateNewSubstitute<WsSqlLogTypeModel>(isNotDefault);
                logWebFk.Device = CreateNewSubstitute<WsSqlDeviceModel>(isNotDefault);
                break;
            case WsSqlPluGroupModel pluGroup:
                pluGroup.Name.Returns(WsLocaleCore.Sql.SqlItemFieldName);
                pluGroup.Code.Returns(WsLocaleCore.Sql.SqlItemFieldCode);
                break;
            case WsSqlPluCharacteristicModel nomenclatureCharacteristic:
                nomenclatureCharacteristic.Name.Returns(WsLocaleCore.Sql.SqlItemFieldName);
                nomenclatureCharacteristic.AttachmentsCount.Returns(3);
                break;
            case WsSqlPluCharacteristicsFkModel nomenclatureCharacteristicFk:
                nomenclatureCharacteristicFk.Plu = CreateNewSubstitute<WsSqlPluModel>(isNotDefault);
                nomenclatureCharacteristicFk.Characteristic = CreateNewSubstitute<WsSqlPluCharacteristicModel>(isNotDefault);
                break;
            case WsSqlPluFkModel pluFk:
                pluFk.Plu = CreateNewSubstitute<WsSqlPluModel>(isNotDefault);
                pluFk.Parent = CreateNewSubstitute<WsSqlPluModel>(isNotDefault);
                break;
            case WsSqlPluGroupFkModel pluGroupFk:
                pluGroupFk.PluGroup = CreateNewSubstitute<WsSqlPluGroupModel>(isNotDefault);
                pluGroupFk.Parent = CreateNewSubstitute<WsSqlPluGroupModel>(isNotDefault);
                break;
            case WsSqlOrderModel order:
                order.Name.Returns(WsLocaleCore.Sql.SqlItemFieldName);
                order.BoxCount.Returns(1);
                order.PalletCount.Returns(1);
                break;
            case WsSqlOrderWeighingModel orderWeighing:
                orderWeighing.Order = CreateNewSubstitute<WsSqlOrderModel>(isNotDefault);
                orderWeighing.PluWeighing = CreateNewSubstitute<WsSqlPluWeighingModel>(isNotDefault);
                break;
            case WsSqlOrganizationModel organization:
                organization.Name.Returns(WsLocaleCore.Sql.SqlItemFieldName);
                organization.Gln.Returns(1);
                break;
            case WsSqlPluModel plu:
                plu.Name.Returns(WsLocaleCore.Sql.SqlItemFieldName);
                plu.Number.Returns((short)100);
                plu.FullName.Returns(WsLocaleCore.Sql.SqlItemFieldFullName);
                plu.Gtin.Returns(WsLocaleCore.Sql.SqlItemFieldGtin);
                plu.Ean13.Returns(WsLocaleCore.Sql.SqlItemFieldEan13);
                plu.Itf14.Returns(WsLocaleCore.Sql.SqlItemFieldItf14);
                plu.Code.Returns(WsLocaleCore.Sql.SqlItemFieldCode);
                break;
            case WsSqlPluBundleFkModel pluBundle:
                pluBundle.Plu = CreateNewSubstitute<WsSqlPluModel>(isNotDefault);
                pluBundle.Bundle = CreateNewSubstitute<WsSqlBundleModel>(isNotDefault);
                break;
            case WsSqlPluClipFkModel pluClips:
                pluClips.Plu = CreateNewSubstitute<WsSqlPluModel>(isNotDefault);
                pluClips.Clip = CreateNewSubstitute<WsSqlClipModel>(isNotDefault);
                break;
            case WsSqlPluLabelModel pluLabel:
                pluLabel.Zpl.Returns(WsLocaleCore.Sql.SqlItemFieldZpl);
                pluLabel.PluWeighing = CreateNewSubstitute<WsSqlPluWeighingModel>(isNotDefault);
                pluLabel.PluScale = CreateNewSubstitute<WsSqlPluScaleModel>(isNotDefault);
                pluLabel.ProductDt.Returns(DateTime.Now);
                pluLabel.ExpirationDt.Returns(DateTime.Now);
                break;
            case WsSqlPluScaleModel pluScale:
                pluScale.IsActive.Returns(true);
                pluScale.Plu = CreateNewSubstitute<WsSqlPluModel>(isNotDefault);
                pluScale.Line = CreateNewSubstitute<WsSqlScaleModel>(isNotDefault);
                break;
            case WsSqlPluStorageMethodModel pluStorageMethod:
                pluStorageMethod.Name.Returns(WsLocaleCore.Sql.SqlItemFieldName);
                pluStorageMethod.MinTemp.Returns((short)0);
                pluStorageMethod.MaxTemp.Returns((short)0);
                break;
            case WsSqlPluStorageMethodFkModel pluStorageMethodFk:
                pluStorageMethodFk.Plu = CreateNewSubstitute<WsSqlPluModel>(isNotDefault);
                pluStorageMethodFk.Method = CreateNewSubstitute<WsSqlPluStorageMethodModel>(isNotDefault);
                pluStorageMethodFk.Resource = CreateNewSubstitute<WsSqlTemplateResourceModel>(isNotDefault);
                break;
            case WsSqlPluTemplateFkModel pluTemplateFk:
                pluTemplateFk.Plu = CreateNewSubstitute<WsSqlPluModel>(isNotDefault);
                pluTemplateFk.Template = CreateNewSubstitute<WsSqlTemplateModel>(isNotDefault);
                break;
            case WsSqlPluWeighingModel pluWeighing:
                pluWeighing.Sscc.Returns(WsLocaleCore.Sql.SqlItemFieldSscc);
                pluWeighing.NettoWeight.Returns(1.1M);
                pluWeighing.WeightTare.Returns(0.25M);
                pluWeighing.RegNum.Returns(1);
                pluWeighing.Kneading.Returns((short)1);
                pluWeighing.PluScale = CreateNewSubstitute<WsSqlPluScaleModel>(isNotDefault);
                pluWeighing.Series = CreateNewSubstitute<WsSqlProductSeriesModel>(isNotDefault);
                break;
            case WsSqlPluNestingFkModel pluNestingFk:
                pluNestingFk.IsDefault.Returns(false);
                pluNestingFk.PluBundle = CreateNewSubstitute<WsSqlPluBundleFkModel>(isNotDefault);
                pluNestingFk.Box = CreateNewSubstitute<WsSqlBoxModel>(isNotDefault);
                pluNestingFk.BundleCount.Returns((short)0);
                break;
            case WsSqlPrinterModel printer:
                printer.DarknessLevel.Returns((short)1);
                printer.PrinterType = CreateNewSubstitute<WsSqlPrinterTypeModel>(isNotDefault);
                break;
            case WsSqlPrinterResourceFkModel printerResource:
                printerResource.Printer = CreateNewSubstitute<WsSqlPrinterModel>(isNotDefault);
                printerResource.TemplateResource = CreateNewSubstitute<WsSqlTemplateResourceModel>(isNotDefault);
                break;
            case WsSqlPrinterTypeModel printerType:
                printerType.Name.Returns(WsLocaleCore.Sql.SqlItemFieldName);
                break;
            case WsSqlProductionFacilityModel productionFacility:
                productionFacility.Name.Returns(WsLocaleCore.Sql.SqlItemFieldName);
                productionFacility.Address.Returns(WsLocaleCore.Sql.SqlItemFieldAddress);
                break;
            case WsSqlProductSeriesModel productSeries:
                productSeries.Sscc.Returns(WsLocaleCore.Sql.SqlItemFieldSscc);
                productSeries.IsClose.Returns(false);
                productSeries.Scale = CreateNewSubstitute<WsSqlScaleModel>(isNotDefault);
                break;
            case WsSqlScaleModel scale:
                scale.WorkShop = CreateNewSubstitute<WsSqlWorkShopModel>(isNotDefault);
                scale.PrinterMain = CreateNewSubstitute<WsSqlPrinterModel>(isNotDefault);
                scale.PrinterShipping = CreateNewSubstitute<WsSqlPrinterModel>(isNotDefault);
                scale.Number.Returns(10000);
                break;
            case WsSqlScaleScreenShotModel scaleScreenShot:
                scaleScreenShot.Scale = CreateNewSubstitute<WsSqlScaleModel>(isNotDefault);
                scaleScreenShot.ScreenShot.Returns(new byte[] { 0x00 });
                break;
            case WsSqlTaskModel task:
                task.TaskType = CreateNewSubstitute<WsSqlTaskTypeModel>(isNotDefault);
                task.Scale = CreateNewSubstitute<WsSqlScaleModel>(isNotDefault);
                break;
            case WsSqlTaskTypeModel taskType:
                taskType.Name.Returns(WsLocaleCore.Sql.SqlItemFieldName);
                break;
            case WsSqlTemplateModel template:
                template.Title.Returns(WsLocaleCore.Sql.SqlItemFieldTitle);
                break;
            case WsSqlTemplateResourceModel templateResource:
                templateResource.Name.Returns(WsLocaleCore.Sql.SqlItemFieldName);
                templateResource.Type.Returns(WsLocaleCore.Sql.SqlItemFieldTemplateResourceType);
                templateResource.DataValue.Returns(new byte[] { 0x00 });
                break;
            case WsSqlVersionModel version:
                version.Version.Returns((short)1);
                version.ReleaseDt.Returns(DateTime.Now);
                break;
            case WsSqlWorkShopModel workShop:
                workShop.Name.Returns(WsLocaleCore.Sql.SqlItemFieldName);
                workShop.ProductionFacility = CreateNewSubstitute<WsSqlProductionFacilityModel>(isNotDefault);
                break;
        }
        return item;
    }

    public void TableBaseModelAssertEqualsNew<T>() where T : WsSqlTableBase, new()
    {
        Assert.DoesNotThrow(() =>
        {
            // Arrange.
            T item = new();
            WsSqlTableBase baseItem = new();
            // Act.
            bool itemEqualsNew = item.EqualsNew();
            bool baseEqualsNew = baseItem.EqualsNew();
            // Assert.
            Assert.AreEqual(baseEqualsNew, itemEqualsNew);
        });
    }

    public void FieldBaseModelAssertEqualsNew<T>() where T : WsSqlFieldBase, new()
    {
        Assert.DoesNotThrow(() =>
        {
            // Arrange.
            T item = new();
            WsSqlFieldBase baseItem = new();
            // Act.
            bool itemEqualsNew = item.EqualsNew();
            bool baseEqualsNew = baseItem.EqualsNew();
            // Assert.
            Assert.AreEqual(baseEqualsNew, itemEqualsNew);
        });
    }

    public void TableBaseModelAssertSerialize<T>() where T : WsSqlTableBase, new()
    {
        Assert.DoesNotThrow(() =>
        {
            // Arrange.
            T item1 = new();
            WsSqlTableBase base1 = new();
            // Act.
            string xml1 = WsDataFormatUtils.SerializeAsXmlString<T>(item1, true, true);
            string xml2 = WsDataFormatUtils.SerializeAsXmlString<WsSqlTableBase>(base1, true, true);
            // Assert.
            Assert.AreNotEqual(xml1, xml2);
            // Act.
            T item2 = WsDataFormatUtils.DeserializeFromXml<T>(xml1);
            TestContext.WriteLine($"{nameof(item2)}: {item2}");
            WsSqlTableBase base2 = WsDataFormatUtils.DeserializeFromXml<WsSqlTableBase>(xml2);
            TestContext.WriteLine($"{nameof(base2)}: {base2}");
            // Assert.
            Assert.AreNotEqual(item2, base2);
        });
    }

    public void TableBaseModelAssertToString<T>() where T : WsSqlTableBase, new()
    {
        Assert.DoesNotThrow(() =>
        {
            // Arrange.
            T item = new();
            WsSqlTableBase baseItem = new();
            // Act.
            string itemString = item.ToString();
            string baseString = baseItem.ToString();
            TestContext.WriteLine($"{nameof(itemString)}: {itemString}");
            TestContext.WriteLine($"{nameof(baseString)}: {baseString}");
            // Assert.
            Assert.AreNotEqual(baseString, itemString);
        });
    }

    public void FieldBaseModelAssertToString<T>() where T : WsSqlFieldBase, new()
    {
        Assert.DoesNotThrow(() =>
        {
            // Arrange.
            T item = new();
            WsSqlFieldBase baseItem = new();
            // Act.
            string itemString = item.ToString();
            string baseString = baseItem.ToString();
            TestContext.WriteLine($"{nameof(itemString)}: {itemString}");
            TestContext.WriteLine($"{nameof(baseString)}: {baseString}");
            // Assert.
            Assert.AreNotEqual(baseString, itemString);
        });
    }

    public void PrintTopRecords<T>(List<T> items, ushort count = 0, bool isValidate = false, bool isSerialize = false) 
        where T : class, new()
    {
        checked
        {
            if (Equals(count, (ushort)0))
                count = (ushort)items.Count;
            TestContext.WriteLine($"Print top {count} from {items.Count} records.");
            int i = 0;
            foreach (T item in items)
            {
                if (i < count)
                {
                    TestContext.WriteLine(WsSqlQueries.TrimQuery(item.ToString() ?? string.Empty));
                    if (isValidate)
                    {
                        AssertSqlTablesValidate(item, true);
                        ValidationResult validationResult = WsSqlValidationUtils.GetValidationResult(item);
                        FailureWriteLine(validationResult);
                        Assert.IsTrue(validationResult.IsValid);
                    }
                    if (isSerialize && item is SerializeBase sitem)
                    {
                        string xml = WsDataFormatUtils.SerializeAsXmlString<T>(sitem, true, false);
                        Assert.IsNotEmpty(xml);
                    }
                }
                else break;
                i++;
            }
        }
    }

    #endregion
}
