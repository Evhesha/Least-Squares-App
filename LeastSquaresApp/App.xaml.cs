using System.Windows;

namespace LeastSquaresApp
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            // Задержка для показа заставки в течение 5 секунд
            System.Threading.Thread.Sleep(5000);
        }
    }
}
