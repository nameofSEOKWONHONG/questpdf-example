using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using SkiaSharp;
using Wellness.Pdf.TestCase;

namespace QuestPdfExample;

public class Example
{
    public static IDocument Create()
    {
        TextStyle.Default.FontFamily("Nanum Gothic");
        
        var start = new DateTime(2024, 12, 30, 22, 00, 00);
        
        return Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(2, Unit.Centimetre);
                page.PageColor(Colors.White);

                page.Header()
                    .CreateHeader();
                
                page.Content()
                    .Column(c =>
                    {
                        c.Item()
                            .PaddingTop(10)
                            .LineHorizontal(0.1f, Unit.Centimetre)
                            .LineColor(Colors.Blue.Darken1);
                        
                        c.Item().Row(row =>
                        {
                            row.RelativeItem()
                                //.Background("#DDD")
                                .Padding(10)
                                .CreateLeft(start);

                            row.ConstantItem(120)
                                //.Background("#BBB")
                                .Padding(10)
                                .CreateRight();
                        });
                    });
                
                page.Footer()
                    .CreateFooter();
            });
        });
    }
}