// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore.Sql.Core.Enums;

namespace DataCore.Sql.Fields;

/// <summary>
/// SQL order model.
/// </summary>
[DebuggerDisplay("Type = {nameof(SqlFieldOrderModel)} | {ToString} | {Direction}")]
public record SqlFieldOrderModel
{
    public string Name { get; init; } = "";
    public SqlOrderDirection Direction { get; init; } = SqlOrderDirection.Asc;

    public override int GetHashCode() => (Name.ToUpper(), Direction).GetHashCode();
}