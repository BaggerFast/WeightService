﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore.Sql.TableScaleFkModels.DeviceScalesFks;
using DataCore.Sql.TableScaleFkModels.DeviceTypesFks;
using DataCore.Sql.TableScaleFkModels.NomenclaturesCharacteristicsFks;
using DataCore.Sql.TableScaleFkModels.NomenclaturesGroupsFks;
using DataCore.Sql.TableScaleFkModels.PlusBundlesFks;
using DataCore.Sql.TableScaleFkModels.PlusTemplatesFks;
using DataCore.Sql.TableScaleModels.Access;
using DataCore.Sql.TableScaleModels.Apps;
using DataCore.Sql.TableScaleModels.BarCodes;
using DataCore.Sql.TableScaleModels.Boxes;
using DataCore.Sql.TableScaleModels.Brands;
using DataCore.Sql.TableScaleModels.Bundles;
using DataCore.Sql.TableScaleModels.Clips;
using DataCore.Sql.TableScaleModels.Contragents;
using DataCore.Sql.TableScaleModels.Devices;
using DataCore.Sql.TableScaleModels.DeviceTypes;
using DataCore.Sql.TableScaleModels.Logs;
using DataCore.Sql.TableScaleModels.LogsTypes;
using DataCore.Sql.TableScaleModels.NomenclaturesCharacteristics;
using DataCore.Sql.TableScaleModels.Orders;
using DataCore.Sql.TableScaleModels.OrdersWeighings;
using DataCore.Sql.TableScaleModels.Organizations;
using DataCore.Sql.TableScaleModels.Plus;
using DataCore.Sql.TableScaleModels.PlusGroups;
using DataCore.Sql.TableScaleModels.PlusLabels;
using DataCore.Sql.TableScaleModels.PlusScales;
using DataCore.Sql.TableScaleModels.PlusWeighings;
using DataCore.Sql.TableScaleModels.Printers;
using DataCore.Sql.TableScaleModels.PrintersResources;
using DataCore.Sql.TableScaleModels.PrintersTypes;
using DataCore.Sql.TableScaleModels.ProductionFacilities;
using DataCore.Sql.TableScaleModels.ProductSeries;
using DataCore.Sql.TableScaleModels.Scales;
using DataCore.Sql.TableScaleModels.ScalesScreenshots;
using DataCore.Sql.TableScaleModels.Tasks;
using DataCore.Sql.TableScaleModels.TasksTypes;
using DataCore.Sql.TableScaleModels.Templates;
using DataCore.Sql.TableScaleModels.TemplatesResources;
using DataCore.Sql.TableScaleModels.Versions;
using DataCore.Sql.TableScaleModels.WorkShops;
using FluentNHibernate.Cfg;
using NHibernate;

namespace DataCoreTests.Sql.Core.Helpers;

[TestFixture]
internal class DataAccessHelperMapTests
{
    #region Public and private methods

    [Test]
    public void DataAccess_SetFluentConfigurationForTest()
    {
        DataCoreTestsUtils.DataCore.AssertAction(() =>
        {
            if (DataCoreTestsUtils.DataAccess.SqlConfiguration is null)
                throw new ArgumentNullException(nameof(DataCoreTestsUtils.DataAccess.SqlConfiguration));

            FluentConfiguration fluentConfiguration = Fluently.Configure().Database(DataCoreTestsUtils.DataAccess.SqlConfiguration);
            DataCoreTestsUtils.DataAccess.AddConfigurationMappings(fluentConfiguration);
            fluentConfiguration.ExposeConfiguration(cfg => cfg.SetProperty("hbm2ddl.keywords", "auto-quote"));
            ISessionFactory sessionFactory = fluentConfiguration.BuildSessionFactory();
            sessionFactory.OpenSession();
            sessionFactory.Close();
            sessionFactory.Dispose();

        }, false);
    }

    [Test]
    public void DataAccess_Map_DoesNotThrow()
    {
        Assert.DoesNotThrow(() =>
        {
            List<Type> sqlTableMaps = DataCoreTestsUtils.DataCore.DataContext.GetTableMaps();
            foreach (Type sqlTableMap in sqlTableMaps)
            {
                TestContext.WriteLine(sqlTableMap);
            }
        });
    }

    [Test]
    public void DataAccess_AccessMap_DoesNotThrow()
    {
        Assert.DoesNotThrow(() =>
        {
            AccessMap item = new();
            TestContext.WriteLine(item);
        });
    }

    [Test]
    public void DataAccess_AppMap_DoesNotThrow()
    {
        Assert.DoesNotThrow(() =>
        {
            AppMap item = new();
            TestContext.WriteLine(item);
        });
    }

    [Test]
    public void DataAccess_BarCodeMap_DoesNotThrow()
    {
        Assert.DoesNotThrow(() =>
        {
            BarCodeMap item = new();
            TestContext.WriteLine(item);
        });
    }

    [Test]
    public void DataAccess_BoxMap_DoesNotThrow()
    {
        Assert.DoesNotThrow(() =>
        {
            BoxMap item = new();
            TestContext.WriteLine(item);
        });
    }

    [Test]
    public void DataAccess_BrandMap_DoesNotThrow()
    {
        Assert.DoesNotThrow(() =>
        {
            BrandMap item = new();
            TestContext.WriteLine(item);
        });
    }

    [Test]
    public void DataAccess_BundleMap_DoesNotThrow()
    {
        Assert.DoesNotThrow(() =>
        {
            BundleMap item = new();
            TestContext.WriteLine(item);
        });
    }

    [Test]
    public void DataAccess_ClipMap_DoesNotThrow()
    {
        Assert.DoesNotThrow(() =>
        {
            ClipMap item = new();
            TestContext.WriteLine(item);
        });
    }

    [Test]
    public void DataAccess_ContragentMap_DoesNotThrow()
    {
        Assert.DoesNotThrow(() =>
        {
            ContragentMap item = new();
            TestContext.WriteLine(item);
        });
    }

    [Test]
    public void DataAccess_DeviceMap_DoesNotThrow()
    {
        Assert.DoesNotThrow(() =>
        {
            DeviceMap item = new();
            TestContext.WriteLine(item);
        });
    }

    [Test]
    public void DataAccess_DeviceScaleFkMap_DoesNotThrow()
    {
        Assert.DoesNotThrow(() =>
        {
            DeviceScaleFkMap item = new();
            TestContext.WriteLine(item);
        });
    }

    [Test]
    public void DataAccess_DeviceTypeFkMap_DoesNotThrow()
    {
        Assert.DoesNotThrow(() =>
        {
            DeviceTypeFkMap item = new();
            TestContext.WriteLine(item);
        });
    }

    [Test]
    public void DataAccess_DeviceTypeMap_DoesNotThrow()
    {
        Assert.DoesNotThrow(() =>
        {
            DeviceTypeMap item = new();
            TestContext.WriteLine(item);
        });
    }

    [Test]
    public void DataAccess_LogMap_DoesNotThrow()
    {
        Assert.DoesNotThrow(() =>
        {
            LogMap item = new();
            TestContext.WriteLine(item);
        });
    }

    [Test]
    public void DataAccess_LogTypeMap_DoesNotThrow()
    {
        Assert.DoesNotThrow(() =>
        {
            LogTypeMap item = new();
            TestContext.WriteLine(item);
        });
    }

    [Test]
    public void DataAccess_PluGroupMap_DoesNotThrow()
    {
        Assert.DoesNotThrow(() =>
        {
            PluGroupMap item = new();
            TestContext.WriteLine(item);
        });
    }

    [Test]
    public void DataAccess_NomenclaturesCharacteristicsFkMap_DoesNotThrow()
    {
        Assert.DoesNotThrow(() =>
        {
            NomenclaturesCharacteristicsFkMap item = new();
            TestContext.WriteLine(item);
        });
    }

    [Test]
    public void DataAccess_NomenclaturesCharacteristicsMap_DoesNotThrow()
    {
        Assert.DoesNotThrow(() =>
        {
            NomenclaturesCharacteristicsMap item = new();
            TestContext.WriteLine(item);
        });
    }

    [Test]
    public void DataAccess_NomenclaturesGroupFkMap_DoesNotThrow()
    {
        Assert.DoesNotThrow(() =>
        {
            NomenclaturesGroupFkMap item = new();
            TestContext.WriteLine(item);
        });
    }

    [Test]
    public void DataAccess_OrderMap_DoesNotThrow()
    {
        Assert.DoesNotThrow(() =>
        {
            OrderMap item = new();
            TestContext.WriteLine(item);
        });
    }

    [Test]
    public void DataAccess_OrderWeighingMap_DoesNotThrow()
    {
        Assert.DoesNotThrow(() =>
        {
            OrderWeighingMap item = new();
            TestContext.WriteLine(item);
        });
    }

    [Test]
    public void DataAccess_OrganizationMap_DoesNotThrow()
    {
        Assert.DoesNotThrow(() =>
        {
            OrganizationMap item = new();
            TestContext.WriteLine(item);
        });
    }

    [Test]
    public void DataAccess_PluBundleFkMap_DoesNotThrow()
    {
        Assert.DoesNotThrow(() =>
        {
            PluBundleFkMap item = new();
            TestContext.WriteLine(item);
        });
    }

    [Test]
    public void DataAccess_PluLabelMap_DoesNotThrow()
    {
        Assert.DoesNotThrow(() =>
        {
            PluLabelMap item = new();
            TestContext.WriteLine(item);
        });
    }

    [Test]
    public void DataAccess_PluMap_DoesNotThrow()
    {
        Assert.DoesNotThrow(() =>
        {
            PluMap item = new();
            TestContext.WriteLine(item);
        });
    }

    [Test]
    public void DataAccess_PluScaleMap_DoesNotThrow()
    {
        Assert.DoesNotThrow(() =>
        {
            PluScaleMap item = new();
            TestContext.WriteLine(item);
        });
    }

    [Test]
    public void DataAccess_PluTemplateFkMap_DoesNotThrow()
    {
        Assert.DoesNotThrow(() =>
        {
            PluTemplateFkMap item = new();
            TestContext.WriteLine(item);
        });
    }

    [Test]
    public void DataAccess_PluWeighingMap_DoesNotThrow()
    {
        Assert.DoesNotThrow(() =>
        {
            PluWeighingMap item = new();
            TestContext.WriteLine(item);
        });
    }

    [Test]
    public void DataAccess_PrinterMap_DoesNotThrow()
    {
        Assert.DoesNotThrow(() =>
        {
            PrinterMap item = new();
            TestContext.WriteLine(item);
        });
    }

    [Test]
    public void DataAccess_PrinterResourceMap_DoesNotThrow()
    {
        Assert.DoesNotThrow(() =>
        {
            PrinterResourceMap item = new();
            TestContext.WriteLine(item);
        });
    }

    [Test]
    public void DataAccess_PrinterTypeMap_DoesNotThrow()
    {
        Assert.DoesNotThrow(() =>
        {
            PrinterTypeMap item = new();
            TestContext.WriteLine(item);
        });
    }

    [Test]
    public void DataAccess_ProductionFacilityMap_DoesNotThrow()
    {
        Assert.DoesNotThrow(() =>
        {
            ProductionFacilityMap item = new();
            TestContext.WriteLine(item);
        });
    }

    [Test]
    public void DataAccess_ProductSeriesMap_DoesNotThrow()
    {
        Assert.DoesNotThrow(() =>
        {
            ProductSeriesMap item = new();
            TestContext.WriteLine(item);
        });
    }

    [Test]
    public void DataAccess_ScaleMap_DoesNotThrow()
    {
        Assert.DoesNotThrow(() =>
        {
            ScaleMap item = new();
            TestContext.WriteLine(item);
        });
    }

    [Test]
    public void DataAccess_ScaleScreenShotMap_DoesNotThrow()
    {
        Assert.DoesNotThrow(() =>
        {
            ScaleScreenShotMap item = new();
            TestContext.WriteLine(item);
        });
    }

    [Test]
    public void DataAccess_TaskMap_DoesNotThrow()
    {
        Assert.DoesNotThrow(() =>
        {
            TaskMap item = new();
            TestContext.WriteLine(item);
        });
    }

    [Test]
    public void DataAccess_TaskTypeMap_DoesNotThrow()
    {
        Assert.DoesNotThrow(() =>
        {
            TaskTypeMap item = new();
            TestContext.WriteLine(item);
        });
    }

    [Test]
    public void DataAccess_TemplateMap_DoesNotThrow()
    {
        Assert.DoesNotThrow(() =>
        {
            TemplateMap item = new();
            TestContext.WriteLine(item);
        });
    }

    [Test]
    public void DataAccess_TemplateResourceMap_DoesNotThrow()
    {
        Assert.DoesNotThrow(() =>
        {
            TemplateResourceMap item = new();
            TestContext.WriteLine(item);
        });
    }

    [Test]
    public void DataAccess_VersionMap_DoesNotThrow()
    {
        Assert.DoesNotThrow(() =>
        {
            VersionMap item = new();
            TestContext.WriteLine(item);
        });
    }

    [Test]
    public void DataAccess_WorkShopMap_DoesNotThrow()
    {
        Assert.DoesNotThrow(() =>
        {
            WorkShopMap item = new();
            TestContext.WriteLine(item);
        });
    }

    #endregion
}