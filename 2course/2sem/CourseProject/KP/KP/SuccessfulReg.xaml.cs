using System.Windows;

namespace KP
{
    /// <summary>
    /// Логика взаимодействия для SuccessfulReg.xaml
    /// </summary>
    public partial class SuccessfulReg : Window
    {
        public SuccessfulReg()
        {
            InitializeComponent();
        }

        private void ButtonEnter_Click(object sender, RoutedEventArgs e)
        {
            UserWindow userWindow = new UserWindow();
            userWindow.Show();
            this.Close();
        }
    }
}
