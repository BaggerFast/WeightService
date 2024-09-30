using Ws.Barcodes.Features.Barcodes;

namespace Ws.Labels.Service.Generate.Features.Weight.Dto;

internal static class GenerateWeightPluDtoExtension
{
    internal static BarcodeBuilder ToBarcodeBuilder(this GenerateWeightLabelDto dto) =>
        new()
        {
            LineNumber = (uint)dto.Line.Number,
            LineCounter = (uint)dto.Line.Counter,
            ProductDt = dto.ProductDt,
            PluGtin = dto.Plu.Gtin,
            PluNumber = (ushort)dto.Plu.Number,
            PluEan13 = dto.Plu.Ean13,
            WeightNet = dto.Plu.Weight,
            Kneading = (ushort)dto.Kneading,
            ExpirationDt = dto.ExpirationDt,
            BundleCount = (ushort)dto.Nesting.BundleCount,
            ExpirationDay = (ushort)dto.ExpirationDt.DayOfYear
        };
}