using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace Wellness.Pdf.TestCase;

public static class ExampleFooter
{
    public static void CreateFooter(this IContainer container)
    {
        byte[] logo2 = File.ReadAllBytes("./logo2.png");
        container.Row(r =>
        {
            r.ConstantItem(100)
                .AlignLeft()
                .Height(10)
                .Image(logo2)
                ;

            r.RelativeItem()
                .AlignRight()
                .Text("ⓒ 2024 MEZOO, Digital Healthcare Frontier. All rights reserved.")
                .FontSize(8);
        });
    }
}