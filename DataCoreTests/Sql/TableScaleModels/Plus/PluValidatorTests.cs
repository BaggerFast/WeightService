﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore.Sql.TableScaleModels.Plus;

namespace DataCoreTests.Sql.TableScaleModels.Plus;

[TestFixture]
internal class PluValidatorTests
{
    [Test]
    public void Model_Validate_IsFalse()
    {
        PluModel item = DataCoreTestsUtils.DataCore.CreateNewSubstitute<PluModel>(false);
        DataCoreTestsUtils.DataCore.AssertSqlValidate(item, false);
    }

    [Test]
    public void Model_Validate_IsTrue()
    {
        PluModel item = DataCoreTestsUtils.DataCore.CreateNewSubstitute<PluModel>(true);
        DataCoreTestsUtils.DataCore.AssertSqlValidate(item, true);
    }
}