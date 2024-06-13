using System;

namespace LeastSquaresProject
{
    /// <summary>
    /// Класс для метода найменьших квадратов
    /// </summary>
    public class LeastSquaresClassProject
    {
        private double slope;
        private double intercept;

        public double Slope { get { return slope; } private set { } }
        public double Intecept { get { return intercept; } private set { } }

        public LeastSquaresClassProject(double[] xValues, double[] yValues)
        {
            slope = LeastSquaresMethodSlope(xValues, yValues);
            intercept = LeastSquaresMethodIntercept(xValues, yValues);
        }

        public double F(double x)
        {
            return (slope * x + intercept);
        }

        public string EquationOfStraight()
        {
            return $"Уравнение прямой: y = ({Math.Round(slope,2)})x + ({Math.Round(intercept,2)})";
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
