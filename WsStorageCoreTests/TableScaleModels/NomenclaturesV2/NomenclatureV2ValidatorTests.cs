﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace WsStorageCoreTests.TableScaleModels.NomenclaturesV2;

[TestFixture]
internal class NomenclaturesV2ValidatorTests
{
    [Test]
    public void Model_Validate_IsFalse()
    {
        NomenclatureV2Model item = DataCoreTestsUtils.DataCore.CreateNewSubstitute<NomenclatureV2Model>(false);
        DataCoreTestsUtils.DataCore.AssertSqlValidate(item, false);
    }

    [Test]
    public void Model_Validate_IsTrue()
    {
        NomenclatureV2Model item = DataCoreTestsUtils.DataCore.CreateNewSubstitute<NomenclatureV2Model>(true);
        DataCoreTestsUtils.DataCore.AssertSqlValidate(item, true);
    }
}