using Microsoft.Win32;
using OfficeOpenXml;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace LeastSquaresApp.ClassFolder
{
    /// <summary>
    /// Класс для экспорта графика в Excel
    /// </summary>
    public class ExcelExport
    {
        private string plotImage = "plot.png";

        public void ExportPlotToExcel()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel files|*.xlsx";
            string filePath = "";
            if (openFileDialog.ShowDialog() == true)
                filePath = openFileDialog.FileName;

            if (filePath == "")
                throw new Exception("Файл не выбран");

            string pathToExcelFile = openFileDialog.FileName;

            using (ExcelPackage package = new ExcelPackage(new FileInfo(pathToExcelFile)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // Получаем первый лист
                System.Drawing.Image image = System.Drawing.Image.FromFile(plotImage); // Загружаем изображение

                // Преобразуем System.Drawing.Image в поток
                using (MemoryStream stream = new MemoryStream())
                {
                    image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                    stream.Position = 0;

                    // Добавляем изображение в лист
                    var picture = worksheet.Drawings.AddPicture("MyPicture", stream);
                    picture.SetPosition(50, 0); // Устанавливаем позицию в ячейке A3
                }
                package.Save();
                MessageBox.Show($"График экспортирован в {filePath}");
            }

            Process.Start(filePath);
        }
    }
}
