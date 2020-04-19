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

namespace ООП13
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AdapterButton_Click(object sender, RoutedEventArgs e)
        {
            // путешественник
            Driver driver = new Driver();
            // машина
            Auto auto = new Auto();
            // отправляемся по X
            driver.Travel(auto);
            // закончили идти по Х ,переходим на движение по Y
            AutoY autoY = new AutoY();
            // используем адаптер
            ITransport AutoYTransport = new AutoYToTransportAdapter(autoY);
            // продолжаем путь по Y
            driver.Travel(AutoYTransport);
        }

        private void DecoratorButton_Click(object sender, RoutedEventArgs e)
        {
            Autobus Autobus1 = new ItalianAutobus();
            Autobus1 = new RedAutobus(Autobus1);
            MessageBox.Show($"Название: {Autobus1.Name}");
            MessageBox.Show($"Цена: {Autobus1.GetCost()}");

            Autobus Autobus2 = new ItalianAutobus();
            Autobus2 = new OpenRoofAutobus(Autobus2);
            MessageBox.Show($"Название: {Autobus2.Name}");
            MessageBox.Show($"Цена: {Autobus2.GetCost()}");

            Autobus Autobus3 = new BulgerianAutobus();
            Autobus3 = new RedAutobus(Autobus3);
            Autobus3 = new OpenRoofAutobus(Autobus3);
            MessageBox.Show($"Название: {Autobus3.Name}");
            MessageBox.Show($"Цена: {Autobus3.GetCost()}");
        }

        private void CompositeButton_Click(object sender, RoutedEventArgs e)
        {
            Component fileSystem = new Directory("Файловая система");
            // определяем новый диск
            Component diskC = new Directory("Диск С");
            // новые файлы
            Component pngFile = new File("12345.png");
            Component docxFile = new File("Document.docx");
            // добавляем файлы на диск С
            diskC.Add(pngFile);
            diskC.Add(docxFile);
            // добавляем диск С в файловую систему
            fileSystem.Add(diskC);
            // выводим все данные
            fileSystem.Print();
            Console.WriteLine();
            // удаляем с диска С файл
            diskC.Remove(pngFile);
            // создаем новую папку
            Component docsFolder = new Directory("Мои Документы");
            // добавляем в нее файлы
            Component txtFile = new File("readme.txt");
            Component csFile = new File("Program.cs");
            docsFolder.Add(txtFile);
            docsFolder.Add(csFile);
            diskC.Add(docsFolder);

            fileSystem.Print();
        }
    }
}
