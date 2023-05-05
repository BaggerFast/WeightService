// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace WsStorageCoreTests.Fields;

[TestFixture]
public sealed class FieldMacAddressModelTests
{
    [Test]
    public void MacEntityTests_Ctor_DoesNotThrow()
    {
        Assert.DoesNotThrowAsync(async () => await Task.Run(() =>
        {
	        foreach (string? address in DataCoreEnums.GetString())
	        {
                if (address is not null)
					_ = new WsSqlFieldMacAddressModel(address);
	        }
        }));
    }
}