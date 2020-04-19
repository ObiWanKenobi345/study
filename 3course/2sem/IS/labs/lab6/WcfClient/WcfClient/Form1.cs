using System.Windows.Forms;

namespace WcfClient
{
    public partial class Form1 : Form
    {
        private ServiceReference1.Service1Client client;

        public Form1()
        {
            InitializeComponent();
            client = new ServiceReference1.Service1Client();
            client.Open();
        }

        private void textBox1_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void SumButton_Click(object sender, System.EventArgs e)
        {
            int val1 = int.Parse(textBox1.Text);
            int val2 = int.Parse(textBox2.Text);
            ResultTextBox.Text = client.Add(val1, val2).ToString();
        }

        private void SubButton_Click(object sender, System.EventArgs e)
        {
            int val1 = int.Parse(textBox1.Text);
            int val2 = int.Parse(textBox2.Text);
            ResultTextBox.Text = client.Sub(val1, val2).ToString();
        }

        private void ConcatButton_Click(object sender, System.EventArgs e)
        {
            string val1 = textBox1.Text;
            string val2 = textBox2.Text;
            ResultTextBox.Text = client.Concat(val1, val2);
        }
    }
}