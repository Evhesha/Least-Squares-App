using System.Windows;

namespace LeastSquaresApp
{
    /// <summary>
    /// Логика взаимодействия для AboutAuthorWindow.xaml
    /// </summary>
    public partial class AboutAuthorWindow : Window
    {
        public AboutAuthorWindow()
        {
            InitializeComponent();
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
