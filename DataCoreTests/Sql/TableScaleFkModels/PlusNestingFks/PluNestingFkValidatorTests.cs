﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore.Sql.TableScaleFkModels.PlusNestingFks;

namespace DataCoreTests.Sql.TableScaleFkModels.PlusNestingFks;

[TestFixture]
internal class PluNestingFkValidatorTests
{
    [Test]
    public void Model_Validate_IsFalse()
    {
        PluNestingFkModel item = DataCoreTestsUtils.DataCore.CreateNewSubstitute<PluNestingFkModel>(false);
        DataCoreTestsUtils.DataCore.AssertSqlValidate(item, false);
    }

    [Test]
    public void Model_Validate_IsTrue()
    {
        PluNestingFkModel item = DataCoreTestsUtils.DataCore.CreateNewSubstitute<PluNestingFkModel>(true);
        DataCoreTestsUtils.DataCore.AssertSqlValidate(item, true);
    }
}