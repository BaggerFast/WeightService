// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore.Sql.TableScaleModels.Brands;

namespace DataCoreTests.Sql.TableScaleModels.Brands;

[TestFixture]
internal class BrandContentTests
{
    private static DataCoreHelper DataCore => DataCoreHelper.Instance;

	[Test]
	public void Model_Validate_Content()
	{
		DataCore.AssertSqlDbContentValidate<BrandModel>();
	}
}