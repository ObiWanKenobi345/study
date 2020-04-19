using System.Windows;

namespace KP
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {


        public AdminWindow()
        {
            InitializeComponent();
        }

        private void ButtonBackClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void ButtonAdminOrderClick(object sender, RoutedEventArgs e)
        {
            AdminOrder adminOrder = new AdminOrder();
            adminOrder.Show();

        }

        private void ButtonUsersClick(object sender, RoutedEventArgs e)
        {
            Users users = new Users();
            users.Show();
        }

        private void ButtonMenuClick(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
        }

        private void ButtonSuppliersClick(object sender, RoutedEventArgs e)
        {
            Suppliers suppliers = new Suppliers();
            suppliers.Show();
        }

        private void ButtonStockClick(object sender, RoutedEventArgs e)
        {
            Stock stock = new Stock();
            stock.Show();
        }
    }
}
