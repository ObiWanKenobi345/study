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
namespace OOP10
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
           
            InitializeComponent();
            using (Model1 db = new Model1())
            {
                Storage lol = new Storage { Vid = "Деревянный", Ima = "Нож", Cena = "151", Kol = 3 };
                Storage lol1 = new Storage { Vid = "Железный", Ima = "Ящик", Cena = "145", Kol = 4 };
                Storage lol2 = new Storage { Vid = "Стеклянная", Ima = "Панель", Cena = "132", Kol = 5 };
                db.Store.Add(lol);
                db.Store.Add(lol1);
                db.Store.Add(lol2);
                db.SaveChanges();
                var u = db.Store;


                List<Sklad> stores = new List<Sklad>();
                foreach (Storage art in db.Store)
                {
                    stores.Add(new Sklad(art.Vid, art.Ima, art.Cena, art.Kol));
                }
                DataContext = new MainViewModel(stores);
            }
        }
    }
}
