using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows;
namespace KP
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        string connectionString;
        public Menu()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void ButtonCloseClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonAddClick(object sender, RoutedEventArgs e)
        {
            if (!CheckEmptyFields())
            {
                MessageBox.Show("Не все поля заполнены");
                return;
            }
            if (!Regex.IsMatch(IdTextBox.Text, "^[0-9]+$"))
            {
                MessageBox.Show("Для id используйте цифры");
                return;
            }
            if (!Regex.IsMatch(NameTextBox.Text, "^[а-яА-ЯёЁ]+$"))
            {
                MessageBox.Show("Для ввода наименования используйте кириллицу");
                return;
            }


            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand scd = new SqlCommand(
                        "insert into [Блюда] ([Id_блюда], [Категория], [Наименование], [Цена]) " +
                        "values (@id, @category, @name, @cost)",
                        connection
                    );
                    scd.Parameters.AddWithValue("@id", IdTextBox.Text);
                    scd.Parameters.AddWithValue("@category", CategoryComboBox.Text);
                    scd.Parameters.AddWithValue("@name", NameTextBox.Text);
                    scd.Parameters.AddWithValue("@cost", CostTextBox.Text);

                    scd.ExecuteNonQuery();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Неверный ввод");
            }
        }

        private bool CheckEmptyFields()
        {
            if (
                IdTextBox.Text == String.Empty ||
                CategoryComboBox.Text == String.Empty ||
                NameTextBox.Text == String.Empty ||
                CostTextBox.Text == String.Empty
            ) return false;
            return true;
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand scd = new SqlCommand(
                    "SELECT * FROM Блюда"
                    , connection);
                SqlDataAdapter sda = new SqlDataAdapter(scd);
                DataTable dt = new DataTable("Блюда");
                sda.Fill(dt);
                grdTable.ItemsSource = dt.DefaultView;
            }
        }

        private void ButtonDeleteClick(object sender, RoutedEventArgs e)
        {
            if (IdTextBox.Text == string.Empty)
            {
                MessageBox.Show("Введите id блюда, которое необходимо удалить");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sqlExpression = string.Format("DELETE  FROM Блюда WHERE Id_блюда='{0}'", IdTextBox.Text);
                    SqlCommand scd = new SqlCommand(sqlExpression, connection);
                    scd.ExecuteNonQuery();
                    MessageBox.Show("Блюдо удалено");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
