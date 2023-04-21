﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace WsStorageCoreTests.TableScaleModels.Boxes;

[TestFixture]
public sealed class BoxValidatorTests
{
    [Test]
    public void Model_Validate_IsFalse()
    {
        BoxModel item = WsTestsUtils.DataTests.CreateNewSubstitute<BoxModel>(false);
        WsTestsUtils.DataTests.AssertSqlValidate(item, false);
    }

    [Test]
    public void Model_Validate_IsTrue()
    {
        BoxModel item = WsTestsUtils.DataTests.CreateNewSubstitute<BoxModel>(true);
        WsTestsUtils.DataTests.AssertSqlValidate(item, true);
    }
}