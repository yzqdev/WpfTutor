﻿using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.ViewModel
{
     public class ChartModel
    {
        public ChartModel()
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

            SeriesCollection1 = new ISeries[] { new LineSeries<int> { Values = values1 } };
            SeriesCollection2 = new ISeries[] { new ColumnSeries<int> { Values = values2 } };

            // sharing the same instance for both charts will keep the zooming and panning synced
            SharedXAxis = new Axis[] { new Axis() };
        }

        public ISeries[] SeriesCollection1 { get; set; }
        public ISeries[] SeriesCollection2 { get; set; }
        public Axis[] SharedXAxis { get; set; }
    }
}
