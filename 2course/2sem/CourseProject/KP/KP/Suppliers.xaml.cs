using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace KP
{
    /// <summary>
    /// Логика взаимодействия для Suppliers.xaml
    /// </summary>
    public partial class Suppliers : Window
    {
        string connectionString;
        public Suppliers()
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
                SqlCommand scd = new SqlCommand(
                    "SELECT * FROM Поставщик"
                    , connection);
                SqlDataAdapter sda = new SqlDataAdapter(scd);
                DataTable dt = new DataTable("Поставщик");
                sda.Fill(dt);
                grdTable.ItemsSource = dt.DefaultView;
            }
        }

    }
}
