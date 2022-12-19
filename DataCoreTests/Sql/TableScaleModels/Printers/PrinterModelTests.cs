// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore.Sql.TableScaleModels.Printers;

namespace DataCoreTests.Sql.TableScaleModels.Printers;

[TestFixture]
internal class PrinterModelTests
{
    private static DataCoreHelper DataCore => DataCoreHelper.Instance;

    [Test]
    public void Model_ToString()
    {
        DataCore.TableBaseModelAssertToString<PrinterModel>();
    }

    [Test]
    public void Model_EqualsNew()
    {
        DataCore.TableBaseModelAssertEqualsNew<PrinterModel>();
    }
}