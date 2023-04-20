// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace WsStorageCore.Models;

/// <summary>
/// SQL field comparing model.
/// </summary>
[DebuggerDisplay("Type = {nameof(SqlFieldFilterModel)} | {Name} | {Comparer} | {Value}")]
public sealed record SqlFieldFilterModel
{
    public string Name { get; init; } = "";
    public WsSqlFieldComparer Comparer { get; init; } = WsSqlFieldComparer.Equal;
    public object? Value { get; init; }

    public override int GetHashCode() => (Name.ToUpper(), Comparer, Value?.ToString().ToUpper() ?? null).GetHashCode();
}