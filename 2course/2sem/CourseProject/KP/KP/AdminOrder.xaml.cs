using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace KP
{
    /// <summary>
    /// Логика взаимодействия для AdminOrder.xaml
    /// </summary>
    public partial class AdminOrder : Window
    {
        string connectionString;
        public AdminOrder()
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
                        "insert into [Заказ_админ] ( [Поставщик], [Ингредиент], [Количество], [Ед_изм], [Дата_заказа]) " +
                        "values ( @supplier, @product, @quantity, @unit, @date)",
                        connection
                    );

                    string sqlExpression = string.Format("UPDATE Склад set Количество = Количество + '{0}' WHERE Ингредиент = '{1}'", QuantityTextBox.Text, ProductComboBox.Text);
                    SqlCommand upd = new SqlCommand(sqlExpression, connection);
                    upd.ExecuteNonQuery();
                    scd.Parameters.AddWithValue("@supplier", SupplierComboBox.Text);
                    scd.Parameters.AddWithValue("@product", ProductComboBox.Text);
                    scd.Parameters.AddWithValue("@quantity", QuantityTextBox.Text);
                    scd.Parameters.AddWithValue("@unit", UnitComboBox.Text);
                    scd.Parameters.AddWithValue("@date", DateTime.Now);
                    scd.ExecuteNonQuery();
                    MessageBox.Show("Заказ добавлен");
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
                SupplierComboBox.Text == String.Empty ||
                ProductComboBox.Text == String.Empty ||
                QuantityTextBox.Text == String.Empty ||
                UnitComboBox.Text == String.Empty
            ) return false;
            return true;
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand scd = new SqlCommand(
                        "SELECT Id_заказа, Поставщик, Заказ_админ.Ингредиент, Заказ_админ.Количество, Заказ_админ.Ед_изм, Заказ_админ.Дата_заказа, Заказ_админ.Количество*Склад.Цена_за_ед [Сумма в BYN] FROM Заказ_админ, Склад Where Заказ_админ.Ингредиент = Склад.Ингредиент"
                        , connection);
                    SqlDataAdapter sda = new SqlDataAdapter(scd);
                    DataTable dt = new DataTable("Заказ_админ");
                    sda.Fill(dt);
                    AdminOrderGrid.ItemsSource = dt.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ButtonDeleteClick(object sender, RoutedEventArgs e)
        {
            if (IdTextBox.Text == string.Empty)
            {
                MessageBox.Show("Введите id заказа, который необходимо удалить");
                return;
            }

            if (!Regex.IsMatch(IdTextBox.Text, "^[0-9]+$"))
            {
                MessageBox.Show("Для ввода id используйте цифры");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sqlExpression = string.Format("DELETE  FROM Заказ_админ WHERE Id_заказа='{0}'", IdTextBox.Text);
                    SqlCommand scd = new SqlCommand(sqlExpression, connection);
                    scd.ExecuteNonQuery();
                    MessageBox.Show("Заказ удален");
                    IdTextBox.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonDeleteUserOrderClick(object sender, RoutedEventArgs e)
        {
            if (IdTextBox.Text == string.Empty)
            {
                MessageBox.Show("Введите id заказа, который необходимо удалить");
                return;
            }

            if (!Regex.IsMatch(IdTextBox.Text, "^[0-9]+$"))
            {
                MessageBox.Show("Для ввода id используйте цифры");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sqlExpression = string.Format("DELETE  FROM Заказ_кафе WHERE Id_заказа='{0}'", IdTextBox.Text);
                    SqlCommand scd = new SqlCommand(sqlExpression, connection);
                    scd.ExecuteNonQuery();
                    MessageBox.Show("Заказ удален");
                    IdTextBox.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonUsersOrderClick(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand scd = new SqlCommand(
                    "SELECT * FROM Заказ_кафе"
                    , connection);
                SqlDataAdapter sda = new SqlDataAdapter(scd);
                DataTable dt = new DataTable("Заказ_кафе");
                sda.Fill(dt);
                UserOrderGrid.ItemsSource = dt.DefaultView;
            }
        }

        private void ButtonStockClick(object sender, RoutedEventArgs e)
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
                StockGrid.ItemsSource = dt.DefaultView;
            }
        }


        private void SupplierSelected(object sender, SelectionChangedEventArgs e)
        {

            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            if (selectedItem.Content.ToString() == "Kraft Heinz")
            {
                ProductComboBox.Items.Clear();
                ProductComboBox.Items.Add("Майонез");
                ProductComboBox.Items.Add("Горчица");
                ProductComboBox.Items.Add("Соус Сырный оригинальный");
                ProductComboBox.Items.Add("Кетчуп томатный");
                ProductComboBox.Items.Add("Соус Кисло-сладкий оригинальный");
                ProductComboBox.Items.Add("Соус Чесночный");
                ProductComboBox.Items.Add("Соус Терияки");
                ProductComboBox.Items.Add("Соус Барбекью");
            }
            if (selectedItem.Content.ToString() == "The Coca-Cola Company")
            {
                ProductComboBox.Items.Clear();
                ProductComboBox.Items.Add("Кола");
                ProductComboBox.Items.Add("Фанта");
                ProductComboBox.Items.Add("Спрайт");
                ProductComboBox.Items.Add("Вода BonAqua");
                ProductComboBox.Items.Add("Сок апельсиновый");
                ProductComboBox.Items.Add("Сок яблочный");
            }
            if (selectedItem.Content.ToString() == "ЗАО Мултон")
            {
                ProductComboBox.Items.Clear();
                ProductComboBox.Items.Add("Сок апельсиновый");
                ProductComboBox.Items.Add("Сок яблочный");
            }
            if (selectedItem.Content.ToString() == "ОАО 1-я минская птицефабрика")
            {
                ProductComboBox.Items.Clear();
                ProductComboBox.Items.Add("Курица");
                ProductComboBox.Items.Add("Сыр");
                ProductComboBox.Items.Add("Яйцо");
                ProductComboBox.Items.Add("Молоко");
            }
            if (selectedItem.Content.ToString() == "ОАО Пивзавод Оливария")
            {
                ProductComboBox.Items.Clear();
                ProductComboBox.Items.Add("Пиво");
            }
            if (selectedItem.Content.ToString() == "Минскхлебпром")
            {
                ProductComboBox.Items.Clear();
                ProductComboBox.Items.Add("Лепешка");
                ProductComboBox.Items.Add("Булочка");
                ProductComboBox.Items.Add("Гренки");
            }
            if (selectedItem.Content.ToString() == "ОАО Лидахлебопродукт")
            {
                ProductComboBox.Items.Clear();
                ProductComboBox.Items.Add("Мука");
            }
            if (selectedItem.Content.ToString() == "Unilever")
            {
                ProductComboBox.Items.Clear();
                ProductComboBox.Items.Add("Чай");
            }
            if (selectedItem.Content.ToString() == "АмиФрут")
            {
                ProductComboBox.Items.Clear();
                ProductComboBox.Items.Add("Помидор");
                ProductComboBox.Items.Add("Салат");
                ProductComboBox.Items.Add("Огурец");
                ProductComboBox.Items.Add("Лук");
                ProductComboBox.Items.Add("Картофель");
            }
            if (selectedItem.Content.ToString() == "Олейкино")
            {
                ProductComboBox.Items.Clear();
                ProductComboBox.Items.Add("Масло");
            }
            if (selectedItem.Content.ToString() == "СООО Морозпродукт")
            {
                ProductComboBox.Items.Clear();
                ProductComboBox.Items.Add("Мороженое");
            }
            if (selectedItem.Content.ToString() == "Nescafe")
            {
                ProductComboBox.Items.Clear();
                ProductComboBox.Items.Add("Кофе");
                ProductComboBox.Items.Add("Шоколад");
                ProductComboBox.Items.Add("Джем");
            }
        }


    }

}
