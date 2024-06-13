using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace LeastSquaresApp
{
    /// <summary>
    /// Логика взаимодействия для GridGenerator.xaml
    /// </summary>
    public partial class GridGenerator : Window
    {
        public bool SaveGridButtonWasClicked { get; private set; }
        public GridGenerator()
        {
            InitializeComponent();
        }

        public double[] Row1Array { get; private set; }
        public double[] Row2Array { get; private set; }

        private void SaveGridButton_Click(object sender, RoutedEventArgs e)
        {
            // Создание двух списков для хранения TextBox'ов из каждого ряда
            List<TextBox> row1TextBoxes = new List<TextBox>();
            List<TextBox> row2TextBoxes = new List<TextBox>();

            // Пройдите по всем дочерним элементам Grid
            foreach (UIElement child in Grid.Children)
            {
                // Проверяем, является ли дочерний элемент TextBox'ом
                if (child is TextBox)
                {
                    TextBox textBox = (TextBox)child;

                    // В зависимости от значения Grid.Row добавьте TextBox в соответствующий список
                    if (Grid.GetRow(textBox) == 0)
                    {
                        row1TextBoxes.Add(textBox);
                    }
                    else if (Grid.GetRow(textBox) == 1)
                    {
                        row2TextBoxes.Add(textBox);
                    }
                }
            }

            // Преобразование списки TextBox'ов в массивы double
            List<double> row1Values = new List<double>();
            List<double> row2Values = new List<double>();

            for (int i = 0; i < row1TextBoxes.Count; i++)
            {
                if (!string.IsNullOrWhiteSpace(row1TextBoxes[i].Text))
                {
                    if (double.TryParse(row1TextBoxes[i].Text, out double value))
                    {
                        row1Values.Add(value);
                    }
                    else
                    {
                        MessageBox.Show("Некорректное значение в первом ряду: " + row1TextBoxes[i].Text);
                        return;
                    }
                }
            }

            for (int i = 0; i < row2TextBoxes.Count; i++)
            {
                if (!string.IsNullOrWhiteSpace(row2TextBoxes[i].Text))
                {
                    if (double.TryParse(row2TextBoxes[i].Text, out double value))
                    {
                        row2Values.Add(value);
                    }
                    else
                    {
                        MessageBox.Show("Некорректное значение во втором ряду: " + row2TextBoxes[i].Text);
                        return;
                    }
                }
            }

            // Преобразование списков значений в массивы
            Row1Array = row1Values.ToArray();
            Row2Array = row2Values.ToArray();

            SaveGridButtonWasClicked = true;

            this.Close();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
