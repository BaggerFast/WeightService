// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore.Sql.TableScaleModels.Orders;

namespace DataCoreTests.Sql.TableScaleModels.Orders;

[TestFixture]
internal class OrderModelTests
{
    private static DataCoreHelper DataCore => DataCoreHelper.Instance;
    
    [Test]
    public void Model_AssertSqlFields_Check()
    {
        DataCore.AssertSqlPropertyCheckDt<OrderModel>(nameof(OrderModel.CreateDt));
        DataCore.AssertSqlPropertyCheckDt<OrderModel>(nameof(OrderModel.ChangeDt));
        DataCore.AssertSqlPropertyCheckBool<OrderModel>(nameof(SqlTableBase.IsMarked));
    }

    [Test]
    public void Model_ToString()
    {
        DataCore.TableBaseModelAssertToString<OrderModel>();
    }
    
    [Test]
    public void Model_EqualsNew()
    {
        DataCore.TableBaseModelAssertEqualsNew<OrderModel>();
    }

    [Test]
    public void Model_Serialize()
    {
        DataCore.TableBaseModelAssertSerialize<OrderModel>();
    }
}