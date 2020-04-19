using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab7
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string connectionString;
        public MainWindow()
        {
            InitializeComponent();
            // получаем строку подключения и используем её
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            ConnectDB();
        }
        private void ConnectDB()
        {
            // Создание подключения
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                // Открываем подключение
                connection.Open();
                MessageBox.Show("Connection is open");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // закрываем подключение
                connection.Close();
                Console.WriteLine("Conection is close...");
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckEmptyFields())
            {
                MessageBox.Show("Not all fields filled");
                return;
            }
              
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand scd = new SqlCommand(
                        "insert into [books] ([name], [count], [publishing], [year], [date], [author]) " +
                        "values (@name, @count, @publishing, @year, @date, @author)",
                        connection
                    );
                    scd.Parameters.Add("@name", Name.Text);
                    scd.Parameters.Add("@count", Count_page.Text);
                    scd.Parameters.Add("@publishing", Publishing.Text);
                    scd.Parameters.Add("@year", Year.Text);
                    scd.Parameters.Add("@date", Date.Text);
                    scd.Parameters.Add("@author", Author.Text);
                    scd.ExecuteNonQuery();
                    MessageBox.Show("added");
                }

                //string sqlExpression = "sp_InsertBook";

                //using (SqlConnection connection = new SqlConnection(connectionString))
                //{
                //    connection.Open();
                //    SqlCommand command = new SqlCommand(sqlExpression, connection);
                //    command.CommandType = System.Data.CommandType.StoredProcedure;
                //    SqlParameter nameParam = new SqlParameter
                //    {
                //        ParameterName = "@Name",
                //        Value = Name.Text
                //    };
                //    SqlParameter countParam = new SqlParameter
                //    {
                //        ParameterName = "@Count",
                //        Value = Count_page.Text
                //    };
                //    SqlParameter publishingParam = new SqlParameter
                //    {
                //        ParameterName = "@Publishing",
                //        Value = Publishing.Text
                //    };
                //    SqlParameter yearParam = new SqlParameter
                //    {
                //        ParameterName = "@Year",
                //        Value = Year.Text
                //    };
                //    SqlParameter dateParam = new SqlParameter
                //    {
                //        ParameterName = "@Date",
                //        Value = Date.Text
                //    };
                //    SqlParameter authorParam = new SqlParameter
                //    {
                //        ParameterName = "@Author",
                //        Value = Author.Text
                //    };

                //    command.Parameters.Add(countParam);
                //    command.Parameters.Add(nameParam);
                //    command.Parameters.Add(publishingParam);
                //    command.Parameters.Add(yearParam);
                //    command.Parameters.Add(dateParam);
                //    command.Parameters.Add(authorParam);
                //    command.ExecuteNonQuery();
                //    MessageBox.Show("Added");
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool CheckEmptyFields()
        {
            if (
                Name.Text == String.Empty ||
                Count_page.Text == String.Empty ||
                Publishing.Text == String.Empty ||
                Year.Text == String.Empty ||
                Date.Text == String.Empty ||
                Author.Text == String.Empty
            ) return false;
            return true;
        }
        
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand scd = new SqlCommand("SELECT * FROM Books", connection);
                SqlDataAdapter sda = new SqlDataAdapter(scd);
                DataTable dt = new DataTable("Books");
                sda.Fill(dt);
                grdTable.ItemsSource = dt.DefaultView;
            }
        }

        private void Sort_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand scd = new SqlCommand("SELECT * FROM Books ORDER BY Name", connection);
                SqlDataAdapter sda = new SqlDataAdapter(scd);
                DataTable dt = new DataTable("Books");
                sda.Fill(dt);
                grdTable.ItemsSource = dt.DefaultView;
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Text == string.Empty)
            {
                MessageBox.Show("Enter the name of book for deleting");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sqlExpression = string.Format("DELETE  FROM Books WHERE Name='{0}'", Name.Text);
                    SqlCommand scd = new SqlCommand(sqlExpression, connection);
                    scd.ExecuteNonQuery();
                    MessageBox.Show("Deleted");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
