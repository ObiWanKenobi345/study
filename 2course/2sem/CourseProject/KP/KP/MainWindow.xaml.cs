using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace KP
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
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }



        private void ButtonEnter_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {

                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();

                String query = "SELECT COUNT(1) FROM Пользователи WHERE Логин=@Username AND Пароль=@Password";
                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@Username", TextBoxLogin.Text);
                sqlCmd.Parameters.AddWithValue("@Password", TextPasswordBox.Password);
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (count == 1)
                {
                    if (TextBoxLogin.Text == "admin")
                    {
                        AdminWindow win = new AdminWindow();
                        win.Show();
                        this.Close();
                    }
                    else
                    {
                        UserWindow win = new UserWindow();
                        win.Show();
                        this.Close();
                    }

                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Отсутствует соединение с базой данных");
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        private void ButtonReg_Click(object sender, RoutedEventArgs e)
        {
            Registration reg = new Registration();
            reg.Show();
            this.Close();
        }

    }
}
