using System;

namespace LeastSquaresLibrary
{
    public class LeastSquaresMethodClassLibrary
    {
            private double Slope;
            private double Intercept;

            public LeastSquaresMethodClassLibrary(double[] xValues, double[] yValues)
            {
                Slope = LeastSquaresMethodSlope(xValues, yValues);
                Intercept = LeastSquaresMethodIntercept(xValues, yValues);
            }

            public double F(double x)
            {
                return (Slope * x + Intercept);
            }

            public string EquationOfStraight()
            {
                return $"Уравнение прямой: y = ({Math.Round(Slope, 2)})x + ({Math.Round(Intercept, 2)})";
            }

            // Метод наименьших квадратов для линейной регрессии
            private double LeastSquaresMethodSlope(double[] xValues, double[] yValues)
            {
            if (xValues == null || yValues == null)
                throw new Exception("Ошибка в корректности заполнения матрицы");

            if (xValues.Length != yValues.Length)
                throw new Exception("Ошибка: Длины массивов xValues и yValues должны совпадать.");

            int n = xValues.Length; // Количество точек данных
                double sumX = 0, sumY = 0, sumXY = 0, sumX2 = 0;

                // Вычисление сумм
                for (int i = 0; i < n; i++)
                {
                    sumX += xValues[i];
                    sumY += yValues[i];
                    sumXY += xValues[i] * yValues[i];
                    sumX2 += xValues[i] * xValues[i];
                }

                // Вычисление коэффициентов линейной модели
                double slope = (n * sumXY - sumX * sumY) / (n * sumX2 - sumX * sumX);

                return slope;
            }

        private double LeastSquaresMethodIntercept(double[] xValues, double[] yValues)
        {
            if (xValues.Length != yValues.Length)
            {
                throw new Exception("Ошибка: Длины массивов xValues и yValues должны совпадать.");
            }

            int n = xValues.Length; // Количество точек данных
            double sumX = 0, sumY = 0, sumXY = 0, sumX2 = 0;

            // Вычисление сумм
            for (int i = 0; i < n; i++)
            {
                sumX += xValues[i];
                sumY += yValues[i];
                sumXY += xValues[i] * yValues[i];
                sumX2 += xValues[i] * xValues[i];
            }

            // Вычисление коэффициентов линейной модели
            double slope = (n * sumXY - sumX * sumY) / (n * sumX2 - sumX * sumX);
            double intercept = (sumY - slope * sumX) / n;

            return intercept;
        }
    }
}
