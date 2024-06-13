using LeastSquaresProject;
using ScottPlot;

namespace LeastSquaresApp.ClassFolder
{
    /// <summary>
    /// Класс для отрисовки графика
    /// </summary>
    public class DrawGraph
    {
        public void Graph(ScottPlot.Plot plt, LeastSquaresClassProject leastSquares, double a, double b)
        {
            int n = 200;
            double h = (b - a) / n;

            double[] xValues = new double[n];
            double[] yValues = new double[n];
            
            for (int i = 0; i < n; i++)
            {
                xValues[i] = a + i * h;
                yValues[i] = leastSquares.F(xValues[i]);
            }

            // Добавляем график на рисунок
            var plot = plt.Add.Scatter(xValues, yValues);

            plot.MarkerSize = 0;
            plot.LineWidth = 4;
            plot.Color = Colors.Orange;

            // История графика
            plot.Label = leastSquares.EquationOfStraight();

            //Размер истории графика
            plt.Legend.Font.Size = 15;

            //Показываем историю графика
            plt.ShowLegend();  
        }
    }
}
