using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.ViewModel
{
    internal class CustomModel
    {
        public CustomModel()
        {
            var values1 = new int[50];
            var values2 = new int[50];
            var r = new Random();
            var t = 0;
            var t2 = 0;

            for (var i = 0; i < 50; i++)
            {
                t += r.Next(-90, 100);
                values1[i] = t;

                t2 += r.Next(-90, 100);
                values2[i] = t2;
            }

            Series = new ISeries[] { new LineSeries<int> {
                Values = values1,
                Stroke= new SolidColorPaint(SKColors.Red) {
                    StrokeThickness = 1
                } ,
                Name = "a",
                Fill=null,
            }
            };


            // sharing the same instance for both charts will keep the zooming and panning synced
            SharedXAxis = new Axis[] { new Axis {
            Name = "抽卡次数",
              NamePaint = new SolidColorPaint
                    {
                        Color = SKColors.Red,
                        //FontFamily = LiveChartsSkiaSharp.MatchChar('أ'), // Arab 
                        //FontFamily = LiveChartsSkiaSharp.MatchChar('あ'), // Japanease 
                        FontFamily = LiveChartsSkiaSharp.MatchChar('你') // Chinese 汉语 sample
                        //FontFamily = "Times New Roman"
                    },
            } };
            SharedYAxis = new Axis[] { new Axis {
            Name    ="获取概率",NamePaint = new SolidColorPaint
                    {
                        Color = SKColors.Red,
                        //FontFamily = LiveChartsSkiaSharp.MatchChar('أ'), // Arab 
                        //FontFamily = LiveChartsSkiaSharp.MatchChar('あ'), // Japanease 
                        FontFamily = LiveChartsSkiaSharp.MatchChar('你') // Chinese 汉语 sample
                        //FontFamily = "Times New Roman"
                    },} };
        }

        public ISeries[] Series { get; set; }

        public Axis[] SharedXAxis { get; set; }
        public Axis[] SharedYAxis { get; set; }
    }
}
