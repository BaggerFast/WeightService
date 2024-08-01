using Ws.Domain.Models.Entities.Users;
using Ws.Labels.Service.Generate.Shared.Dto;

namespace Ws.Labels.Service.Generate.Features.Piece.Dto;

public record GeneratePiecePalletDto
{
    public required PluFolLabel Plu { get; init; }
    public required ArmForLabel Line { get; init; }
    public required NestingForLabel Nesting { get; init; }
    public required PalletForLabel Pallet { get; init; }
    public required short Kneading { get; init; }
    public required decimal TrayWeight { get; init; }
    public required DateTime ProductDt { get; init; }
    public DateTime ExpirationDt => ProductDt.AddDays(Plu.ShelfLifeDays);
}