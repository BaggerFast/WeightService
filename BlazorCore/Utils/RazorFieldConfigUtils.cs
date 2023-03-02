﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using BlazorCore.Razors;
using DataCore.Sql.TableScaleFkModels.DeviceScalesFks;
using DataCore.Sql.TableScaleFkModels.DeviceTypesFks;
using DataCore.Sql.TableScaleFkModels.PlusNestingFks;
using DataCore.Sql.TableScaleModels.Access;
using DataCore.Sql.TableScaleModels.BarCodes;
using DataCore.Sql.TableScaleModels.Boxes;
using DataCore.Sql.TableScaleModels.Bundles;
using DataCore.Sql.TableScaleModels.Devices;
using DataCore.Sql.TableScaleModels.DeviceTypes;
using DataCore.Sql.TableScaleModels.Organizations;
using DataCore.Sql.TableScaleModels.Plus;
using DataCore.Sql.TableScaleModels.PlusScales;
using DataCore.Sql.TableScaleModels.Printers;
using DataCore.Sql.TableScaleModels.PrintersResources;
using DataCore.Sql.TableScaleModels.PrintersTypes;
using DataCore.Sql.TableScaleModels.ProductionFacilities;
using DataCore.Sql.TableScaleModels.Scales;
using DataCore.Sql.TableScaleModels.TemplatesResources;
using DataCore.Sql.TableScaleModels.Versions;
using DataCore.Sql.TableScaleModels.WorkShops;
using Radzen;

namespace BlazorCore.Utils;


public static class RazorFieldConfigUtils
{
    private static LocaleTable LTable => LocaleTable.Instance;
    
    public static class Base
    {
        public static RazorFieldConfigModel GetChangeDt() => new(nameof(SqlTableBase.ChangeDt), TextAlign.Center, LTable.ChangeDt);
        public static RazorFieldConfigModel GetCreateDt() => new(nameof(SqlTableBase.CreateDt), TextAlign.Center, LTable.CreateDt);
        public static RazorFieldConfigModel GetDescription(string description = "") => new(nameof(SqlTableBase.Description), TextAlign.Left, !string.IsNullOrEmpty(description) ? description : LTable.Description);
        public static RazorFieldConfigModel GetName(string name = "") => new(nameof(SqlTableBase.Name), TextAlign.Left, !string.IsNullOrEmpty(name) ? name : LTable.Name);
    }
    
    public static class Access
	{
		public static RazorFieldConfigModel GetRights() => new(nameof(AccessModel.Rights), TextAlign.Left, LTable.AccessLevel);
		public static RazorFieldConfigModel GetLoginDt() => new(nameof(AccessModel.LoginDt), TextAlign.Center, LTable.LoginDt);
	}

	public static class BarCode
	{
		public static RazorFieldConfigModel GetTypeTop() => new(nameof(BarCodeModel.TypeTop), TextAlign.Left, LTable.Type);
		public static RazorFieldConfigModel GetValueTop() => new(nameof(BarCodeModel.ValueTop), TextAlign.Left, LTable.Value);
		public static RazorFieldConfigModel GetValueRight() => new(nameof(BarCodeModel.ValueRight), TextAlign.Left, LTable.Value);
		public static RazorFieldConfigModel GetValueBottom() => new(nameof(BarCodeModel.ValueBottom), TextAlign.Left, LTable.Value);
		public static RazorFieldConfigModel GetPluLabelChangeDt() => new(nameof(BarCodeModel.PluLabel.ChangeDt), TextAlign.Center, LTable.Label);
	}

    # region Devices
    
    public static class Device
    {
        public static RazorFieldConfigModel GetLoginDt() => new(nameof(DeviceModel.LoginDt), TextAlign.Left, LTable.LoginDt);
        public static RazorFieldConfigModel GetLogoutDt() => new(nameof(DeviceModel.LogoutDt), TextAlign.Left, LTable.LogoutDt);
        public static RazorFieldConfigModel GetIpv4() => new(nameof(DeviceModel.Ipv4), TextAlign.Left, LTable.DeviceIp);
        public static RazorFieldConfigModel GetMacAddress() => new(nameof(DeviceModel.MacAddress), TextAlign.Center, LTable.DeviceMac);
        public static RazorFieldConfigModel GetPrettyName() => new(nameof(DeviceModel.PrettyName), TextAlign.Left, LTable.PrettyName);
        public static RazorFieldConfigModel GetTypePrettyName() => new(
            $"{nameof(DeviceTypeModel)}.{nameof(DeviceTypeModel.PrettyName)}", TextAlign.Left, LTable.Type);
    }
    
    public static class DeviceScaleFk
	{
		public static RazorFieldConfigModel GetDeviceIp() => new($"{nameof(DeviceScaleFkModel.Device)}.{nameof(DeviceModel.Ipv4)}", TextAlign.Left, LTable.DeviceIp);
		public static RazorFieldConfigModel GetDeviceLoginDt() => new($"{nameof(DeviceScaleFkModel.Device)}.{nameof(DeviceModel.LoginDt)}", TextAlign.Center, LTable.LoginDt);
		public static RazorFieldConfigModel GetDeviceLogoutDt() => new($"{nameof(DeviceScaleFkModel.Device)}.{nameof(DeviceModel.LogoutDt)}", TextAlign.Center, LTable.LogoutDt);
		public static RazorFieldConfigModel GetDeviceMacAddress() => new($"{nameof(DeviceScaleFkModel.Device)}.{nameof(DeviceModel.MacAddress)}", TextAlign.Center, LTable.DeviceMac);
		public static RazorFieldConfigModel GetDeviceName() => new(new DeviceModel(), $"{nameof(DeviceScaleFkModel.Device)}.{nameof(DeviceModel.Name)}", TextAlign.Left, LTable.Device, LTable.Name);
		public static RazorFieldConfigModel GetDevicePrettyName() => new($"{nameof(DeviceScaleFkModel.Device)}.{nameof(DeviceModel.PrettyName)}", TextAlign.Left, LTable.PrettyName);
	}

	public static class DeviceType
	{
		public static RazorFieldConfigModel GetPrettyName() => new(nameof(DeviceTypeModel.PrettyName), TextAlign.Left, LTable.PrettyName);
	}

	public static class DeviceTypeFk
	{
		public static RazorFieldConfigModel GetDeviceLoginDt() => new(
			$"{nameof(DeviceTypeFkModel.Device)}.{nameof(DeviceModel.LoginDt)}",
			TextAlign.Center, LTable.LoginDt, nameof(DateTime));
		public static RazorFieldConfigModel GetDeviceLogoutDt() => new(
			$"{nameof(DeviceTypeFkModel.Device)}.{nameof(DeviceModel.LogoutDt)}", TextAlign.Center, LTable.LogoutDt);
		public static RazorFieldConfigModel GetDeviceName() => new(
			$"{nameof(DeviceTypeFkModel.Device)}.{nameof(DeviceModel.Name)}", TextAlign.Left, LTable.Name);
		public static RazorFieldConfigModel GetDevicePrettyName() => new(
			$"{nameof(DeviceTypeFkModel.Device)}.{nameof(DeviceModel.PrettyName)}", TextAlign.Left, LTable.PrettyName);
		public static RazorFieldConfigModel GetDeviceIpv4() => new(
			$"{nameof(DeviceTypeFkModel.Device)}.{nameof(DeviceModel.Ipv4)}", TextAlign.Left, LTable.DeviceIp);
		public static RazorFieldConfigModel GetDeviceMacAddress() => new(
			$"{nameof(DeviceTypeFkModel.Device)}.{nameof(DeviceModel.MacAddress)}", TextAlign.Center, LTable.DeviceMac);
		public static RazorFieldConfigModel GetDeviceTypeName() => new(
			$"{nameof(DeviceTypeFkModel.Type)}.{nameof(DeviceTypeModel.Name)}", TextAlign.Left, LTable.Type);
		public static RazorFieldConfigModel GetDeviceTypePrettyName() => new(
			$"{nameof(DeviceTypeFkModel.Type)}.{nameof(DeviceTypeModel.PrettyName)}", TextAlign.Left, LTable.Type);
	}
    
    # endregion

    public static class LogQuick
	{
		public static RazorFieldConfigModel GetApp() => new(nameof(DataCore.Sql.Xml.LogQuickModel.App), TextAlign.Left, LTable.App);
		public static RazorFieldConfigModel GetDevice() => new(nameof(DataCore.Sql.Xml.LogQuickModel.Host), TextAlign.Left, LTable.Host, "string");
		public static RazorFieldConfigModel GetIcon() => new(nameof(DataCore.Sql.Xml.LogQuickModel.Icon), TextAlign.Left, LTable.Icon);
		public static RazorFieldConfigModel GetMessage() => new(nameof(DataCore.Sql.Xml.LogQuickModel.Message), TextAlign.Left, LTable.Message);
		public static RazorFieldConfigModel GetScale() => new(nameof(DataCore.Sql.Xml.LogQuickModel.Scale), TextAlign.Left, LTable.Arm, "string");
		public static RazorFieldConfigModel GetVersion() => new(nameof(DataCore.Sql.Xml.LogQuickModel.Version), TextAlign.Left, LTable.Version);
	}

	public static class Organization
	{
		public static RazorFieldConfigModel GetGln() => new(nameof(OrganizationModel.Gln), TextAlign.Center, LTable.Gln);
	}

    public static class Box
    {
        public static RazorFieldConfigModel GetName() => new(nameof(BoxModel.Name), TextAlign.Left, LTable.Name);
        public static RazorFieldConfigModel GetWeight() => new(nameof(BoxModel.Weight), TextAlign.Center, LTable.BoxWeight);
    }

    public static class Bundle
    {
        public static RazorFieldConfigModel GetName() => new(nameof(BundleModel.Name), TextAlign.Left, LTable.Name);
        public static RazorFieldConfigModel GetWeight() => new(nameof(BundleModel.Weight), TextAlign.Center, LTable.BundleWeight);
    }

    public static class BundleFk
	{
        public static RazorFieldConfigModel GetBoxName() => new(nameof(PluNestingFkModel.Box.Name), TextAlign.Center, LTable.BundleCount);
        public static RazorFieldConfigModel GetBundleCount() => new(nameof(PluNestingFkModel.BundleCount), TextAlign.Center, LTable.BundleCount);
    }

    public static class PluBundleFk
	{
		public static RazorFieldConfigModel GetWeightTare() => new("0", TextAlign.Center, LTable.WeightShort);
	}

	public static class Plu
	{
		public static RazorFieldConfigModel GetNumber() => new(nameof(PluModel.Number), TextAlign.Center, LTable.Number);
		public static RazorFieldConfigModel GetShelfLifeDays() => new(nameof(PluModel.ShelfLifeDays), TextAlign.Center, LTable.ShelfLifeDaysShort);
        public static RazorFieldConfigModel GetCode() => new(nameof(PluModel.Code), TextAlign.Center, LTable.Code);
    }

    public static class PluScale
	{
		public static RazorFieldConfigModel GetScaleNumber() => new(nameof(PluScaleModel.Scale.Number), TextAlign.Left, LTable.NumberShort);
		public static RazorFieldConfigModel GetPluNumber() => new(nameof(PluScaleModel.Plu.Number), TextAlign.Left, LTable.NumberShort);
		public static RazorFieldConfigModel GetActive() => new(nameof(PluScaleModel.IsActive), TextAlign.Left, LTable.ActiveShort, "bool");
	}

	public static class Printer
	{
		public static RazorFieldConfigModel GetIp() => new(nameof(PrinterModel.Ip), TextAlign.Left, LocaleCore.Print.Ip);
		public static RazorFieldConfigModel GetMacAddress() => new(nameof(PrinterModel.MacAddress), TextAlign.Left, LocaleCore.Print.Mac);
		public static RazorFieldConfigModel GetPrinterType() => new(new PrinterTypeModel(), $"{nameof(PrinterModel.PrinterType)}.{nameof(PrinterTypeModel.Name)}", TextAlign.Left, LocaleCore.Print.Type, "string");
	}

	public static class PrinterResource
	{
		public static RazorFieldConfigModel GetName() => new(new PrinterResourceModel(), $"{nameof(PrinterResourceModel.TemplateResource)}.{nameof(TemplateResourceModel.Name)}", TextAlign.Left, LocaleCore.Print.TemplateResource, "string");
		public static RazorFieldConfigModel GetPrinter() => new(new PrinterModel(), $"{nameof(PrinterResourceModel.Printer)}.{nameof(PrinterModel.Name)}", TextAlign.Left, LocaleCore.Print.Name, "string");
	}

	public static class ProductionFacility
	{
		public static RazorFieldConfigModel GetAddress() => new(nameof(ProductionFacilityModel.Address), TextAlign.Left, LTable.Address);
	}

	public static class Scale
	{
		public static RazorFieldConfigModel GetNumber() => new($"{nameof(ScaleModel.Number)}", TextAlign.Center, LTable.Number);
		public static RazorFieldConfigModel GetPrinterMain() => new(new PrinterModel(), $"{nameof(ScaleModel.PrinterMain)}.{nameof(ScaleModel.PrinterMain.Name)}",
			TextAlign.Left, LocaleCore.Print.NameMain, "string");
		public static RazorFieldConfigModel GetPrinterShipping() => new(new PrinterModel(), $"{nameof(ScaleModel.PrinterShipping)}.{nameof(ScaleModel.PrinterShipping.Name)}",
			TextAlign.Left, LocaleCore.Print.NameShipping, "string");
		public static RazorFieldConfigModel GetWorkShop() => new(new WorkShopModel(), $"{nameof(ScaleModel.WorkShop)}.{nameof(WorkShopModel.Name)}",
			TextAlign.Left, LTable.WorkShop, "string");
    }

    public static class Version
	{
		public static RazorFieldConfigModel GetReleaseDt() => new(nameof(VersionModel.ReleaseDt), TextAlign.Center, LTable.ReleaseDt);
		public static RazorFieldConfigModel GetVersion() => new(nameof(VersionModel.Version), TextAlign.Center, LTable.Version);
	}

	public static class WorkShop
	{
		public static RazorFieldConfigModel GetProductionFacility() => new(new ProductionFacilityModel(), $"{nameof(WorkShopModel.ProductionFacility)}.{nameof(ProductionFacilityModel.Name)}", TextAlign.Left, LTable.ProductionFacility, "string");
	}
}