using QuestPDF.Infrastructure;
using SkiaSharp;

namespace QuestPdfExample;

public class DrawComponents
{
    public static void DrawBarChart(SKCanvas canvas, Size size, DateTime start, SKColor chartColor)
    {
        // X축
        canvas.DrawLine(10, 5, 290, 5, new SKPaint
        {
            Color = SKColors.Black,
            StrokeWidth = 0.2f,
            IsStroke = true,
        });
        // y축
        canvas.DrawLine(10, 5, 10, 40, new SKPaint
        {
            Color = SKColors.Black,
            StrokeWidth = 0.2f,
            IsStroke = true,
        });
        // x축
        canvas.DrawLine(10, 35, 290, 35, new SKPaint
        {
            Color = SKColors.Black,
            StrokeWidth = 0.2f,
            IsStroke = true,
        });
        
        canvas.DrawLine(10, 20, 290, 20, new SKPaint
        {
            Color = SKColors.Black,
            StrokeWidth = 0.2f,
            IsStroke = true,
        });

        var startPoint = 20;
        var interval = 5;
        const int addNumber = 4;
        for (var i = start; i <= start.AddHours(11); i = i.AddMinutes(10))
        {
            var x = startPoint + interval;

            if (i.ToString("mmss") == "0000")
            {
                canvas.DrawLine(x, 5, x, 10, new SKPaint
                {
                    Color = SKColors.Black,
                    StrokeWidth = 0.2f,
                    IsStroke = true,
                });

                canvas.DrawText(i.ToString("HH"), x - 2, 13, new SKPaint()
                {
                    Color = SKColors.Black,
                    TextSize = 4,
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

            interval += addNumber;
            
            canvas.DrawLine(x, Random.Shared.Next(25, 35), x, 35, new SKPaint
            {
                Color = chartColor,
                StrokeWidth = 0.2f,
                IsStroke = true,
            });
        }
    }

    public static void DrawLineChart(SKCanvas canvas, Size size, DateTime start, SKColor chartColor)
    {
        // X축
        canvas.DrawLine(10, 5, 290, 5, new SKPaint
        {
            Color = SKColors.Black,
            StrokeWidth = 0.2f,
            IsStroke = true,
        });
        // y축
        canvas.DrawLine(10, 5, 10, 40, new SKPaint
        {
            Color = SKColors.Black,
            StrokeWidth = 0.2f,
            IsStroke = true,
        });

        var linePoints = new List<SKPoint>();

        var startPoint = 20;
        var interval = 5;
        const int addNumber = 4;
        for (var i = start; i <= start.AddHours(11); i = i.AddMinutes(10))
        {
            var x = startPoint + interval;

            if (i.ToString("mmss") == "0000")
            {
                canvas.DrawLine(x, 5, x, 10, new SKPaint
                {
                    Color = SKColors.Black,
                    StrokeWidth = 0.2f,
                    IsStroke = true,
                });

                canvas.DrawText(i.ToString("HH"), x - 2, 13, new SKPaint()
                {
                    Color = SKColors.Black,
                    TextSize = 4,
                });
                
                var y = Random.Shared.Next(20, 40);
                canvas.DrawText(y.ToString(), x-2, y-2, new SKPaint()
                {
                    Color = SKColors.Black,
                    TextSize = 4,
                });
                canvas.DrawCircle(x, y, 1, new SKPaint()
                {
                    Color = chartColor,
                    TextSize = 2,
                });
                
                linePoints.Add(new SKPoint(x, y));
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
            
            interval += addNumber;
        }

        for (var i = 0; i < linePoints.Count; i++)
        {
            if(i == linePoints.Count - 1) break;
            var current = linePoints[i];
            var next = linePoints[i + 1];

            canvas.DrawLine(current.X, current.Y, next.X, next.Y, new SKPaint()
            {
                Color = chartColor,
                StrokeWidth = 0.2f,
                IsStroke = true,
            });
        }        
    }

    public static void DrawSmallLineChart(SKCanvas canvas, Size size, List<SKPoint> data, SKColor chartColor)
    {
        // 라인1
        canvas.DrawLine(0, 10, 100, 10, new SKPaint
        {
            Color = SKColors.Red,
            StrokeWidth = 0.2f,
            IsStroke = true,
        });

        //라인2
        canvas.DrawLine(0, 20, 100, 20, new SKPaint
        {
            Color = SKColors.CornflowerBlue,
            StrokeWidth = 0.2f,
            IsStroke = true,
        });

        //contents
        for (var i = 0; i < data.Count; i++)
        {
            if(i == data.Count - 1) break;
            var current = data[i];
            var next = data[i + 1];

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
                Color = chartColor,
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
    }
}