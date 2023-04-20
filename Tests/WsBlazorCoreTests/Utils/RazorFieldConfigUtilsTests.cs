// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using WsBlazorCore.Razors;
using WsBlazorCore.Utils;

namespace WsBlazorCoreTests.Utils;

[TestFixture]
public sealed class RazorFieldConfigUtilsTests
{
	#region Public and private fields, properties, constructor

	private BlazorCoreHelper BlazorCore { get; } = BlazorCoreHelper.Instance;

	#endregion

	#region Public and private methods

	[Test]
	public void Base_Get_DoesNotThrow()
	{
		Assert.DoesNotThrow(() =>
		{
			RazorFieldConfigModel razorFieldConfig = RazorFieldConfigUtils.Base.GetCreateDt();
			TestContext.WriteLine(razorFieldConfig);
			
            razorFieldConfig = RazorFieldConfigUtils.Base.GetChangeDt();
			TestContext.WriteLine(razorFieldConfig);
			
            razorFieldConfig = RazorFieldConfigUtils.Base.GetDescription();
			TestContext.WriteLine(razorFieldConfig);
		});
	}

	[Test]
	public void Access_Get_DoesNotThrow()
	{
		Assert.DoesNotThrow(() =>
		{
			// Arrange & Act & Assert.
			RazorFieldConfigModel razorFieldConfig = RazorFieldConfigUtils.Access.GetRights();
			TestContext.WriteLine(razorFieldConfig);
			// Arrange & Act & Assert.
			razorFieldConfig = RazorFieldConfigUtils.Base.GetName(LocaleCore.Table.User);
			TestContext.WriteLine(razorFieldConfig);
		});
	}

	[Test]
	public void BarCode_Get_DoesNotThrow()
	{
		Assert.DoesNotThrow(() =>
		{
			// Arrange & Act & Assert.
			RazorFieldConfigModel razorFieldConfig = RazorFieldConfigUtils.BarCode.GetValueTop();
			TestContext.WriteLine(razorFieldConfig);
		});
	}

	[Test]
	public void Plu_Get_DoesNotThrow()
	{
		Assert.DoesNotThrow(() =>
		{
			// Arrange & Act & Assert.
			RazorFieldConfigModel razorFieldConfig = RazorFieldConfigUtils.Base.GetName();
			TestContext.WriteLine(razorFieldConfig);
			// Arrange & Act & Assert.
			razorFieldConfig = RazorFieldConfigUtils.Plu.GetShelfLifeDays();
			TestContext.WriteLine(razorFieldConfig);
            // Arrange & Act & Assert.
            //razorFieldConfig = RazorFieldConfigUtils.Plu.GetWeightTare();
            //TestContext.WriteLine(razorFieldConfig);
            // Arrange & Act & Assert.
            //razorFieldConfig = RazorFieldConfigUtils.PluNestingFk.GetBundleCount();
			//TestContext.WriteLine(razorFieldConfig);
		});
	}

	[Test]
	public void Scale_Get_DoesNotThrow()
	{
		Assert.DoesNotThrow(() =>
		{
			RazorComponentBase razorPage = BlazorCore.CreateNewSubstituteRazorComponentBase();
			//DeviceScaleFkModel host = BlazorCore.DataCore.CreateNewSubstitute<HostModel>(true);
			PrinterModel printer = BlazorCore.DataCore.CreateNewSubstitute<PrinterModel>(true);
			WorkShopModel workShop = BlazorCore.DataCore.CreateNewSubstitute<WorkShopModel>(true);
			// Arrange & Act & Assert.
			RazorFieldConfigModel razorFieldConfig = RazorFieldConfigUtils.Scale.GetNumber();
			TestContext.WriteLine(razorFieldConfig);
			// Arrange & Act & Assert.
			razorFieldConfig = RazorFieldConfigUtils.Base.GetDescription();
			TestContext.WriteLine(razorFieldConfig);
			// Arrange & Act & Assert.
			//razorFieldConfig = RazorFieldConfigUtils.Scale.GetDeviceIp();
			TestContext.WriteLine(razorFieldConfig);
			// Arrange & Act & Assert.
			//razorFieldConfig = RazorFieldConfigUtils.Scale.GetHost(razorPage.GetRouteItemPath(host));
			TestContext.WriteLine(razorFieldConfig);
			// Arrange & Act & Assert.
			razorFieldConfig = RazorFieldConfigUtils.Scale.GetPrinterMain();
			TestContext.WriteLine(razorFieldConfig);
			// Arrange & Act & Assert.
			razorFieldConfig = RazorFieldConfigUtils.Scale.GetPrinterShipping();
			TestContext.WriteLine(razorFieldConfig);
			// Arrange & Act & Assert.
			razorFieldConfig = RazorFieldConfigUtils.Scale.GetWorkShop();
			TestContext.WriteLine(razorFieldConfig);
		});
	}

	[Test]
	public void Version_Get_DoesNotThrow()
	{
		Assert.DoesNotThrow(() =>
		{
			// Arrange & Act & Assert.
			RazorFieldConfigModel razorFieldConfig = RazorFieldConfigUtils.Scale.GetNumber();
			TestContext.WriteLine(razorFieldConfig);
			// Arrange & Act & Assert.
			razorFieldConfig = RazorFieldConfigUtils.Base.GetDescription();
			TestContext.WriteLine(razorFieldConfig);
			// Arrange & Act & Assert.
			razorFieldConfig = RazorFieldConfigUtils.Version.GetReleaseDt();
			TestContext.WriteLine(razorFieldConfig);
			// Arrange & Act & Assert.
			razorFieldConfig = RazorFieldConfigUtils.Version.GetVersion();
			TestContext.WriteLine(razorFieldConfig);
		});
	}

	#endregion
}
