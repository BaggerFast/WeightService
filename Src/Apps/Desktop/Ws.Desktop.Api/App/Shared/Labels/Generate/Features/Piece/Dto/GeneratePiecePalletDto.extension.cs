using Ws.Print.Features.Barcodes;

namespace Ws.Desktop.Api.App.Shared.Labels.Generate.Features.Piece.Dto;

public static class LabelPiecePalletDtoMapper
{
    public static BarcodeBuilder ToBarcodeBuilder(this GeneratePiecePalletDto palletDto)
    {
        return new()
        {
            Kneading = (ushort)palletDto.Kneading,
            BundleCount = (ushort)palletDto.Nesting.BundleCount,
            ProductDt = palletDto.ProductDt,
            LineNumber = (uint)palletDto.Line.Number,
            LineCounter = (uint)palletDto.Line.Counter,
            PluNumber = (ushort)palletDto.Plu.Number,
            PluGtin = palletDto.Plu.Gtin,
            PluEan13 = palletDto.Plu.Ean13,
            WeightNet = palletDto.Nesting.CalculateWeightNet(palletDto.Plu),
            ExpirationDt = palletDto.ExpirationDt,
            ExpirationDay = (ushort)palletDto.ExpirationDt.DayOfYear
        };
    }
}