// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore.Sql.TableScaleModels.Nomenclatures;

namespace DataCoreTests.Sql.TableScaleModels.NomenclaturesV2;

[TestFixture]
internal class NomenclatureV2ModelTests
{
    private static DataCoreHelper DataCore => DataCoreHelper.Instance;

    [Test]
    public void Model_AssertSqlFields_Check()
    {
        DataCore.AssertSqlPropertyCheckDt<NomenclatureV2Model>(nameof(SqlTableBase.CreateDt));
        DataCore.AssertSqlPropertyCheckDt<NomenclatureV2Model>(nameof(SqlTableBase.ChangeDt));
        DataCore.AssertSqlPropertyCheckBool<NomenclatureV2Model>(nameof(SqlTableBase.IsMarked));
    }

    [Test]
    public void Model_ToString()
    {
        DataCore.TableBaseModelAssertToString<NomenclatureV2Model>();
    }

    [Test]
    public void Model_EqualsNew()
    {
        DataCore.TableBaseModelAssertEqualsNew<NomenclatureV2Model>();
    }

    [Test]
    public void Model_Serialize()
    {
        DataCore.TableBaseModelAssertSerialize<NomenclatureV2Model>();
    }
}