using System.Windows;

namespace KP
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public UserWindow()
        {
            InitializeComponent();
        }

        private void ButtonBackClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void ButtonMenuClick(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
        }

        private void ButtonOrderClick(object sender, RoutedEventArgs e)
        {
            UserOrder userOrder = new UserOrder();
            userOrder.Show();
        }

        private void ButtonStockClick(object sender, RoutedEventArgs e)
        {
            Stock stock = new Stock();
            stock.Show();
        }
    }
}
