namespace Ws.Database.EntityFramework.Entities.Print.Pallets;

public class PalletEntity
{
    public Guid Id { get; set; }

    #region FK

    public LineEntity Arm { get; set; } = new();
    public PalletManEntity PalletMan { get; set; } = new();

    #endregion

    public uint Counter { get; set; }
    public bool IsShipped { get; set; }
    public decimal TrayWeight { get; set; }
    public DateTime ProductDt { get; set; }
    public string Number { get; set; } = string.Empty;
    public string Barcode { get; set; } = string.Empty;

    #region Date

    public DateTime CreateDt { get; init; }
    public DateTime? DeletedAt { get; set; }

    #endregion
}