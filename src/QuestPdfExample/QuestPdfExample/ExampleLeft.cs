using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using QuestPdfExample;
using SkiaSharp;

namespace Wellness.Pdf.TestCase;

public static class ExampleLeft
{
    public static void CreateLeft(this IContainer container, DateTime start)
    {
        container.Column(c1 =>
        {
            c1.Spacing(10f);
            c1.Item().Text("수면정보").FontSize(FontConstant.LABEL_SIZE);
            c1.Item()
                .PaddingTop(2)
                .LineHorizontal(0.03f, Unit.Centimetre);
            c1.Item()
                .Row(r =>
                {
                    r.RelativeItem()
                        .Table(t =>
                        {
                            t.ColumnsDefinition(d =>
                            {
                                d.RelativeColumn();
                            });
                            t.Cell().Row(1).Column(1).Text("수면 시간").FontSize(FontConstant.LABEL_SIZE);
                            t.Cell().Row(2).Column(1).Text("8시간 00분").FontSize(FontConstant.TEXT_SIZE).Bold();
                        });
                    
                    r.RelativeItem()
                        .Table(t =>
                        {
                            t.ColumnsDefinition(d =>
                            {
                                d.RelativeColumn();
                            });
                            t.Cell().Row(1).Column(1).Text("취침 시간").FontSize(FontConstant.LABEL_SIZE);
                            t.Cell().Row(2).Column(1).Text("22:00").FontSize(FontConstant.TEXT_SIZE).Bold();
                        });
                    
                    r.RelativeItem()
                        .Table(t =>
                        {
                            t.ColumnsDefinition(d =>
                            {
                                d.RelativeColumn();
                            });
                            t.Cell().Row(1).Column(1).Text("기상 시간").FontSize(FontConstant.LABEL_SIZE);
                            t.Cell().Row(2).Column(1).Text("06:00").FontSize(FontConstant.TEXT_SIZE).Bold();
                        });
                });
            
            c1.Item()
                .BorderTop(0.4f)
                .BorderBottom(0.4f)
                .Table(t =>
                {
                    t.ColumnsDefinition(d =>
                    {
                        d.ConstantColumn(50);
                        d.RelativeColumn();
                    });
                    t.Cell().Row(1).Column(1).AlignMiddle()
                        .Text("수면 단계\r\nSleep Stage")
                        .FontSize(FontConstant.LABEL_SIZE)
                        .AlignCenter();
                    t.Cell().Row(1).Column(2)
                        .BorderLeft(0.1f)
                        .Table(tt =>
                        {
                            tt.ColumnsDefinition(dd =>
                            {
                                dd.RelativeColumn();
                            });
                            tt.Cell().Row(1).Column(1)
                                .Height(70)
                                .SkiaSharpCanvas((canvas, size) =>
                                {
                                    var data = new List<ValueTuple<string, DateTime>>();
                                    data.Add(new ("A", new DateTime(2024, 12, 30, 22, 59, 59)));
                                    data.Add(new ("B", new DateTime(2024, 12, 30, 23, 59, 59)));
                                    data.Add(new ("C", new DateTime(2024, 12, 31, 00, 59, 59)));
                                    data.Add(new ("D", new DateTime(2024, 12, 31, 01, 59, 59)));
                                    data.Add(new ("C", new DateTime(2024, 12, 31, 02, 59, 59)));
                                    data.Add(new ("B", new DateTime(2024, 12, 31, 03, 59, 59)));
                                    data.Add(new ("B", new DateTime(2024, 12, 31, 04, 59, 59)));
                                    data.Add(new ("C", new DateTime(2024, 12, 31, 05, 59, 59)));
                                    data.Add(new ("C", new DateTime(2024, 12, 31, 06, 59, 59)));
                                    data.Add(new ("B", new DateTime(2024, 12, 31, 07, 59, 59)));
                                    data.Add(new ("A", new DateTime(2024, 12, 31, 08, 59, 59)));
                                    
                                    // X축
                                    canvas.DrawLine(10, 5, 290, 5, new SKPaint
                                    {
                                        Color = SKColors.Black,
                                        StrokeWidth = 0.2f,
                                        IsStroke = true,
                                    });
                                    // y축
                                    canvas.DrawLine(10, 5, 10, 128, new SKPaint
                                    {
                                        Color = SKColors.Black,
                                        StrokeWidth = 0.2f,
                                        IsStroke = true,
                                    });
                                    
                                    //중간 라인
                                    canvas.DrawLine(10, 20 - 1, 295, 20 - 1,  new SKPaint
                                    {
                                        Color = SKColors.Black,
                                        StrokeWidth = 0.1f,
                                        IsStroke = true,
                                    });
                                    
                                    //하단라인
                                    canvas.DrawLine(10, 30 - 1, 295, 30 - 1,  new SKPaint
                                    {
                                        Color = SKColors.Black,
                                        StrokeWidth = 0.1f,
                                        IsStroke = true,
                                    });               
                                    
                                    //시간라인 1
                                    canvas.DrawLine(10, 40 - 1, 295, 40 - 1,  new SKPaint
                                    {
                                        Color = SKColors.Black,
                                        StrokeWidth = 0.1f,
                                        IsStroke = true,
                                    });  
                                    //시간라인 2
                                    canvas.DrawLine(10, 50 - 1, 295, 50 - 1,  new SKPaint
                                    {
                                        Color = SKColors.Black,
                                        StrokeWidth = 0.1f,
                                        IsStroke = true,
                                    });        
                                    //시간라인 3
                                    canvas.DrawLine(10, 60 - 1, 295, 60 - 1,  new SKPaint
                                    {
                                        Color = SKColors.Black,
                                        StrokeWidth = 0.1f,
                                        IsStroke = true,
                                    });                                                                 
                                    
                                    var startPoint = 30;
                                    const int addNumber = 4;
                                    for (var i = start; i <= start.AddHours(11); i = i.AddMinutes(10))
                                    {
                                        var x = startPoint;

                                        if (i.ToString("mmss") == "0000")
                                        {
                                            canvas.DrawLine(x, 5, x, 10, new SKPaint
                                            {
                                                Color = SKColors.Black,
                                                StrokeWidth = 0.2f,
                                                IsStroke = true,
                                            });

                                            canvas.DrawText(i.ToString("HH"), x - 2, 13, SKTextAlign.Center, new SKFont()
                                            {
                                                Size = 4,
                                            }, new SKPaint()
                                            {
                                                Color = SKColors.Black
                                            });    
                                        }
                                        else
                                        {
                                            canvas.DrawLine(x, 5, x, 8, new SKPaint
                                            {
                                                Color = SKColors.Black,
                                                StrokeWidth = 0.2f,
                                                IsStroke = true,
                                            });
                                        }

                                        var item = data.FirstOrDefault(m => m.Item2 >= i);
                                        if (item.Item1 == "A")
                                        {
                                            canvas.DrawRect(x, 20, 0, 8, new SKPaint()
                                            {
                                                Color = SKColors.Orange,
                                                StrokeWidth = 4,
                                                IsStroke = true
                                            });    
                                        }
                                        else if (item.Item1 == "B")
                                        {
                                            canvas.DrawRect(x, 30, 0, 8, new SKPaint()
                                            {
                                                Color = SKColors.CadetBlue,
                                                StrokeWidth = 4,
                                                IsStroke = true
                                            });
                                        }
                                        else if (item.Item1 == "C")
                                        {
                                            canvas.DrawRect(x, 40, 0, 8, new SKPaint()
                                            {
                                                Color = SKColors.Blue,
                                                StrokeWidth = 4,
                                                IsStroke = true
                                            });
                                        }
                                        else if (item.Item1 == "D")
                                        {
                                            canvas.DrawRect(x, 50, 0, 8, new SKPaint()
                                            {
                                                Color = SKColors.Purple,
                                                StrokeWidth = 4,
                                                IsStroke = true
                                            });
                                        }
                                        

                                        startPoint += addNumber;
                                    }                                           
                                });
                            tt.Cell().Row(2).Column(1).Text("            수면 단계 통계")
                                .FontSize(FontConstant.TEXT_SIZE);
                            tt.Cell().Row(3).Column(1)
                                .PaddingLeft(20)
                                .Height(50)
                                .Table(ttt =>
                                {
                                    ttt.ColumnsDefinition(ddd =>
                                    {
                                        ddd.ConstantColumn(20);
                                        ddd.ConstantColumn(40);
                                        ddd.ConstantColumn(40);
                                        ddd.ConstantColumn(40);
                                    });

                                    ttt.Cell().Row(1).Column(1)
                                        .BorderBottom(0.2f)
                                        .Text("   ")
                                        .FontSize(FontConstant.LABEL_SIZE)
                                        .Bold()
                                        ;
                                    ttt.Cell().Row(1).Column(2)
                                        .BorderBottom(0.2f)
                                        .Text("단계")
                                        .FontSize(FontConstant.LABEL_SIZE)
                                        .Bold()
                                        ;                                                   
                                    ttt.Cell().Row(1).Column(3)
                                        .BorderBottom(0.2f)
                                        .Text("시간")
                                        .FontSize(FontConstant.LABEL_SIZE)
                                        .Bold()
                                        ;         
                                    ttt.Cell().Row(1).Column(4)
                                        .BorderBottom(0.2f)
                                        .Text("비율")
                                        .FontSize(FontConstant.LABEL_SIZE)
                                        .Bold()
                                        ;         
                                    
                                    ttt.Cell().Row(2).Column(1)
                                        .BorderBottom(0.2f)
                                        .Height(5)
                                        .SkiaSharpCanvas((canvans, size) =>
                                        {
                                            canvans.DrawLine(3, 3, 12, 3, new SKPaint()
                                            {
                                                Color = SKColors.Orange,
                                                StrokeWidth = 4,
                                                IsStroke = true,
                                            });
                                        })
                                        ;
                                    ttt.Cell().Row(2).Column(2)
                                        .BorderBottom(0.2f)
                                        .Text("비수면")
                                        .FontSize(FontConstant.LABEL_SIZE)
                                        ;                                                   
                                    ttt.Cell().Row(2).Column(3)
                                        .BorderBottom(0.2f)
                                        .Text("48분")
                                        .FontSize(FontConstant.LABEL_SIZE)
                                        ;         
                                    ttt.Cell().Row(2).Column(4)
                                        .BorderBottom(0.2f)
                                        .Text("10%")
                                        .FontSize(FontConstant.LABEL_SIZE)
                                        ;         
                                    
                                    ttt.Cell().Row(3).Column(1)
                                        .BorderBottom(0.2f)
                                        .Height(5)
                                        .SkiaSharpCanvas((canvans, size) =>
                                        {
                                            canvans.DrawLine(3, 3, 12, 3, new SKPaint()
                                            {
                                                Color = SKColors.CadetBlue,
                                                StrokeWidth = 4,
                                                IsStroke = true,
                                            });
                                        })
                                        ;
                                    ttt.Cell().Row(3).Column(2)
                                        .BorderBottom(0.2f)
                                        .Text("램(REM) 수면")
                                        .FontSize(FontConstant.LABEL_SIZE)
                                        ;                                                   
                                    ttt.Cell().Row(3).Column(3)
                                        .BorderBottom(0.2f)
                                        .Text("1시간 36분")
                                        .FontSize(FontConstant.LABEL_SIZE)
                                        ;         
                                    ttt.Cell().Row(3).Column(4)
                                        .BorderBottom(0.2f)
                                        .Text("20%")
                                        .FontSize(FontConstant.LABEL_SIZE)
                                        ;            

                                    ttt.Cell().Row(4).Column(1)
                                        .BorderBottom(0.2f)
                                        .Height(5)
                                        .SkiaSharpCanvas((canvans, size) =>
                                        {
                                            canvans.DrawLine(3, 3, 12, 3, new SKPaint()
                                            {
                                                Color = SKColors.Blue,
                                                StrokeWidth = 4,
                                                IsStroke = true,
                                            });
                                        })
                                        ;
                                    ttt.Cell().Row(4).Column(2)
                                        .BorderBottom(0.2f)
                                        .Text("얕은 수면")
                                        .FontSize(FontConstant.LABEL_SIZE)
                                        ;                                                   
                                    ttt.Cell().Row(4).Column(3)
                                        .BorderBottom(0.2f)
                                        .Text("3시간 12분")
                                        .FontSize(FontConstant.LABEL_SIZE)
                                        ;         
                                    ttt.Cell().Row(4).Column(4)
                                        .BorderBottom(0.2f)
                                        .Text("40%")
                                        .FontSize(FontConstant.LABEL_SIZE)
                                        ;

                                    ttt.Cell().Row(5).Column(1)
                                        .BorderBottom(0.2f)
                                        .Height(5)
                                        .SkiaSharpCanvas((canvans, size) =>
                                        {
                                            canvans.DrawLine(3, 3, 12, 3, new SKPaint()
                                            {
                                                Color = SKColors.Purple,
                                                StrokeWidth = 4,
                                                IsStroke = true,
                                            });
                                        })
                                        ;
                                    ttt.Cell().Row(5).Column(2)
                                        .BorderBottom(0.2f)
                                        .Text("깊은 수면")
                                        .FontSize(FontConstant.LABEL_SIZE)
                                        ;                                                   
                                    ttt.Cell().Row(5).Column(3)
                                        .BorderBottom(0.2f)
                                        .Text("2시간 24분")
                                        .FontSize(FontConstant.LABEL_SIZE)
                                        ;         
                                    ttt.Cell().Row(5).Column(4)
                                        .BorderBottom(0.2f)
                                        .Text("30%")
                                        .FontSize(FontConstant.LABEL_SIZE)
                                        ;                                                               
                                });
                        });
                });
            c1.Item()
                .Text("● 렘(REM) 수면은 정신의 피로를 회복하는 데 중요한 수면 단계이며, 얕은 수면과 깉은 수면은 신체적인 회복에 필요한 수면 단계 입니다.")
                .FontSize(FontConstant.LABEL_SIZE);

            #region [이벤트 발생 정보]

            c1.Item().Text("이벤트 발생 정보").FontSize(FontConstant.TEXT_SIZE).Bold();
            c1.Item()
                .BorderTop(0.4f)
                .BorderBottom(0.4f)
                .Table(t =>
                {
                    t.ColumnsDefinition(d =>
                    {
                        d.ConstantColumn(50);
                        d.RelativeColumn();
                    });
                    t.Cell().Row(1)
                        .Column(1)
                        .BorderBottom(0.4f)
                        .AlignMiddle()
                        .Column(cc =>
                        {
                            cc.Item().Text("무호흡")
                                .FontSize(FontConstant.LABEL_SIZE)
                                .Bold();
                            cc.Item().Text("Apnear")
                                .FontSize(FontConstant.LABEL_SIZE);
                        });
                    t.Cell().Row(1).Column(2)
                        .BorderLeft(0.1f)
                        .Height(40)
                        .SkiaSharpCanvas((canvas, size) =>
                        {
                            DrawComponents.DrawBarChart(canvas, size, start, SKColors.DodgerBlue);
                        });
                    
                    t.Cell().Row(2)
                        .Column(1)
                        .BorderBottom(0.4f)
                        .AlignMiddle()
                        .Column(cc =>
                        {
                            cc.Item().Text("불규칙한 심장박동")
                                .FontSize(FontConstant.LABEL_SIZE)
                                .Bold();
                            cc.Item().Text("Arrhythmia")
                                .FontSize(FontConstant.LABEL_SIZE);
                        });
                    t.Cell().Row(2).Column(2)
                        .BorderLeft(0.1f)
                        .Height(40)
                        .SkiaSharpCanvas((canvas, size) =>
                        {
                            DrawComponents.DrawBarChart(canvas, size, start, SKColors.Red);
                        });
                    
                   t.Cell().Row(3)
                       .Column(1)
                       .AlignMiddle()
                       .Column(cc =>
                       {
                           cc.Item().Text("뒤척임")
                               .FontSize(FontConstant.LABEL_SIZE)
                               .Bold();
                           cc.Item().Text("Arrhythmia")
                               .FontSize(FontConstant.LABEL_SIZE);
                       });
                    t.Cell().Row(3).Column(2)
                        .BorderLeft(0.1f)
                        .Height(40)
                        .SkiaSharpCanvas((canvas, size) =>
                        {
                            DrawComponents.DrawBarChart(canvas, size, start, SKColors.Blue);
                        });                                                 
                });
            
            #endregion

            #region [트랜드 정보]
            
            c1.Item().Text("트랜드 정보").FontSize(FontConstant.TEXT_SIZE).Bold();
            c1.Item()
                .BorderTop(0.4f)
                .BorderBottom(0.4f)
                .Table(t =>
                {
                    t.ColumnsDefinition(d =>
                    {
                        d.ConstantColumn(50);
                        d.RelativeColumn();
                    });
                    t.Cell().Row(1)
                        .Column(1)
                        .BorderBottom(0.4f)
                        .AlignMiddle()
                        .Column(cc =>
                        {
                            cc.Item().Text("호흡수")
                                .FontSize(FontConstant.LABEL_SIZE)
                                .Bold();
                            cc.Item().Text("1분간 호흡하는 횟수 (회/분)")
                                .FontSize(FontConstant.LABEL_SIZE);
                        });
                    t.Cell().Row(1).Column(2)
                        .BorderLeft(0.1f)
                        .Height(40)
                        .SkiaSharpCanvas((canvas, size) =>
                        {
                            DrawComponents.DrawLineChart(canvas, size, start, SKColors.Blue);
                        });
                    
                    t.Cell().Row(2)
                        .Column(1)
                        .BorderBottom(0.4f)
                        .AlignMiddle()
                        .Column(cc =>
                        {
                            cc.Item().Text("산소포화도")
                                .FontSize(FontConstant.LABEL_SIZE)
                                .Bold();
                            cc.Item().Text("혈액내 산소의 비율 (%)")
                                .FontSize(FontConstant.LABEL_SIZE);
                        });
                    
                    t.Cell().Row(2).Column(2)
                        .BorderLeft(0.1f)
                        .Height(40)
                        .SkiaSharpCanvas((canvas, size) =>
                        {
                            DrawComponents.DrawLineChart(canvas, size, start, SKColors.Blue);
                        });
                    
                   t.Cell().Row(3)
                       .Column(1)
                       .BorderBottom(0.4f)
                       .AlignMiddle()
                       .Column(cc =>
                       {
                           cc.Item().Text("심박수")
                               .FontSize(FontConstant.LABEL_SIZE)
                               .Bold();
                           cc.Item().Text("1분간 심장이 뛰는 횟수 (bpm)")
                               .FontSize(FontConstant.LABEL_SIZE);
                       });
                    t.Cell().Row(3).Column(2)
                        .BorderLeft(0.1f)
                        .Height(40)
                        .SkiaSharpCanvas((canvas, size) =>
                        {
                            DrawComponents.DrawLineChart(canvas, size, start, SKColors.Blue);
                        });
                    
                   t.Cell().Row(4)
                       .Column(1)
                       .AlignMiddle()
                       .Column(cc =>
                       {
                           cc.Item().Text("체온")
                               .FontSize(FontConstant.LABEL_SIZE)
                               .Bold();
                           cc.Item().Text("신체 내부의 온도 (℃)")
                               .FontSize(FontConstant.LABEL_SIZE);
                       });
                    t.Cell().Row(4).Column(2)
                        .BorderLeft(0.1f)
                        .Height(40)
                        .SkiaSharpCanvas((canvas, size) =>
                        {
                            DrawComponents.DrawLineChart(canvas, size, start, SKColors.Blue);
                        });
                });
            
            #endregion
        });        
    }
}
