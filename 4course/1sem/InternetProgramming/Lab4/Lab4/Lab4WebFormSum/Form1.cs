using System;
using System.Windows.Forms;

namespace Lab4WebFormSum
{
    public partial class Form1 : Form
    {
        SimplexService.SimplexSoapClient serviceClient = new SimplexService.SimplexSoapClient("SimplexSoap");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) { }

        private void sendButton_Click(object sender, EventArgs e)
        {
            SimplexService.A a1 = new SimplexService.A();
            a1.s = a1s.Text;
            a1.k = Int32.Parse(a1k.Text);
            a1.f = float.Parse(a1f.Text);

            SimplexService.A a2 = new SimplexService.A();
            a2.s = a2s.Text;
            a2.k = Int32.Parse(a2k.Text);
            a2.f = float.Parse(a2f.Text);
            
            var result = serviceClient.Sum(a1, a2);
            resultS.Text = result.s;
            resultK.Text = result.k.ToString();
            resultF.Text = result.f.ToString();
        }

        private void label10_Click(object sender, EventArgs e) { }

        private void label11_Click(object sender, EventArgs e) {}

        private void AddButton_Click(object sender, EventArgs e)
        {
            int x = Int32.Parse(xInput.Text);
            int y = Int32.Parse(yInput.Text);

            var result = serviceClient.Add(x, y);
            resAdd.Text = result.ToString();
        }

        private void ConcatButton_Click(object sender, EventArgs e)
        {
            var s = sInput.Text;
            var d = Double.Parse(dInput.Text);

            var result = serviceClient.Concat(s, d);
            resConcat.Text = result;
        }
    }
}