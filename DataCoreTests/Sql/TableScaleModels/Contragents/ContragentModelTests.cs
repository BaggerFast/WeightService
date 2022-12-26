// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore.Sql.TableScaleModels.Contragents;

namespace DataCoreTests.Sql.TableScaleModels.Contragents;

[TestFixture]
internal class ContragentModelTests
{
    private static DataCoreHelper DataCore => DataCoreHelper.Instance;
    
    [Test]
    public void Model_AssertSqlFields_Check()
    {
        DataCore.AssertSqlPropertyCheckDt<ContragentModel>(nameof(ContragentModel.CreateDt));
        DataCore.AssertSqlPropertyCheckDt<ContragentModel>(nameof(ContragentModel.ChangeDt));
        DataCore.AssertSqlPropertyCheckBool<ContragentModel>(nameof(SqlTableBase.IsMarked));
    }

    [Test]
    public void Model_ToString()
    {
        DataCore.TableBaseModelAssertToString<ContragentModel>();
    }

    [Test]
    public void Model_EqualsNew()
    {
        DataCore.TableBaseModelAssertEqualsNew<ContragentModel>();
    }

    [Test]
    public void Model_Serialize()
    {
        DataCore.TableBaseModelAssertSerialize<ContragentModel>();
    }
}