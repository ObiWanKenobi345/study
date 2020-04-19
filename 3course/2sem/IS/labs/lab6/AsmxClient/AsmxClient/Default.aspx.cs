using System;

namespace AsmxClient
{
    public partial class Default : System.Web.UI.Page
    {
        private ServiceReference1.XXXServiceSoapClient client;

        protected void Page_Load(object sender, EventArgs e)
        {
            client = new ServiceReference1.XXXServiceSoapClient();
        }

        protected void PlusButton_Click(object sender, EventArgs e)
        {
            int x = int.Parse(XTextBox.Text);
            int y = int.Parse(YTextBox.Text);
            ResultTextBox.Text = client.Add(x, y).ToString();
        }

        protected void MinusButton_Click(object sender, EventArgs e)
        {
            int x = int.Parse(XTextBox.Text);
            int y = int.Parse(YTextBox.Text);
            ResultTextBox.Text = client.Sub(x, y).ToString();
        }

        protected void MulButton_Click(object sender, EventArgs e)
        {
            int x = int.Parse(XTextBox.Text);
            int y = int.Parse(YTextBox.Text);
            ResultTextBox.Text = client.Mul(x, y).ToString();
        }

        protected void SetStringButton_Click(object sender, EventArgs e)
        {
            client.SetString(StringTextBox.Text);
            StringTextBox.Text = String.Empty;
        }

        protected void GetStringButton_Click(object sender, EventArgs e)
        {
            StringTextBox.Text = client.GetString();
        }

        protected void SetIntButton_Click(object sender, EventArgs e)
        {
            int value = int.Parse(IntTextBox.Text);
            client.setInt(value);
            IntTextBox.Text = String.Empty;
        }

        protected void GetIntButton_Click(object sender, EventArgs e)
        {
            IntTextBox.Text = client.getInt().ToString();
        }
    }
}