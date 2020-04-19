using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows;

namespace KP
{
    /// <summary>
    /// Логика взаимодействия для UserOrder.xaml
    /// </summary>
    public partial class UserOrder : Window
    {
        string connectionString;
        public UserOrder()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void ButtonBackClick(object sender, RoutedEventArgs e)
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
            if (!Regex.IsMatch(QuantityTextBox.Text, "^[0-9]+$"))
            {
                MessageBox.Show("Для ввода количества используйте цифры");
                return;
            }
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand scd = new SqlCommand(
                        "insert into [Заказ_кафе] ( [Ингредиент], [Количество], [Ед_изм], [Кафе], [Дата_заказа]) " +
                        "values (@product, @quantity, @unit, @cafe, @date)",
                        connection
                    );

                    string sqlExpression = string.Format("UPDATE Склад set Количество = Количество - '{0}' WHERE Ингредиент = '{1}'", QuantityTextBox.Text, ProductComboBox.Text);
                    SqlCommand upd = new SqlCommand(sqlExpression, connection);
                    upd.ExecuteNonQuery();

                    scd.Parameters.AddWithValue("@product", ProductComboBox.Text);
                    scd.Parameters.AddWithValue("@quantity", QuantityTextBox.Text);
                    scd.Parameters.AddWithValue("@unit", UnitComboBox.Text);
                    scd.Parameters.AddWithValue("@cafe", CafeComboBox.Text);
                    scd.Parameters.AddWithValue("@date", DateTime.Now);
                    scd.ExecuteNonQuery();
                    MessageBox.Show("Заказ добавлен");
                    Update();
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
                ProductComboBox.Text == String.Empty ||
                QuantityTextBox.Text == String.Empty ||
                UnitComboBox.Text == String.Empty ||
                CafeComboBox.Text == String.Empty
            ) return false;
            return true;
        }

        private void Update()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand scd = new SqlCommand(
                    "SELECT * FROM Заказ_кафе"
                    , connection);
                SqlDataAdapter sda = new SqlDataAdapter(scd);
                DataTable dt = new DataTable("Заказ_кафе");
                sda.Fill(dt);
                grdTable.ItemsSource = dt.DefaultView;
            }
        }

        private void ButtonUpdateClick(object sender, RoutedEventArgs e)
        {
            Update();
        }



    }
}
