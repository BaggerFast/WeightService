﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace DataCoreTests.Sql.Core;

[TestFixture]
internal class DataAcessExtTests
{
	#region Public and private fields, properties, constructor

	private DataCoreHelper DataCore { get; } = DataCoreHelper.Instance;

	#endregion

	#region Public and private methods

	[Test]
	public void DataAccess_GetListPluScales_CountExists()
	{
		DataCore.AssertAction(() =>
		{
			// Arrange.
			List<ScaleModel> scales = DataCore.DataAccess.GetListScales(true, false, false);
			TestContext.WriteLine($"{nameof(scales)}.{nameof(scales.Count)}: {scales.Count}");
			// Assert.
			Assert.IsTrue(scales.Count > 0);
			foreach (ScaleModel scale in scales)
			{
				if (scale.IdentityValueId == 5)
				{
					TestContext.WriteLine($"{nameof(scale)}: {scale.IdentityValueId} | {scale}");
					List<PluScaleModel> pluScales = DataCore.DataAccess.GetListPluScales(scale, 
						false, true, true);
					// Act.
					TestContext.WriteLine($"{nameof(pluScales)}.{nameof(pluScales.Count)}: {pluScales.Count}");
				}
			}
		});
	}

	[Test]
	public void DataAccess_GetListPluPackages_CountExists()
	{
		DataCore.AssertAction(() =>
		{
			// Arrange.
			List<PluModel> plus = DataCore.DataAccess.GetListPlus(true, false, false);
			TestContext.WriteLine($"{nameof(plus)}.{nameof(plus.Count)}: {plus.Count}");
			// Assert.
			Assert.IsTrue(plus.Count > 0);
			foreach (PluModel plu in plus)
			{
				if (plu.Number == 113)
				{
					TestContext.WriteLine($"{nameof(plu)}: {plu.IdentityValueId} | {plu}");
					List<PluPackageModel> pluPackages = DataCore.DataAccess.GetListPluPackages(
						plu, false, false, false);
					// Act.
					TestContext.WriteLine($"{nameof(pluPackages)}.{nameof(pluPackages.Count)}: {pluPackages.Count}");
				}
			}
		});
	}

	#endregion
}
