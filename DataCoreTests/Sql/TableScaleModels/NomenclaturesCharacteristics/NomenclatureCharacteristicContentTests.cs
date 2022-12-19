// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore.Sql.TableScaleModels.NomenclaturesCharacteristics;

namespace DataCoreTests.Sql.TableScaleModels.NomenclaturesCharacteristics;

[TestFixture]
internal class NomenclaturesCharacteristicContentTests
{
    private static DataCoreHelper DataCore => DataCoreHelper.Instance;

	[Test]
	public void Model_Content_Validate()
	{
		DataCore.AssertSqlDbContentValidate<NomenclaturesCharacteristicsModel>();
	}
}