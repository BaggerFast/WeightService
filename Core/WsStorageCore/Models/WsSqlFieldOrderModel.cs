// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace WsStorageCore.Models;

/// <summary>
/// SQL order model.
/// </summary>
[DebuggerDisplay("{ToString()}")]
public sealed record WsSqlFieldOrderModel(string Name, WsSqlEnumOrder Direction)
{
    public override int GetHashCode() => (Name.ToUpper(), Direction).GetHashCode();

    public override string ToString() => $"{Name} {Direction}";
}