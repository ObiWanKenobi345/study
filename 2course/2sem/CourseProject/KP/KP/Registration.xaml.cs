using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace KP
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        string connectionString;
        public Registration()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void SubmitButtonClick(object sender, RoutedEventArgs e)
        {
            if (!CheckFields())
            {
                MessageBox.Show("Поля пусты или  пароли не совпадают");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String query = "SELECT Логин FROM Пользователи WHERE Логин=@login";
                    SqlCommand sqlCmd = new SqlCommand(query, connection);
                    sqlCmd.Parameters.AddWithValue("@login", LoginTextBox.Text);
                    SqlDataReader reader = sqlCmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        MessageBox.Show("Данный пользователь уже зарегистрирован");
                        LoginTextBox.Clear();
                        PasswordBox.Clear();
                        ConfirmPasswordBox.Clear();
                    }
                    else
                    {
                        if (!Regex.IsMatch(LoginTextBox.Text, "^[a-zA-Z0-9]+$"))
                        {
                            MessageBox.Show("Неверный символ. Для логина и пароля используйте набор букв латиницы и цифры");
                            return;
                        }
                        if (!Regex.IsMatch(PasswordBox.Password, "^[a-zA-Z0-9]+$"))
                        {
                            MessageBox.Show("Неверный символ. Для логина и пароля используйте набор букв латиницы и цифры");
                            return;
                        }
                        if (!Regex.IsMatch(NameTextBox.Text, "^[а-яА-ЯёЁa-zA-Z]+$"))
                        {
                            MessageBox.Show("Неверный символ. Для имени и фамилии используйте набор букв латиницы или кириллицы");
                            return;
                        }
                        if (!Regex.IsMatch(SurnameTextBox.Text, "^[а-яА-ЯёЁa-zA-Z]+$"))
                        {
                            MessageBox.Show("Неверный символ. Для имени и фамилии используйте набор букв латиницы или кириллицы");
                            return;
                        }
                        SqlCommand scd = new SqlCommand(
                            "insert into [Пользователи] ([Логин], [Имя], [Фамилия],  [Пароль], [Дата_регистрации]) " +
                            "values (@login, @name, @surname, @password, @date)",
                            connection
                        );
                        scd.Parameters.AddWithValue("@login", LoginTextBox.Text);
                        scd.Parameters.AddWithValue("@name", NameTextBox.Text);
                        scd.Parameters.AddWithValue("@surname", SurnameTextBox.Text);
                        scd.Parameters.AddWithValue("@password", ConfirmPasswordBox.Password);
                        scd.Parameters.AddWithValue("@date", DateTime.Now);
                        scd.ExecuteNonQuery();
                        SuccessfulReg successfulReg = new SuccessfulReg();
                        successfulReg.Show();
                        this.Close();
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private bool CheckFields()
        {
            if (
                LoginTextBox.Text == String.Empty ||
                NameTextBox.Text == String.Empty ||
                SurnameTextBox.Text == String.Empty ||
                PasswordBox.Password == String.Empty ||
                ConfirmPasswordBox.Password == String.Empty ||
                PasswordBox.Password != ConfirmPasswordBox.Password
            ) return false;
            return true;
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }




    }
}
