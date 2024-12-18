using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Wellness.Pdf.TestCase;

public class FontConstant
{
    public const float LABEL_SIZE = 4f;
    public const float TEXT_SIZE = 6f;
    public const float TABLE_LABEL_SIZE = 8f;
    public const float TABLE_TEXT_SIZE = 6f;
}

public static class ExampleHeader
{
    public static void CreateHeader(this IContainer container)
    {
        byte[] logo = File.ReadAllBytes("./logo.png");
        container
            .Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn();
                    columns.ConstantColumn(300);
                });
                
                table.Cell().Row(1).Column(1)
                    .Column(col1 =>
                    {
                        col1.Item()
                            .Height(16)
                            .Width(80)
                            .Image(logo);
                        col1.Item()
                            .Text("Daily Sleep Report")
                            .FontColor(Colors.Blue.Darken1)
                            ;
                    });
                
                table.Cell().Row(1).Column(2)
                    .Shrink()
                    .Table(c2Table =>
                    {
                        c2Table.ColumnsDefinition(columns =>
                        {
                            columns.ConstantColumn(100);
                            columns.ConstantColumn(100);
                            columns.ConstantColumn(100);
                        });
                        
                        c2Table.Cell().Row(1).Column(1)
                            .BorderLeft(0.1f)
                            .BorderRight(0.1f)
                            .BorderTop(0.1f)
                            .Padding(3)
                            .Table(t =>
                            {
                                t.ColumnsDefinition(c =>
                                {
                                    c.ConstantColumn(30);
                                    c.ConstantColumn(50);
                                });
                                t.Cell().Row(1).Column(1).Text("프로필")
                                    .FontSize(FontConstant.LABEL_SIZE);
                                t.Cell().Row(1).Column(2).Text("이지은")
                                    .FontSize(FontConstant.TEXT_SIZE)
                                    .Bold();
                            });
                        
                        c2Table.Cell().Row(1).Column(2)
                            .BorderLeft(0.1f)
                            .BorderRight(0.1f)
                            .BorderTop(0.1f)
                            .Padding(3)
                            .Table(t =>
                            {
                                t.ColumnsDefinition(c =>
                                {
                                    c.ConstantColumn(30);
                                    c.ConstantColumn(50);
                                });
                                t.Cell().Row(1).Column(1).Text("성별")
                                    .FontSize(FontConstant.LABEL_SIZE);
                                t.Cell().Row(1).Column(2).Text("여성")
                                    .FontSize(FontConstant.TEXT_SIZE)
                                    .Bold();
                            });         
                        
                        c2Table.Cell().Row(1).Column(3)
                            .BorderLeft(0.1f)
                            .BorderRight(0.1f)
                            .BorderTop(0.1f)
                            .Padding(3)
                            .Table(t =>
                            {
                                t.ColumnsDefinition(c =>
                                {
                                    c.ConstantColumn(30);
                                    c.ConstantColumn(50);
                                });
                                t.Cell().Row(1).Column(1).Text("생년원일")
                                    .FontSize(FontConstant.LABEL_SIZE);
                                t.Cell().Row(1).Column(2).Text("1990.03.12")
                                    .FontSize(FontConstant.TEXT_SIZE)
                                    .Bold();
                            });
                        c2Table.Cell().Row(2).Text("").FontSize(4);
                        c2Table.Cell().Row(3).ColumnSpan(3)
                            .BorderLeft(0.1f)
                            .BorderRight(0.1f)
                            .BorderTop(0.1f)
                            .Padding(3)
                            .Table(t =>
                            {
                                t.ColumnsDefinition(c =>
                                {
                                    c.ConstantColumn(30);
                                    c.ConstantColumn(200);
                                });
                                t.Cell().Row(1).Column(1).Text("측정일시")
                                    .FontSize(FontConstant.LABEL_SIZE);
                                t.Cell().Row(1).Column(2).Text("2024년 9월 23일 오후 10시 - 9월 24일 오전 6시")
                                    .FontSize(FontConstant.TEXT_SIZE)
                                    .Bold();  
                            });
                    });
            });
    }
}