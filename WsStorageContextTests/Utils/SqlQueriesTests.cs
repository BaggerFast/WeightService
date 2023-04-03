// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore.Enums;
using DataCore.Sql.Core.Utils;
using DataCore.Sql.TableScaleFkModels.Aggregations;

namespace WsStorageContextTests.Utils;

[TestFixture]
internal class SqlQueriesTests
{
    [Test]
    public void SqlQueries_GetWeighingsAggrWithPlu_MoreThanZero()
    {
        DataCoreTestsUtils.DataCore.AssertAction(() =>
        {
            List<PluAggrModel> pluWeighingAggrs = new();
            object[] objects = DataCoreTestsUtils.DataCore.DataAccess.GetArrayObjectsNotNullable(
                SqlQueries.DbScales.Tables.PluWeighings.GetWeighingsAggrWithPlu(200));
            Assert.That(objects.Any());
            foreach (object obj in objects)
            {
                if (obj is object[] { Length: 5 } item)
                {
                    pluWeighingAggrs.Add(new(Convert.ToDateTime(item[0]),
                        Convert.ToInt32(item[1]), Convert.ToString(item[2]) ?? string.Empty,
                        Convert.ToString(item[3]) ?? string.Empty, Convert.ToString(item[4]) ?? string.Empty)
                    );
                }
            }
            for (int i = 0; i < 5; i++)
            {
                if (i < pluWeighingAggrs.Count)
                    TestContext.WriteLine(pluWeighingAggrs[i]);
            }
        }, false, new() { Configuration.DevelopVS, Configuration.ReleaseVS });
    }
    
    [Test]
    public void SqlQueries_GetWeighingsAggrWithoutPlu_MoreThanZero()
    {
        DataCoreTestsUtils.DataCore.AssertAction(() =>
        {
            List<PluAggrModel> pluWeighingAggrs = new();
            object[] objects = DataCoreTestsUtils.DataCore.DataAccess.GetArrayObjectsNotNullable(
                SqlQueries.DbScales.Tables.PluWeighings.GetWeighingsAggrWithoutPlu(200));
            Assert.That(objects.Any());
            foreach (object obj in objects)
            {
                if (obj is object[] { Length: 4 } item)
                {
                    pluWeighingAggrs.Add(new(Convert.ToDateTime(item[0]),
                        Convert.ToInt32(item[1]), Convert.ToString(item[2]) ?? string.Empty,
                        Convert.ToString(item[3]) ?? string.Empty)
                    );
                }
            }
            for (int i = 0; i < 5; i++)
            {
                if (i < pluWeighingAggrs.Count)
                    TestContext.WriteLine(pluWeighingAggrs[i]);
            }
        }, false, new() { Configuration.DevelopVS, Configuration.ReleaseVS });
    }

    [Test]
    public void SqlQueries_GetLabelsAggrWithPlu_MoreThanZero()
    {
        DataCoreTestsUtils.DataCore.AssertAction(() =>
        {
            List<PluAggrModel> pluAggrs = new();
            object[] objects = DataCoreTestsUtils.DataCore.DataAccess.GetArrayObjectsNotNullable(
                SqlQueries.DbScales.Tables.PluLabels.GetLabelsAggrWithPlu(200));
            Assert.That(objects.Any());
            foreach (object obj in objects)
            {
                if (obj is object[] { Length: 5 } item)
                {
                    pluAggrs.Add(new(Convert.ToDateTime(item[0]),
                        Convert.ToInt32(item[1]), Convert.ToString(item[2]) ?? string.Empty,
                        Convert.ToString(item[3]) ?? string.Empty, Convert.ToString(item[4]) ?? string.Empty)
                    );
                }
            }
            for (int i = 0; i < 5; i++)
            {
                if (i < pluAggrs.Count)
                    TestContext.WriteLine(pluAggrs[i]);
            }
        }, false, new() { Configuration.DevelopVS, Configuration.ReleaseVS });
    }

    [Test]
    public void SqlQueries_GetLabelsAggrWithoutPlu_MoreThanZero()
    {
        DataCoreTestsUtils.DataCore.AssertAction(() =>
        {
            List<PluAggrModel> pluWeighingAggrs = new();
            object[] objects = DataCoreTestsUtils.DataCore.DataAccess.GetArrayObjectsNotNullable(
                SqlQueries.DbScales.Tables.PluLabels.GetLabelsAggrWithoutPlu(200));
            Assert.That(objects.Any());
            foreach (object obj in objects)
            {
                if (obj is object[] { Length: 4 } item)
                {
                    pluWeighingAggrs.Add(new(Convert.ToDateTime(item[0]),
                        Convert.ToInt32(item[1]), Convert.ToString(item[2]) ?? string.Empty,
                        Convert.ToString(item[3]) ?? string.Empty)
                    );
                }
            }
            for (int i = 0; i < 5; i++)
            {
                if (i < pluWeighingAggrs.Count)
                    TestContext.WriteLine(pluWeighingAggrs[i]);
            }
        }, false, new() { Configuration.DevelopVS, Configuration.ReleaseVS });
    }
}