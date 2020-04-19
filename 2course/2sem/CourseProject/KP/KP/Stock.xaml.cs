using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace KP
{
    /// <summary>
    /// Логика взаимодействия для Stock.xaml
    /// </summary>
    public partial class Stock : Window
    {
        string connectionString;
        public Stock()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void ButtonCloseClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand scd = new SqlCommand(
                    "SELECT * FROM Склад"
                    , connection);
                SqlDataAdapter sda = new SqlDataAdapter(scd);
                DataTable dt = new DataTable("Склад");
                sda.Fill(dt);
                grdTable.ItemsSource = dt.DefaultView;
            }
        }
    }
}
