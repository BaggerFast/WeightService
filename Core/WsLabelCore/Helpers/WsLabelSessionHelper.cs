// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace WsLabelCore.Helpers;

/// <summary>
/// Пользовательская сессия.
/// </summary>
#nullable enable
public sealed class WsLabelSessionHelper : BaseViewModel, INotifyPropertyChanged
{
    #region Design pattern "Lazy Singleton"

#pragma warning disable CS8618
    private static WsLabelSessionHelper _instance;
#pragma warning restore CS8618
    public static WsLabelSessionHelper Instance => LazyInitializer.EnsureInitialized(ref _instance);

    #endregion

    #region Public and private fields and properties

    private WsDebugHelper Debug => WsDebugHelper.Instance;
    public WsSqlContextManagerHelper ContextManager => WsSqlContextManagerHelper.Instance;
    public WsSqlContextCacheHelper ContextCache => WsSqlContextCacheHelper.Instance;
    public WsPluginPrintTscModel? PluginPrintTscMain { get; set; }
    public WsPluginPrintZebraModel? PluginPrintZebraMain { get; set; }
    public WsPluginPrintTscModel? PluginPrintTscShipping { get; set; }
    public WsPluginPrintZebraModel? PluginPrintZebraShipping { get; set; }
    private ProductSeriesDirect ProductSeries { get; set; } = new();
    public WsEnumPrintModel PrintModelMain =>
        Line.PrinterMain is not null && Line.PrinterMain.PrinterType.Name.Contains("TSC ") ? WsEnumPrintModel.Tsc : WsEnumPrintModel.Zebra;
    public WsEnumPrintModel PrintModelShipping =>
        Line.PrinterShipping is not null && Line.PrinterShipping.PrinterType.Name.Contains("TSC ") ? WsEnumPrintModel.Tsc : WsEnumPrintModel.Zebra;
    public WsSqlPluWeighingModel PluWeighing { get; set; }
    public WsWeighingSettingsModel WeighingSettings { get; private set; }
    public WsSqlPluScaleModel PluLine { get; private set; }
    public ushort PlusPageColumnCount => 4;
    public ushort PlusPageSize => 16;
    public ushort PlusPageRowCount => 4;
    public int PlusPageNumber { get; set; }
    public WsSqlDeviceScaleFkModel DeviceScaleFk { get; private set; }
    public WsSqlProductionFacilityModel Area { get; private set ; }
    public WsSqlScaleModel Line { get; private set; }
    public string PublishDescription { get; private set; } = "";
    private DateTime ProductDateMaxValue => DateTime.Now.AddDays(+31);
    private DateTime ProductDateMinValue => DateTime.Now.AddDays(-31);
    public DateTime ProductDate { get; set; }
    public string DeviceName => MdNetUtils.GetLocalDeviceName(false);
    public WsSqlViewPluNestingModel ViewPluNesting { get; private set; }
    private readonly object _locker = new();
    /// <summary>
    /// Инкремент счётчика печати штучной продукции.
    /// </summary>
    public bool IsIncrementCounter { get; private set; } = true;

    public WsLocalizationModel Localization { get; set; } = new();


    public WsLabelSessionHelper()
    {
        Area = ContextManager.ContextAreas.GetNewItem();
        PluLine = ContextManager.ContextPlusLines.GetNewItem();
        Line = ContextManager.ContextLines.GetNewItem();
        PluWeighing = ContextManager.ContextPlusWeighing.GetNewItem();
        DeviceScaleFk = ContextManager.ContextDevicesLines.GetNewItem();
        ViewPluNesting = ContextManager.ContextPlusNesting.GetNewView();
        WeighingSettings = new();
    }

    #endregion

    #region Public and private methods

    public int GetPlusPageCount() =>
        ContextCache.LocalViewPlusLines.Where(item => item.IsActive).ToList().Count / PlusPageSize;

    public void RotateProductDate(WsEnumDirection direction)
    {
        switch (direction)
        {
            case WsEnumDirection.Left:
            {
                ProductDate = ProductDate.AddDays(-1);
                if (ProductDate < ProductDateMinValue) ProductDate = ProductDateMinValue;
                break;
            }
            case WsEnumDirection.Right:
            {
                ProductDate = ProductDate.AddDays(1);
                if (ProductDate > ProductDateMaxValue) ProductDate = ProductDateMaxValue;
                break;
            }
        }
    }

    public void NewPallet()
    {
        if (PluginPrintTscMain is not null) PluginPrintTscMain.LabelPrintedCount = 1;
        if (PluginPrintZebraMain is not null) PluginPrintZebraMain.LabelPrintedCount = 1;
        if (Line.IsShipping)
        {
            if (PluginPrintTscShipping is not null) PluginPrintTscShipping.LabelPrintedCount = 1;
            if (PluginPrintZebraShipping is not null) PluginPrintZebraShipping.LabelPrintedCount = 1;
        }
        ProductSeries.Load();
    }

    /// <summary>
    /// Настроить сессию.
    /// </summary>
    /// <param name="showNavigation"></param>
    /// <param name="lineId"></param>
    /// <param name="area"></param>
    public void SetSessionForLabelPrint(Action<WsFormBaseUserControl, string> showNavigation, long lineId = -1,
        WsSqlProductionFacilityModel? area = null)
    {
        lock (_locker)
        {
            SetSqlPublish();
            // Обновить кэш.
            ContextCache.LoadGlobal();
            // Device.
            WsSqlDeviceModel device = ContextManager.ContextItem.GetItemDeviceNotNullable(DeviceName);
            device = WsFormNavigationUtils.SetNewDeviceWithQuestion(showNavigation,
                device, MdNetUtils.GetLocalIpAddress(), MdNetUtils.GetLocalMacAddress());
            // DeviceTypeFk.
            WsSqlDeviceTypeFkModel deviceTypeFk = ContextManager.ContextItem.GetItemDeviceTypeFkNotNullable(device);
            if (deviceTypeFk.IsNew)
            {
                // DeviceType.
                WsSqlDeviceTypeModel deviceType = ContextManager.ContextItem.GetItemDeviceTypeNotNullable("Monoblock");
                // DeviceTypeFk.
                deviceTypeFk.Device = device;
                deviceTypeFk.Type = deviceType;
                ContextManager.AccessItem.Save(deviceTypeFk);
            }
            // DeviceTypeFk.
            DeviceScaleFk = ContextManager.ContextItem.GetItemDeviceScaleFkNotNullable(deviceTypeFk.Device);
            // Line.
            SetLine(lineId <= 0 ? DeviceScaleFk.Scale : ContextManager.ContextItem.GetScaleNotNullable(lineId));
            // Area.
            SetArea(area);
            // Other.
            ProductDate = DateTime.Now;
            // Новая серия, упаковка продукции, новая паллета.
            ProductSeries = new(Line);
            WeighingSettings = new();
        }
    }

    /// <summary>
    /// Задать настройки публикации.
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    private void SetSqlPublish() =>
        PublishDescription = Debug.Config switch
        {
            WsEnumConfiguration.DevelopAleksandrov => WsLocaleCore.Sql.SqlServerDevelopAleksandrov,
            WsEnumConfiguration.DevelopMorozov => WsLocaleCore.Sql.SqlServerDevelopMorozov,
            WsEnumConfiguration.DevelopVS => WsLocaleCore.Sql.SqlServerVS,
            WsEnumConfiguration.ReleaseAleksandrov => WsLocaleCore.Sql.SqlServerReleaseAleksandrov,
            WsEnumConfiguration.ReleaseMorozov => WsLocaleCore.Sql.SqlServerReleaseMorozov,
            WsEnumConfiguration.ReleaseVS => WsLocaleCore.Sql.SqlServerReleaseVS,
            _ => throw new ArgumentOutOfRangeException()
        };

    #endregion

    #region Public and private methods

    /// <summary>
    /// Смена площадки.
    /// </summary>
    private void SetArea(WsSqlProductionFacilityModel? area = null)
    {
        if (area is not null && area.IsExists)
        {
            Area = area;
        }
        else if (Line.WorkShop is not null && Area.IsNotExists)
        {
            WsSqlWorkShopModel? workShop = ContextCache.WorkShops.Find(
                item => item.IdentityValueId.Equals(Line.WorkShop.IdentityValueId));
            if (workShop is not null)
            {
                Area = ContextCache.Areas.Find(
                    item => item.IdentityValueId.Equals(workShop.ProductionFacility.IdentityValueId));
            }
            else
                Area = ContextManager.ContextAreas.GetNewItem();
        }
        else if (Area.IsNotExists)
        {
            Area = ContextManager.ContextAreas.GetNewItem();
        }
        // Журналирование смены площадки.
        ContextManager.ContextItem.SaveLogInformation($"{WsLocaleCore.LabelPrint.SetArea(Area.IdentityValueId, Area.Name)}");
    }

    /// <summary>
    /// Смена линии.
    /// </summary>
    private void SetLine(WsSqlScaleModel? line = null)
    {
        Line = line ?? ContextManager.ContextLines.GetNewItem();
        // Журналирование смены линии.
        if (Line.IsExists)
            ContextManager.ContextItem.SaveLogInformation($"{WsLocaleCore.LabelPrint.SetLine(Line.IdentityValueId, Line.Description)}");
        // Смена площадки.
        SetArea();
        // Смена ПЛУ линии.
        SetPluLine();
    }

    /// <summary>
    /// Смена ПЛУ линии.
    /// </summary>
    public void SetPluLine(WsSqlPluScaleModel? pluLine = null)
    {
        PluLine = pluLine ?? ContextManager.ContextPlusLines.GetNewItem();
        // Журналирование смены ПЛУ на линии.
        if (PluLine.IsExists)
            ContextManager.ContextItem.SaveLogInformation($"{WsLocaleCore.LabelPrint.SetPlu(PluLine.Plu.Number, PluLine.Plu.Name)}");

        if (PluLine.IsNotNew)
        {
            WsSqlBundleModel bundle = ContextManager.ContextBundles.GetItem(PluLine.Plu);
            if (bundle.IsExists)
            {
                PluLine.Plu.PackageTypeGuid = bundle.IdentityValueUid;
                PluLine.Plu.PackageTypeName = bundle.Name;
                PluLine.Plu.PackageTypeWeight = bundle.Weight;
            }
            WsSqlClipModel clip = WsSqlContextManagerHelper.Instance.ContextClips.GetItem(PluLine.Plu);
            if (clip.IsExists)
            {
                PluLine.Plu.ClipTypeGuid = clip.IdentityValueUid;
                PluLine.Plu.ClipTypeName = clip.Name;
                PluLine.Plu.ClipTypeWeight = clip.Weight;
            }
        }
        if (PluginPrintTscMain is not null) PluginPrintTscMain.LabelPrintedCount = 1;
        if (PluginPrintZebraMain is not null) PluginPrintZebraMain.LabelPrintedCount = 1;
        if (Line.IsShipping)
        {
            if (PluginPrintTscShipping is not null) PluginPrintTscShipping.LabelPrintedCount = 1;
            if (PluginPrintZebraShipping is not null) PluginPrintZebraShipping.LabelPrintedCount = 1;
        }
        // Смена вложенности ПЛУ.
        SetViewPluNesting();
    }

    /// <summary>
    /// Смена вложенности ПЛУ.
    /// </summary>
    /// <param name="viewPluNesting"></param>
    public void SetViewPluNesting(WsSqlViewPluNestingModel? viewPluNesting = null)
    {
        if (viewPluNesting is null && PluLine.IsExists)
        {
            viewPluNesting = ContextCache.ViewPlusNesting.Find(
                item => item.PluUid.Equals(PluLine.Plu.IdentityValueUid) && item.IsDefault);
            ViewPluNesting = viewPluNesting ?? ContextManager.ContextPlusNesting.GetNewView();
        }
        else if (viewPluNesting is null)
        {
            ViewPluNesting = ContextManager.ContextPlusNesting.GetNewView();
        }
        else
            ViewPluNesting = viewPluNesting;
        // Журналирование смены вложенности ПЛУ.
        if (PluLine.IsExists)
            ContextManager.ContextItem.SaveLogInformation(
                $"{WsLocaleCore.LabelPrint.SetPluNesting(ViewPluNesting.PluNumber, ViewPluNesting.PluName, ViewPluNesting.BundleCount)}");
    }

    /// <summary>
    /// Задать Инкремент счётчика печати штучной продукции.
    /// </summary>
    /// <param name="isIncrementCounter"></param>
    public void SetIsIncrementCounter(bool isIncrementCounter)
    {
        IsIncrementCounter = isIncrementCounter;
    }

    /// <summary>
    /// Инкремент счётчика этикеток.
    /// </summary>
    public void AddLineCounter()
    {
        Line.LabelCounter++;
        PluLine.Line.LabelCounter = Line.LabelCounter;
        ContextManager.AccessItem.Update(Line);
    }

    #endregion
}