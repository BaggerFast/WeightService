// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore.Sql.TableScaleModels.PlusCharacteristics;

namespace DataCoreTests.Sql.TableScaleModels.NomenclaturesCharacteristics;

[TestFixture]
internal class NomenclaturesCharacteristicModelTests
{
    [Test]
    public void Model_AssertSqlFields_Check()
    {
        DataCoreTestsUtils.DataCore.AssertSqlPropertyCheckDt<PluCharacteristicModel>(nameof(SqlTableBase.CreateDt));
        DataCoreTestsUtils.DataCore.AssertSqlPropertyCheckDt<PluCharacteristicModel>(nameof(SqlTableBase.ChangeDt));
        DataCoreTestsUtils.DataCore.AssertSqlPropertyCheckBool<PluCharacteristicModel>(nameof(SqlTableBase.IsMarked));
    }

    [Test]
    public void Model_ToString()
    {
        DataCoreTestsUtils.DataCore.TableBaseModelAssertToString<PluCharacteristicModel>();
    }

    [Test]
    public void Model_EqualsNew()
    {
        DataCoreTestsUtils.DataCore.TableBaseModelAssertEqualsNew<PluCharacteristicModel>();
    }

    [Test]
    public void Model_Serialize()
    {
        DataCoreTestsUtils.DataCore.TableBaseModelAssertSerialize<PluCharacteristicModel>();
    }
}