using BinaryKits.Zpl.Labelary;
using DeviceControl.Source.Shared.RenderZpl.Exceptions;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Processing;

namespace DeviceControl.Source.Shared.RenderZpl;

internal class RenderLabelService : IRenderLabelService
{
    public async Task<string> GetZplPreviewBase64(string zpl, decimal width, decimal height)
    {
        LabelaryClient data = new();
        try
        {
            byte[] stk = await data.GetPreviewAsync(zpl, PrintDensity.PD12dpmm,
                new(Convert.ToDouble(width), Convert.ToDouble(height), Measure.Millimeter));
            return ConvertImageToBase64(stk);
        }
        catch (Exception)
        {
            throw new RenderLabelException();
        }
    }

    #region Private

    private static string ConvertImageToBase64(byte[] imageBytes)
    {
        using MemoryStream imageStream = new(imageBytes);
        using Image image = Image.Load(imageStream);

        image.Mutate(x => x.Rotate(90));

        using MemoryStream rotatedStream = new();
        image.Save(rotatedStream, new PngEncoder());
        return Convert.ToBase64String(rotatedStream.ToArray());
    }

    #endregion
}