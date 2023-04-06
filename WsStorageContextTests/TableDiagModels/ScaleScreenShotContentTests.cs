// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore.Sql.TableDiagModels.ScalesScreenshots;

namespace WsStorageContextTests.TableDiagModels;

[TestFixture]
internal class ScaleScreenShotContentTests
{
    [Test]
    public void Model_Content_Validate()
    {
        DataCoreTestsUtils.DataCore.AssertSqlDbContentValidate<ScaleScreenShotModel>();
    }
}