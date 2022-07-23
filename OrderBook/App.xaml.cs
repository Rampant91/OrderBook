using OrderBook.ViewModels;
using System.Windows;

namespace OrderBook
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs startupEventArgs)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new OrderViewModel()
            };
            MainWindow.Show();
        }
    }
}