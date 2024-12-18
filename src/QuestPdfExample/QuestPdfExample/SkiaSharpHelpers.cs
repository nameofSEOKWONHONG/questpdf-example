using System.Text;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using SkiaSharp;

namespace QuestPdfExample;

public static class SkiaSharpHelpers
{
    public static void SkiaSharpCanvas(this IContainer container, Action<SKCanvas, Size> drawOnCanvas)
    {
        container.Svg(size =>
        {
            using var stream = new MemoryStream();

            using (var canvas = SKSvgCanvas.Create(new SKRect(0, 0, size.Width, size.Height), stream))
                drawOnCanvas(canvas, size);
            
            var svgData = stream.ToArray();
            return Encoding.UTF8.GetString(svgData);
        });
    }
    
    public static void SkiaSharpRasterized(this IContainer container, Action<SKCanvas, Size> drawOnCanvas)
    {
        container.Image(payload =>
        {
            using var bitmap = new SKBitmap(payload.ImageSize.Width, payload.ImageSize.Height);

            using (var canvas = new SKCanvas(bitmap))
            {
                var scalingFactor = payload.Dpi / (float)DocumentSettings.DefaultRasterDpi;
                canvas.Scale(scalingFactor);
                drawOnCanvas(canvas, payload.AvailableSpace);
            }
        
            return bitmap.Encode(SKEncodedImageFormat.Png, 100).ToArray();
        });
    }
}

public static class QuestPdfExtensions
{
    private static IContainer Cell(this IContainer container, bool dark)
    {
        return container
            .Border(1)
            .Background(dark ? Colors.Grey.Lighten2 : Colors.White)
            .Padding(10);
    }
    
    // displays only text label
    public static void LabelCell(this IContainer container, string text) => container.Cell(true).Text(text).Medium();
    
    // allows you to inject any type of content, e.g. image
    public static IContainer ValueCell(this IContainer container) => container.Cell(false);
    
}