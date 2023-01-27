﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore.Sql.TableScaleModels.Clips;

namespace DataCoreTests.Sql.TableScaleModels.Clips;

[TestFixture]
internal class ClipContentTests
{
    private static DataCoreHelper DataCore => DataCoreHelper.Instance;

    [Test]
    public void Model_Validate_Content()
    {
        DataCore.AssertSqlDbContentValidate<ClipModel>();
    }
}