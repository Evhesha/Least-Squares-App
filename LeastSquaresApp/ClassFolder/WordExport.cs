using Microsoft.Win32;
using System.Diagnostics;
using System.Windows;

namespace LeastSquaresApp.ClassFolder
{
    /// <summary>
    /// Класс для экспорта в Word
    /// </summary>
    public class WordExport
    {
        string plotImage = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "plot.png");

        public void ExportPlotToWord(double[] xArray, double[] yArray)
        {
            // Открываем диалог выбора файла
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Word Documents|*.docx";
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;

                // Создаем новый Word.Application
                Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();

                // Открываем документ
                Microsoft.Office.Interop.Word.Document doc = word.Documents.Open(filePath);

                // Вставляем картинку и заголовок
                var paragraph = doc.Content.Paragraphs.Add();
                paragraph.Range.InsertParagraphBefore();
                paragraph.Range.Text = "ScottPlot Graphics";
                paragraph.Range.InsertParagraphAfter();

                doc.InlineShapes.AddPicture(plotImage, Range: paragraph.Range);

                // Добавляем таблицу
                var range = doc.Content;
                range.InsertAfter("\n");
                range.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
                var table = doc.Tables.Add(range, xArray.Length + 1, 2);
                table.Cell(1, 1).Range.Text = "X";
                table.Cell(1, 2).Range.Text = "Y";
                for (int i = 0; i < xArray.Length; i++)
                {
                    table.Cell(i + 2, 1).Range.Text = xArray[i].ToString();
                    table.Cell(i + 2, 2).Range.Text = yArray[i].ToString();
                }

                // Добавляем границы для таблицы
                table.Borders.Enable = 1;

                // Сохраняем и закрываем документ
                doc.Save();
                doc.Close();

                // Закрываем Word.Application
                word.Quit();

                Process.Start(filePath);
                MessageBox.Show($"График экспортирован в {filePath}");
            }
        }
    }
}
