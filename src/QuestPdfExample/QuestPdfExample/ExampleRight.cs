using System.Security.Cryptography;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkiaSharp;

namespace QuestPdfExample;

public static class ExampleRight
{
    public static void CreateRight(this IContainer container)
    {
        //라인 차트
        // 원리는 아래와 같다.
        // maxValue, minValue에 따라 범위를 넘어서는 값은 모두 maxValue + 1, minValue - 1로 처리한다.
        // 범위는 각 라인의 레드라인은 정상 최대값, 블루라인은 정상 최소값이다.
        container
            .Column(c =>
            {
                c.Item().Text("수면 측정 점수").FontSize(Wellness.Pdf.TestCase.FontConstant.TEXT_SIZE);
                c.Item()
                    .PaddingTop(2)
                    .LineHorizontal(0.03f, Unit.Centimetre);
                c.Item()
                    .Row(r =>
                    {
                        r.RelativeItem()
                            .AlignMiddle()
                            .Text("점수: ")
                            .FontSize(Wellness.Pdf.TestCase.FontConstant.LABEL_SIZE);
                        r.RelativeItem()
                            .Text("68/100")
                            .FontSize(Wellness.Pdf.TestCase.FontConstant.TEXT_SIZE)
                            .AlignRight();
                        r.RelativeItem()
                            .AlignBottom()
                            .AlignLeft()
                            .Text("점")
                            .FontSize(Wellness.Pdf.TestCase.FontConstant.LABEL_SIZE)
                            ;
                    });
                c.Item()
                    .Height(100)
                    .SkiaSharpCanvas((canvas, size) =>
                    {
                        using var paint = new SKPaint()
                        {
                            Color = SKColors.Red,
                            StrokeWidth = 0.5f,
                            IsStroke = true,
                        };

                        using var font = new SKFont()
                        {
                            Size = 5,
                        };

                        using var fontPaint = new SKPaint()
                        {
                            Color = SKColors.Black,
                            StrokeWidth = 0.5f,
                            IsStroke = true,
                        };

                        using var myPaint = new SKPaint()
                        {
                            Color = SKColors.SandyBrown,
                            StrokeWidth = 0.5f,
                            IsStroke = true,
                        };

                        using var myPaint2 = new SKPaint()
                        {
                            Color = SKColors.Black,
                            StrokeWidth = 0.5f,
                            IsStroke = true,
                        };
                        
                        canvas.DrawRect(0, 10, 20, 5, new SKPaint { Color = SKColors.Blue });
                        canvas.DrawRect(0, 15, 20, 10, new SKPaint { Color = SKColors.DodgerBlue });
                        canvas.DrawRect(0, 25, 20, 50, new SKPaint { Color = SKColors.LightBlue });
                        canvas.DrawRect(0, 65, 20, 20, new SKPaint { Color = SKColors.DarkGray });
                        canvas.DrawRect(0, 85, 20, 10, new SKPaint { Color = SKColors.LightPink });
                        
                        canvas.DrawLine(20, 10, 50, 10, paint);
                        canvas.DrawText("Excellent", 52, 10, font, fontPaint);

                        canvas.DrawLine(20, 15, 50, 15, paint);
                        canvas.DrawText("GOOD", 52, 15, font, fontPaint);
                        
                        canvas.DrawLine(20, 25, 50, 25, paint);
                        canvas.DrawText("Not Bad", 52, 25, font, fontPaint);                                             
                        
                        canvas.DrawLine(20, 75, 50, 75, paint);
                        canvas.DrawText("Bad", 52, 75, font, fontPaint);
                        
                        canvas.DrawLine(20, 90, 50, 90, paint);
                        canvas.DrawText("Very Bad", 52, 90, font, fontPaint);
                        
                        canvas.DrawLine(0, 45, 80, 45, myPaint);
                        canvas.DrawRect(80, 30, 30, 15, myPaint);
                        canvas.DrawText("My Point", 85, 40, font, myPaint2);
                    });
                
                c.Item().Text("수면 상태 평가").FontSize(Wellness.Pdf.TestCase.FontConstant.TEXT_SIZE);
                c.Item()
                    .PaddingTop(2)
                    .LineHorizontal(0.03f, Unit.Centimetre);
                c.Item()
                    .Table(t =>
                    {
                        var items = new List<ValueTuple<string, string>>();
                        items.Add(new ("실제 수면 시간", "12시간 12분"));
                        items.Add(new ("수면까지 걸린 시간", "1시간"));
                        items.Add(new ("불규칙 리듬 횟수", "10회"));
                        items.Add(new ("무호흡 횟수", "10회"));
                        items.Add(new ("뒤척임 횟수", "10회"));
                        
                        t.ColumnsDefinition(cd =>
                        {
                            cd.RelativeColumn();
                            cd.RelativeColumn();
                        });

                        for (uint i = 1; i < items.Count + 1; i++)
                        {
                            var data = items[(int)i-1];
                            t.Cell().Row(i).Column(1)
                                .BorderBottom(0.1f)
                                .Text(data.Item1)
                                .AlignLeft()
                                .FontSize(Wellness.Pdf.TestCase.FontConstant.LABEL_SIZE);
                            t.Cell().Row(i).Column(2)
                                .BorderBottom(0.1f)
                                .AlignRight()
                                .Text(data.Item2)
                                .FontSize(Wellness.Pdf.TestCase.FontConstant.LABEL_SIZE);    
                        }
                    });

                c.Item().PaddingTop(10).Text("생체 정보").FontSize(Wellness.Pdf.TestCase.FontConstant.TEXT_SIZE);
                c.Item()
                    .PaddingTop(2)
                    .LineHorizontal(0.03f, Unit.Centimetre);
                c.Item()
                    .Table(t =>
                    {
                        t.ColumnsDefinition(cd =>
                        {
                            cd.RelativeColumn();
                        });
                        t.Cell().Table(tt =>
                        {
                            tt.ColumnsDefinition(cdd =>
                            {
                                cdd.RelativeColumn();
                                cdd.RelativeColumn();
                                cdd.RelativeColumn();
                            });
                            tt.Cell().Row(1).Column(1)
                                .Text("호흡수")
                                .AlignLeft()
                                .FontSize(Wellness.Pdf.TestCase.FontConstant.LABEL_SIZE);
                            tt.Cell().Row(1).Column(2);
                            tt.Cell().Row(1).Column(3)
                                .AlignRight()
                                .Text("평균 16회/분")
                                .FontSize(Wellness.Pdf.TestCase.FontConstant.LABEL_SIZE);
                            
                            tt.Cell().Row(2).ColumnSpan(3)
                                .Height(40)
                                .SkiaSharpCanvas((canvas, size) =>
                                {
                                    var start = new DateTime(2024, 12, 30, 22, 00, 00);
                                    var items = new List<SKPoint>();
                                    var index = 0f;
                                    var action = (double y) =>
                                    {
                                        var y_min = 8;
                                        var y_max = 27;
                                        var b_min = 5;
                                        var b_max = 22;
                                        var y_prime = b_max - (y - y_min) / (y_max - y_min) * (b_max - b_min);
                                        return y_prime;
                                    };
                                    
                                    Console.WriteLine("=================호흡수=================");
                                    for (var i = start; i <= start.AddHours(11); i = i.AddMinutes(10))
                                    { 
                                        var r = Random.Shared.Next(9, 27);
                                        Console.WriteLine(r);
                                        var y = action(r);
                                        items.Add(new SKPoint(index, (float)y));
                                        index += 1.5f;
                                    }
                                    Console.WriteLine("=================호흡수=================");
                                    
                                    // 라인1
                                    canvas.DrawLine(0, 7f, 100, 7f, new SKPaint
                                    {
                                        Color = SKColors.Red,
                                        StrokeWidth = 0.2f,
                                        IsStroke = true,
                                    });

                                    //라인2
                                    canvas.DrawLine(0, 20f, 100, 20f, new SKPaint
                                    {
                                        Color = SKColors.CornflowerBlue,
                                        StrokeWidth = 0.2f,
                                        IsStroke = true,
                                    });

                                    //contents
                                    for (var i = 0; i < items.Count; i++)
                                    {
                                        if(i == items.Count - 1) break;
                                        var current = items[i];
                                        var next = items[i + 1];

                                        #region [debug]

                                        // canvas.DrawText(current.Y.ToString(), current.X, current.Y, SKTextAlign.Center, new SKFont()
                                        // {
                                        //     Size = 3f,
                                        // }, new SKPaint()
                                        // {
                                        //     Color = chartColor,                
                                        // });
                                        // canvas.DrawCircle(current.X, current.Y, 2, new SKPaint()
                                        // {
                                        //     Color = chartColor,
                                        //     StrokeWidth = 0.1f,
                                        //     IsStroke = true                
                                        // });            

                                        #endregion

                                        canvas.DrawLine(current.X, current.Y, next.X, next.Y, new SKPaint()
                                        {
                                            Color = SKColors.Black,
                                            StrokeWidth = 0.1f,
                                            IsStroke = true
                                        });
                                    }
                                    //contents

                                    canvas.DrawLine(0, 25, 100, 25, new SKPaint()
                                    {
                                        Color = SKColors.Black,
                                        StrokeWidth = 0.2f,
                                        IsStroke = true,
                                    });

                                    canvas.DrawLine(0, 25, 0, 28, new SKPaint()
                                    {
                                        Color = SKColors.Black,
                                        StrokeWidth = 0.2f,
                                        IsStroke = true,
                                    });
                                    canvas.DrawLine(50, 25, 50, 28, new SKPaint()
                                    {
                                        Color = SKColors.Black,
                                        StrokeWidth = 0.2f,
                                        IsStroke = true,
                                    });
                                    canvas.DrawLine(100, 25, 100, 28, new SKPaint()
                                    {
                                        Color = SKColors.Black,
                                        StrokeWidth = 0.2f,
                                        IsStroke = true,
                                    });      

                                    canvas.DrawText("PM10", 0, 35, new SKPaint()
                                    {
                                        Color = SKColors.Black,
                                        TextSize = 4,
                                    });
                                    canvas.DrawText("AM02", 45, 35, new SKPaint()
                                    {
                                        Color = SKColors.Black,
                                        TextSize = 4,
                                    });                                                        
                                    canvas.DrawText("AM9", 92, 35, new SKPaint()
                                    {
                                        Color = SKColors.Black,
                                        TextSize = 4,
                                    });
                                });
                            
                            tt.Cell().Row(3).Column(1)
                                .Width(5)
                                .Height(5)
                                .SkiaSharpCanvas((canvans, size) =>
                                {
                                    canvans.DrawLine(3, 3, 12, 3, new SKPaint()
                                    {
                                        Color = SKColors.Red,
                                        StrokeWidth = 4,
                                        IsStroke = true,
                                    });
                                });
                            tt.Cell().Row(3).Column(2)
                                .Text("25 bpm 이상")
                                .FontSize(Wellness.Pdf.TestCase.FontConstant.LABEL_SIZE);                                                    
                            tt.Cell().Row(3).Column(3)
                                .AlignRight()
                                .Text("4건 발생")
                                .FontSize(Wellness.Pdf.TestCase.FontConstant.LABEL_SIZE); 
                            
                            tt.Cell().Row(4).Column(1)
                                .Width(5)
                                .Height(5)
                                .SkiaSharpCanvas((canvans, size) =>
                                {
                                    canvans.DrawLine(3, 3, 12, 3, new SKPaint()
                                    {
                                        Color = SKColors.CornflowerBlue,
                                        StrokeWidth = 4,
                                        IsStroke = true,
                                    });
                                });
                            tt.Cell().Row(4).Column(2)
                                .Text("10 bpm 이하")
                                .FontSize(Wellness.Pdf.TestCase.FontConstant.LABEL_SIZE);                                                    
                            tt.Cell().Row(4).Column(3)
                                .AlignRight()
                                .Text("2건 발생")
                                .FontSize(Wellness.Pdf.TestCase.FontConstant.LABEL_SIZE);                                                  
                        });
                        
                        t.Cell()
                            .PaddingTop(10)
                            .Table(tt =>
                        {
                            tt.ColumnsDefinition(cdd =>
                            {
                                cdd.RelativeColumn();
                                cdd.RelativeColumn();
                                cdd.RelativeColumn();
                            });
                            tt.Cell().Row(1).Column(1)
                                .Text("산소포화도")
                                .AlignLeft()
                                .FontSize(Wellness.Pdf.TestCase.FontConstant.LABEL_SIZE);
                            tt.Cell().Row(1).Column(2);
                            tt.Cell().Row(1).Column(3)
                                .AlignRight()
                                .Text("평균 98%")
                                .FontSize(Wellness.Pdf.TestCase.FontConstant.LABEL_SIZE);
                            
                            tt.Cell().Row(2).ColumnSpan(3)
                                .Height(40)
                                .SkiaSharpCanvas((canvas, size) =>
                                {
                                    var start = new DateTime(2024, 12, 30, 22, 00, 00);
                                    var items = new List<SKPoint>();
                                    var index = 0f;
                                    var action = (double y) =>
                                    {
                                        var y_min = 92;
                                        var y_max = 101;
                                        var b_min = 5;
                                        var b_max = 22;
                                        var y_prime = b_max - (y - y_min) / (y_max - y_min) * (b_max - b_min);
                                        return y_prime;
                                    };
                                    
                                    //값의 범위는 50 ~ 110까지
                                    for (var i = start; i <= start.AddHours(11); i = i.AddMinutes(10))
                                    {
                                        var y = action(Random.Shared.Next(92, 102));
                                        items.Add(new SKPoint(index, (float)y));
                                        index += 1.5f;
                                    }
                                    
                                    // 라인1
                                    canvas.DrawLine(0, 7f, 100, 7f, new SKPaint
                                    {
                                        Color = SKColors.Red,
                                        StrokeWidth = 0.2f,
                                        IsStroke = true,
                                    });

                                    //라인2
                                    canvas.DrawLine(0, 19.8f, 100, 19.8f, new SKPaint
                                    {
                                        Color = SKColors.CornflowerBlue,
                                        StrokeWidth = 0.2f,
                                        IsStroke = true,
                                    });

                                    //contents
                                    for (var i = 0; i < items.Count; i++)
                                    {
                                        if(i == items.Count - 1) break;
                                        var current = items[i];
                                        var next = items[i + 1];

                                        #region [debug]

                                        // canvas.DrawText(current.Y.ToString(), current.X, current.Y, SKTextAlign.Center, new SKFont()
                                        // {
                                        //     Size = 3f,
                                        // }, new SKPaint()
                                        // {
                                        //     Color = chartColor,                
                                        // });
                                        // canvas.DrawCircle(current.X, current.Y, 2, new SKPaint()
                                        // {
                                        //     Color = chartColor,
                                        //     StrokeWidth = 0.1f,
                                        //     IsStroke = true                
                                        // });            

                                        #endregion

                                        canvas.DrawLine(current.X, current.Y, next.X, next.Y, new SKPaint()
                                        {
                                            Color = SKColors.Black,
                                            StrokeWidth = 0.1f,
                                            IsStroke = true
                                        });
                                    }
                                    //contents

                                    canvas.DrawLine(0, 25, 100, 25, new SKPaint()
                                    {
                                        Color = SKColors.Black,
                                        StrokeWidth = 0.2f,
                                        IsStroke = true,
                                    });

                                    canvas.DrawLine(0, 25, 0, 28, new SKPaint()
                                    {
                                        Color = SKColors.Black,
                                        StrokeWidth = 0.2f,
                                        IsStroke = true,
                                    });
                                    canvas.DrawLine(50, 25, 50, 28, new SKPaint()
                                    {
                                        Color = SKColors.Black,
                                        StrokeWidth = 0.2f,
                                        IsStroke = true,
                                    });
                                    canvas.DrawLine(100, 25, 100, 28, new SKPaint()
                                    {
                                        Color = SKColors.Black,
                                        StrokeWidth = 0.2f,
                                        IsStroke = true,
                                    });      

                                    canvas.DrawText("PM10", 0, 35, new SKPaint()
                                    {
                                        Color = SKColors.Black,
                                        TextSize = 4,
                                    });
                                    canvas.DrawText("AM02", 45, 35, new SKPaint()
                                    {
                                        Color = SKColors.Black,
                                        TextSize = 4,
                                    });                                                        
                                    canvas.DrawText("AM9", 92, 35, new SKPaint()
                                    {
                                        Color = SKColors.Black,
                                        TextSize = 4,
                                    });                              
                                });
                            
                            tt.Cell().Row(3).Column(1)
                                .Width(5)
                                .Height(5)
                                .SkiaSharpCanvas((canvans, size) =>
                                {
                                    canvans.DrawLine(3, 3, 12, 3, new SKPaint()
                                    {
                                        Color = SKColors.CornflowerBlue,
                                        StrokeWidth = 4,
                                        IsStroke = true,
                                    });
                                });
                            tt.Cell().Row(3).Column(2)
                                .Text("94% 이하")
                                .FontSize(Wellness.Pdf.TestCase.FontConstant.LABEL_SIZE);                                                    
                            tt.Cell().Row(3).Column(3)
                                .AlignRight()
                                .Text("2건 발생")
                                .FontSize(Wellness.Pdf.TestCase.FontConstant.LABEL_SIZE);                                                
                        });                                            
                                                                    
                        t.Cell()
                            .PaddingTop(10)
                            .Table(tt =>
                        {
                            tt.ColumnsDefinition(cdd =>
                            {
                                cdd.RelativeColumn();
                                cdd.RelativeColumn();
                                cdd.RelativeColumn();
                            });
                            tt.Cell().Row(1).Column(1)
                                .Text("심박수")
                                .AlignLeft()
                                .FontSize(Wellness.Pdf.TestCase.FontConstant.LABEL_SIZE);
                            tt.Cell().Row(1).Column(2);
                            tt.Cell().Row(1).Column(3)
                                .AlignRight()
                                .Text("평균 92bpm")
                                .FontSize(Wellness.Pdf.TestCase.FontConstant.LABEL_SIZE);
                            
                            tt.Cell().Row(2).ColumnSpan(3)
                                .Height(40)
                                .SkiaSharpCanvas((canvas, size) =>
                                {
                                    var start = new DateTime(2024, 12, 30, 22, 00, 00);
                                    var items = new List<SKPoint>();
                                    var index = 0f;
                                    var action = (double y) =>
                                    {
                                        var y_min = 40;
                                        var y_max = 120;
                                        var b_min = 5;
                                        var b_max = 25;
                                        var y_prime = b_max - (y - y_min) / (y_max - y_min) * (b_max - b_min);
                                        return y_prime;
                                    };
                                    
                                    //값의 범위는 50 ~ 110까지
                                    for (var i = start; i <= start.AddHours(11); i = i.AddMinutes(10))
                                    {
                                        var y = action(Random.Shared.Next(50, 110));
                                        items.Add(new SKPoint(index, (float)y));
                                        index += 1.5f;
                                    }
                                    
                                    // 라인1
                                    canvas.DrawLine(0, 10f, 100, 10f, new SKPaint
                                    {
                                        Color = SKColors.Red,
                                        StrokeWidth = 0.2f,
                                        IsStroke = true,
                                    });

                                    //라인2
                                    canvas.DrawLine(0, 20f, 100, 20f, new SKPaint
                                    {
                                        Color = SKColors.CornflowerBlue,
                                        StrokeWidth = 0.2f,
                                        IsStroke = true,
                                    });

                                    //contents
                                    for (var i = 0; i < items.Count; i++)
                                    {
                                        if(i == items.Count - 1) break;
                                        var current = items[i];
                                        var next = items[i + 1];

                                        #region [debug]

                                        // canvas.DrawText(current.Y.ToString(), current.X, current.Y, SKTextAlign.Center, new SKFont()
                                        // {
                                        //     Size = 3f,
                                        // }, new SKPaint()
                                        // {
                                        //     Color = chartColor,                
                                        // });
                                        // canvas.DrawCircle(current.X, current.Y, 2, new SKPaint()
                                        // {
                                        //     Color = chartColor,
                                        //     StrokeWidth = 0.1f,
                                        //     IsStroke = true                
                                        // });            

                                        #endregion

                                        canvas.DrawLine(current.X, current.Y, next.X, next.Y, new SKPaint()
                                        {
                                            Color = SKColors.Black,
                                            StrokeWidth = 0.1f,
                                            IsStroke = true
                                        });
                                    }
                                    //contents

                                    canvas.DrawLine(0, 25, 100, 25, new SKPaint()
                                    {
                                        Color = SKColors.Black,
                                        StrokeWidth = 0.2f,
                                        IsStroke = true,
                                    });

                                    canvas.DrawLine(0, 25, 0, 28, new SKPaint()
                                    {
                                        Color = SKColors.Black,
                                        StrokeWidth = 0.2f,
                                        IsStroke = true,
                                    });
                                    canvas.DrawLine(50, 25, 50, 28, new SKPaint()
                                    {
                                        Color = SKColors.Black,
                                        StrokeWidth = 0.2f,
                                        IsStroke = true,
                                    });
                                    canvas.DrawLine(100, 25, 100, 28, new SKPaint()
                                    {
                                        Color = SKColors.Black,
                                        StrokeWidth = 0.2f,
                                        IsStroke = true,
                                    });      

                                    canvas.DrawText("PM10", 0, 35, new SKPaint()
                                    {
                                        Color = SKColors.Black,
                                        TextSize = 4,
                                    });
                                    canvas.DrawText("AM02", 45, 35, new SKPaint()
                                    {
                                        Color = SKColors.Black,
                                        TextSize = 4,
                                    });                                                        
                                    canvas.DrawText("AM9", 92, 35, new SKPaint()
                                    {
                                        Color = SKColors.Black,
                                        TextSize = 4,
                                    });                               
                                });
                            
                            tt.Cell().Row(3).Column(1)
                                .Width(5)
                                .Height(5)
                                .SkiaSharpCanvas((canvans, size) =>
                                {
                                    canvans.DrawLine(3, 3, 12, 3, new SKPaint()
                                    {
                                        Color = SKColors.Red,
                                        StrokeWidth = 4,
                                        IsStroke = true,
                                    });
                                });
                            tt.Cell().Row(3).Column(2)
                                .Text("100 bpm 이상")
                                .FontSize(Wellness.Pdf.TestCase.FontConstant.LABEL_SIZE);                                                    
                            tt.Cell().Row(3).Column(3)
                                .AlignRight()
                                .Text("4건 발생")
                                .FontSize(Wellness.Pdf.TestCase.FontConstant.LABEL_SIZE); 
                            
                            tt.Cell().Row(4).Column(1)
                                .Width(5)
                                .Height(5)
                                .SkiaSharpCanvas((canvans, size) =>
                                {
                                    canvans.DrawLine(3, 3, 12, 3, new SKPaint()
                                    {
                                        Color = SKColors.CornflowerBlue,
                                        StrokeWidth = 4,
                                        IsStroke = true,
                                    });
                                });
                            tt.Cell().Row(4).Column(2)
                                .Text("60 bpm 이하")
                                .FontSize(Wellness.Pdf.TestCase.FontConstant.LABEL_SIZE);                                                    
                            tt.Cell().Row(4).Column(3)
                                .AlignRight()
                                .Text("2건 발생")
                                .FontSize(Wellness.Pdf.TestCase.FontConstant.LABEL_SIZE);                                                  
                        });
                        
                        t.Cell()
                            .PaddingTop(10)
                            .Table(tt =>
                        {
                            tt.ColumnsDefinition(cdd =>
                            {
                                cdd.RelativeColumn();
                                cdd.RelativeColumn();
                                cdd.RelativeColumn();
                            });
                            tt.Cell().Row(1).Column(1)
                                .Text("체온")
                                .AlignLeft()
                                .FontSize(Wellness.Pdf.TestCase.FontConstant.LABEL_SIZE);
                            tt.Cell().Row(1).Column(2);
                            tt.Cell().Row(1).Column(3)
                                .AlignRight()
                                .Text("평균 36.5℃")
                                .FontSize(Wellness.Pdf.TestCase.FontConstant.LABEL_SIZE);
                            
                            tt.Cell().Row(2).ColumnSpan(3)
                                .Height(40)
                                .SkiaSharpCanvas((canvas, size) =>
                                {
                                    var start = new DateTime(2024, 12, 30, 22, 00, 00);
                                    var items = new List<SKPoint>();
                                    var index = 0f;
                                    var action = (double y) =>
                                    {
                                        var y_min = 350;
                                        var y_max = 380;
                                        var b_min = 5;
                                        var b_max = 25;
                                        var y_prime = b_max - (y - y_min) / (y_max - y_min) * (b_max - b_min);
                                        return y_prime;
                                    };
                                    
                                    //값의 범위는 360 ~ 380까지
                                    for (var i = start; i <= start.AddHours(11); i = i.AddMinutes(10))
                                    {
                                        var y = action(Random.Shared.Next(360, 380));
                                        items.Add(new SKPoint(index, (float)y));
                                        index += 1.5f;
                                    }
                                    
                                    // 라인1
                                    canvas.DrawLine(0, 8.4f, 100, 8.4f, new SKPaint
                                    {
                                        Color = SKColors.Red,
                                        StrokeWidth = 0.2f,
                                        IsStroke = true,
                                    });

                                    //라인2
                                    canvas.DrawLine(0, 15f, 100, 15f, new SKPaint
                                    {
                                        Color = SKColors.CornflowerBlue,
                                        StrokeWidth = 0.2f,
                                        IsStroke = true,
                                    });

                                    //contents
                                    for (var i = 0; i < items.Count; i++)
                                    {
                                        if(i == items.Count - 1) break;
                                        var current = items[i];
                                        var next = items[i + 1];

                                        #region [debug]

                                        // canvas.DrawText(current.Y.ToString(), current.X, current.Y, SKTextAlign.Center, new SKFont()
                                        // {
                                        //     Size = 3f,
                                        // }, new SKPaint()
                                        // {
                                        //     Color = chartColor,                
                                        // });
                                        // canvas.DrawCircle(current.X, current.Y, 2, new SKPaint()
                                        // {
                                        //     Color = chartColor,
                                        //     StrokeWidth = 0.1f,
                                        //     IsStroke = true                
                                        // });            

                                        #endregion

                                        canvas.DrawLine(current.X, current.Y, next.X, next.Y, new SKPaint()
                                        {
                                            Color = SKColors.Black,
                                            StrokeWidth = 0.1f,
                                            IsStroke = true
                                        });
                                    }
                                    //contents

                                    canvas.DrawLine(0, 25, 100, 25, new SKPaint()
                                    {
                                        Color = SKColors.Black,
                                        StrokeWidth = 0.2f,
                                        IsStroke = true,
                                    });

                                    canvas.DrawLine(0, 25, 0, 28, new SKPaint()
                                    {
                                        Color = SKColors.Black,
                                        StrokeWidth = 0.2f,
                                        IsStroke = true,
                                    });
                                    canvas.DrawLine(50, 25, 50, 28, new SKPaint()
                                    {
                                        Color = SKColors.Black,
                                        StrokeWidth = 0.2f,
                                        IsStroke = true,
                                    });
                                    canvas.DrawLine(100, 25, 100, 28, new SKPaint()
                                    {
                                        Color = SKColors.Black,
                                        StrokeWidth = 0.2f,
                                        IsStroke = true,
                                    });      

                                    canvas.DrawText("PM10", 0, 35, new SKPaint()
                                    {
                                        Color = SKColors.Black,
                                        TextSize = 4,
                                    });
                                    canvas.DrawText("AM02", 45, 35, new SKPaint()
                                    {
                                        Color = SKColors.Black,
                                        TextSize = 4,
                                    });                                                        
                                    canvas.DrawText("AM9", 92, 35, new SKPaint()
                                    {
                                        Color = SKColors.Black,
                                        TextSize = 4,
                                    });
                                });
                            
                            tt.Cell().Row(3).Column(1)
                                .Width(5)
                                .Height(5)
                                .SkiaSharpCanvas((canvans, size) =>
                                {
                                    canvans.DrawLine(3, 3, 12, 3, new SKPaint()
                                    {
                                        Color = SKColors.Red,
                                        StrokeWidth = 4,
                                        IsStroke = true,
                                    });
                                });
                            tt.Cell().Row(3).Column(2)
                                .Text("37.5℃ 이상")
                                .FontSize(Wellness.Pdf.TestCase.FontConstant.LABEL_SIZE);                                                    
                            tt.Cell().Row(3).Column(3)
                                .AlignRight()
                                .Text("4건 발생")
                                .FontSize(Wellness.Pdf.TestCase.FontConstant.LABEL_SIZE); 
                            
                            tt.Cell().Row(4).Column(1)
                                .Width(5)
                                .Height(5)
                                .SkiaSharpCanvas((canvans, size) =>
                                {
                                    canvans.DrawLine(3, 3, 12, 3, new SKPaint()
                                    {
                                        Color = SKColors.CornflowerBlue,
                                        StrokeWidth = 4,
                                        IsStroke = true,
                                    });
                                });
                            tt.Cell().Row(4).Column(2)
                                .Text("36.5℃ 이하")
                                .FontSize(Wellness.Pdf.TestCase.FontConstant.LABEL_SIZE);                                                    
                            tt.Cell().Row(4).Column(3)
                                .AlignRight()
                                .Text("2건 발생")
                                .FontSize(Wellness.Pdf.TestCase.FontConstant.LABEL_SIZE);                                                  
                        });                                         
                    });
            });                     
    }
}