using LeastSquaresApp.ClassFolder;
using LeastSquaresProject;
using MathWorks.MATLAB.NET.Arrays;
using Microsoft.Win32;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using MathWorks.Matlab.Square;
using System.Diagnostics;
using System.Threading;

namespace LeastSquaresApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AboutAuthorWindow aboutAuthorWindow;
        private GridGenerator gridGenerate;
        Thread matlabThread, excelThread, wordThread;

        private double[] YArray;
        private double[] XArray;

        private string plotImage = "plot.png";

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Очистка программы
        /// </summary>
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            WpfPlot1.Plot.Clear();
            XArray = null;
            YArray = null;

            WpfPlot1.Refresh();
            CheckLastButtonClick.Content = "";
            MessageBox.Show("Произведена очистка");
        }

        /// <summary>
        /// Открывает chm файл для открытия помощи
        /// </summary>
        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
           // Файл для чужого использования, находитя в папке с проектом
           Process.Start("..\\Help.chm");
           //Process.Start("D:\\BNTU\\2 курс\\4 семестр\\Разработка приложений в визуальных средах\\Курсовой проект\\Help.chm");
        }

        /// <summary>
        /// Открывает диологовое окно для автора
        /// </summary>
        private void AboutAuthorButton_Click(object sender, RoutedEventArgs e)
        {
            aboutAuthorWindow = new AboutAuthorWindow();
            aboutAuthorWindow.ShowDialog();
        }

        /// <summary>
        /// Кнопка сохранения после создания матрицы значений
        /// </summary>
        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            gridGenerate = new GridGenerator();
            gridGenerate.ShowDialog();
            if (gridGenerate.SaveGridButtonWasClicked)
            {
                XArray = gridGenerate.Row1Array;
                YArray = gridGenerate.Row2Array;
                CheckLastButtonClick.Content = "Матрица сгенерирована";
            }    
        }

        /// <summary>
        /// Загрузка матрицы из excel
        /// </summary>
        private void GridUploadButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                string filePath = "";
                if (openFileDialog.ShowDialog() == true)
                    filePath = openFileDialog.FileName;

                if (filePath == "")
                    throw new Exception("Файл не выбран");

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                // Создание нового Excel пакета
                using (ExcelPackage package = new ExcelPackage(new FileInfo(filePath)))
                {
                    // Получение первого листа
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                    // Получение количества столбцов
                    int columnCount = worksheet.Dimension.Columns;

                    // Создание двух списков
                    List<double> list1 = new List<double>();
                    List<double> list2 = new List<double>();

                    // Загрузка данных в списки
                    for (int i = 1; i <= columnCount; i++)
                    {
                        if (worksheet.Cells[1, i].Value != null)
                            list1.Add(double.Parse(worksheet.Cells[1, i].Value.ToString()));
                        
                        if (worksheet.Cells[2, i].Value != null)
                            list2.Add(double.Parse(worksheet.Cells[2, i].Value.ToString()));
                    }

                    // Преобразование списков в массивы
                    XArray = list1.ToArray();
                    YArray = list2.ToArray();
                }

                CheckLastButtonClick.Content = "Матрица загружена из Excel";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        /// <summary>
        /// Рисование графика
        /// </summary>
        private void DrawPlot_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WpfPlot1.Plot.Clear();
                
                LeastSquaresClassProject leastSquares = new LeastSquaresClassProject(XArray, YArray);
                DrawGraph drawGraph = new DrawGraph();

                double x1 = XArray[0] - 1;
                double x2 = XArray[XArray.Length - 1] + 1;
                double y1 = YArray[0] - 5;
                double y2 = YArray[YArray.Length - 1] + 5;

                WpfPlot1.Plot.Add.Markers(XArray, YArray);
                drawGraph.Graph(WpfPlot1.Plot, leastSquares, x1, x2);

                WpfPlot1.Plot.Axes.SetLimits((x1 - 5), (x2 + 5), y1, y2);
                WpfPlot1.Plot.SavePng(plotImage, 800, 500);
                WpfPlot1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        /// <summary>
        /// Отрисовка графика в Matlab
        /// </summary>
        private void MATLABSolveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBox.Show("Ожидайте...");
                MLNApp mLNApp = new MLNApp();

                // Создаем MWArray для хранения данных
                MWNumericArray X = new MWNumericArray(XArray);
                MWNumericArray Y = new MWNumericArray(YArray);
                matlabThread = new Thread(() =>
                { 
                    // Передаем MWArray в MagicSquareComp и вызываем MATLAB функцию
                    mLNApp.plotPolyfit(X, Y);
                });

                matlabThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        /// <summary>
        /// Экспорт графика в excel
        /// </summary>
        private void ExcelExportButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ExcelExport excelExport = new ExcelExport();
                excelThread = new Thread(() =>
                {
                    excelExport.ExportPlotToExcel();
                });

                excelThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        /// <summary>
        /// Экспорт графика в Word
        /// </summary>
        private void WordExportButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WordExport wordExport = new WordExport();
                wordThread = new Thread(() => 
                {
                    wordExport.ExportPlotToWord(XArray, YArray);
                });
                
                wordThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        /// <summary>
        /// Закрытие программы
        /// </summary>
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
