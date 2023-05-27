using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace ODE_with_plotting
{
    internal class Plot
    {
        public static void CreatePlotPicture(List<double> y, double a, double b)
        {
            Chart chart = new Chart() { Width = 1200, Height = 1200 };
            chart.Legends.Add(new Legend());

            chart.ChartAreas.Add(new ChartArea());
            chart.ChartAreas[0].AxisX.Minimum = a;
            chart.ChartAreas[0].AxisX.Maximum = b;
            chart.ChartAreas[0].AxisX.Interval = 0.2;
            chart.ChartAreas[0].AxisY.Minimum = y.First();
            chart.ChartAreas[0].AxisY.Maximum = y.Last() + 1;
            chart.ChartAreas[0].AxisY.Interval = Math.Round((y.Last() - y.First()) / 5, 1);

            chart.Series.Add(new Series("Approximation") { ChartType = SeriesChartType.Line });
            chart.Series.Add(new Series("Exact") { ChartType = SeriesChartType.Line });

            double h = (b - a) / (y.Count - 1);
            for (int i = 0; i < y.Count; i++)
            {
                var x = a + i * h;
                chart.Series[0].Points.AddXY(x, y[i]);
                chart.Series[1].Points.AddXY(x, x * x);
            }

            chart.Titles.Add("Approximation");

            chart.SaveImage("chart.png", ChartImageFormat.Png);
        }
    }
}
