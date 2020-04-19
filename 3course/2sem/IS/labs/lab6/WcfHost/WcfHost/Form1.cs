using System.Windows.Forms;
using System.ServiceModel;

namespace WcfHost
{
    public partial class Form1 : Form
    {
        private ServiceHost serviceHost;

        public Form1()
        {
            InitializeComponent();
            serviceHost = new ServiceHost(typeof(WcfServiceLibrary.Service1));
            serviceHost.Open();
        }

        private void label1_Click(object sender, System.EventArgs e)
        {

        }
    }
}