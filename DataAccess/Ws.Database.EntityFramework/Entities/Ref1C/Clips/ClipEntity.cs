namespace Ws.Database.EntityFramework.Entities.Ref1C.Clips;

[Table(SqlTables.Clips)]
public sealed class ClipEntity : EfEntityBase
{
    [Column(SqlColumns.Name)]
    [StringLength(64, MinimumLength = 1, ErrorMessage = "Name must be between 1 and 64 characters")]
    public string Name { get; set; } = string.Empty;

    [Range(0, 1.000, ErrorMessage = "Weight must be less than 1.000")]
    [RegularExpression(@"^\d+\.\d{3}$", ErrorMessage = "Weight must have exactly three decimal places")]
    [Column(SqlColumns.Weight, TypeName = "decimal(4,3)")]
    public decimal Weight { get; set; }

    #region Date

    public DateTime CreateDt { get; init; }
    public DateTime ChangeDt { get; init; }

    #endregion

    public ClipEntity() { }

    public ClipEntity(Guid uid, string name, decimal weight)
    {
        Id = uid;
        Name = name;
        Weight = weight;
    }
}