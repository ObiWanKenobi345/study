using System;
using System.Collections.Generic;
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
using System.Data.Entity;


namespace lab8
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserContext context = new UserContext();
        public MainWindow()
        {
            InitializeComponent();
        }

        private bool CheckEmpty()
        {
            if (User_Name.Text != String.Empty && User_Age.Text != String.Empty && User_Car_Id.Text != String.Empty)
                return true;
            return false;
        }

        private void User_Add_Click(object sender, RoutedEventArgs e)
        {
            if (CheckEmpty())
            {
                try
                {
                    using (UserContext db = new UserContext())
                    {
                        int age = Convert.ToInt32(User_Age.Text);
                        int carId = Convert.ToInt32(User_Car_Id.Text);

                        User user = new User
                        {
                            Name = User_Name.Text,
                            Age = age,
                            CarId = carId
                        };
                        db.Users.Add(user);
                        db.SaveChanges();
                        MessageBox.Show("Добавлено");
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else MessageBox.Show("Поля пусты");
        }

        private void User_Delete_Click(object sender, RoutedEventArgs e)
        {
            int current_id = (UsersGrid.SelectedItem as User).Id;
            User current = (
                from r in context.Users
                where r.Id == current_id
                select r
            ).SingleOrDefault();

            context.Users.Remove(current);
            context.SaveChanges();
        }

        private void User_Update_Click(object sender, RoutedEventArgs e)
        {
            UsersGrid.ItemsSource = context.Users.ToList();
        }

        private bool CheckEmpty2()
        {
            if (Car_Model.Text != String.Empty && Car_color.Text != String.Empty && Car_year.Text != String.Empty)
                return true;
            return false;
        }

        private void Car_Add_Click(object sender, RoutedEventArgs e)
        {
            if (CheckEmpty2())
            {
                try
                {
                    using (UserContext db = new UserContext())
                    {
                        Car car = new Car { Model = Car_Model.Text, Color = Car_color.Text, Year = Car_year.Text };
                        db.Cars.Add(car);
                        db.SaveChanges();
                        MessageBox.Show("Машина добавлена");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else MessageBox.Show("Поля пусты");
        }

        private void Car_Delete_Click(object sender, RoutedEventArgs e)
        {
            int current_id = (CarsGrid.SelectedItem as Car).Id;
            Car current = (
                from r in context.Cars
                where r.Id == current_id
                select r
            ).SingleOrDefault();

            context.Cars.Remove(current);
            context.SaveChanges();
        }

        private void Car_Update_Click(object sender, RoutedEventArgs e)
        {
            CarsGrid.ItemsSource = context.Cars.ToList();
        }

    }
}
