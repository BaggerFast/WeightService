// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore.Sql.TableScaleFkModels.NomenclaturesCharacteristicsFks;

namespace DataCoreTests.Sql.TableScaleFkModels.NomenclaturesCharacteristicsFks;

[TestFixture]
internal class NomenclatureCharacteristicsFkContentTests
{
	[Test]
    public void Item_Content_Validate()
    {
		DataCoreTestsUtils.DataCore.AssertSqlDbContentValidate<NomenclaturesCharacteristicsFkModel>();
	}
}