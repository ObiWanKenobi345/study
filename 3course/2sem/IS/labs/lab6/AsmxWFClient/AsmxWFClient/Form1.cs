using System;
using System.Windows.Forms;

namespace AsmxWFClient
{
    public partial class Form1 : Form
    {
        private ServiceReference1.XXXServiceSoapClient client;

        public Form1()
        {
            InitializeComponent();
            client = new ServiceReference1.XXXServiceSoapClient();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x = int.Parse(XTextBox.Text);
            int y = int.Parse(YTextBox.Text);
            ResultTextBox.Text = client.Add(x, y).ToString();
        }

        private void MinusButton_Click(object sender, EventArgs e)
        {
            int x = int.Parse(XTextBox.Text);
            int y = int.Parse(YTextBox.Text);
            ResultTextBox.Text = client.Sub(x, y).ToString();
        }

        private void MulButton_Click(object sender, EventArgs e)
        {
            int x = int.Parse(XTextBox.Text);
            int y = int.Parse(YTextBox.Text);
            ResultTextBox.Text = client.Mul(x, y).ToString();
        }

        private void GetStringButton_Click(object sender, EventArgs e)
        {
            string value = client.GetString();
            StringTextBox.Text = value;
        }

        private void SetStringButton_Click(object sender, EventArgs e)
        {
            client.SetString(StringTextBox.Text);
            StringTextBox.Text = String.Empty;
        }

        private void GetIntButton_Click(object sender, EventArgs e)
        {
            int value = client.getInt();
            IntTextBox.Text = value.ToString();
        }

        private void SetIntButton_Click(object sender, EventArgs e)
        {
            int value = int.Parse(IntTextBox.Text);
            client.setInt(value);
            IntTextBox.Text = "";
        }
    }
}