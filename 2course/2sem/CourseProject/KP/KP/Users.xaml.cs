using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace KP
{
    /// <summary>
    /// Логика взаимодействия для Users.xaml
    /// </summary>
    public partial class Users : Window
    {
        string connectionString;
        public Users()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void ButtonCloseClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private bool CheckEmptyFields()
        {
            if (
                LoginTextBox.Text == String.Empty ||
                PasswordTextBox.Text == String.Empty

            ) return false;
            return true;
        }


        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand scd = new SqlCommand("SELECT * FROM Пользователи WHERE not Логин='admin'", connection);
                SqlDataAdapter sda = new SqlDataAdapter(scd);
                DataTable dt = new DataTable("Пользователи");
                sda.Fill(dt);
                grdTable.ItemsSource = dt.DefaultView;
            }
        }

        private void ButtonDeleteClick(object sender, RoutedEventArgs e)
        {
            if (LoginTextBox.Text == string.Empty)
            {
                MessageBox.Show("Введите логин пользователя, которого необходимо удалить");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sqlExpression = string.Format("DELETE  FROM Пользователи WHERE Логин='{0}'", LoginTextBox.Text);
                    SqlCommand scd = new SqlCommand(sqlExpression, connection);
                    scd.ExecuteNonQuery();
                    MessageBox.Show("Пользователь удален");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonChangePassClick(object sender, RoutedEventArgs e)
        {
            if (LoginTextBox.Text == string.Empty || PasswordTextBox.Text == string.Empty)
            {
                MessageBox.Show("Введите логин и новый пароль");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sqlExpression = string.Format("UPDATE Пользователи set Пароль='{0}' where Логин='{1}'", PasswordTextBox.Text, LoginTextBox.Text);
                    SqlCommand scd = new SqlCommand(sqlExpression, connection);
                    scd.ExecuteNonQuery();
                    MessageBox.Show("Пароль изменен");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
