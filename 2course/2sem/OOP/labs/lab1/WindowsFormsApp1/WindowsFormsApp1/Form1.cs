using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            Text = "Calculator";


        }


        private void SlozhenieButton_Click(object sender, EventArgs e)
        {
            float a = float.Parse(textBox1.Text);
            float b = float.Parse(textBox2.Text);
            float c = a + b;
            textBox3.Text = Convert.ToString(c);
        }

        private void VichitanieButton_Click(object sender, EventArgs e)
        {
            float a = float.Parse(textBox1.Text);
            float b = float.Parse(textBox2.Text);
            float c = a - b;
            textBox3.Text = Convert.ToString(c);
        }

        private void DelenieButton_Click(object sender, EventArgs e)
        {
            float a = float.Parse(textBox1.Text);
            float b = float.Parse(textBox2.Text);
            try
            {
                if (b == 0)
                {
                    MessageBox.Show($"Нельля делить на ноль");
                }
                else
                {
                    float c = a / b;
                    textBox3.Text = Convert.ToString(c);
                }
            }
            catch (Exception)
            {
                throw new Exception("Ошибка при делении");
            }

        }

        private void UmnozhenieButton_Click(object sender, EventArgs e)
        {
            float a = float.Parse(textBox1.Text);
            float b = float.Parse(textBox2.Text);
            float c = a * b;
            textBox3.Text = Convert.ToString(c);
        }

        private void SinusButton_Click(object sender, EventArgs e)
        {
            float a = float.Parse(textBox1.Text);
            textBox3.Text = Convert.ToString(Math.Sin(a));
        }

        private void CosButton_Click(object sender, EventArgs e)
        {
            float a = float.Parse(textBox1.Text);
            textBox3.Text = Convert.ToString(Math.Cos(a));
        }

        private void SqrtButton_Click(object sender, EventArgs e)
        {
            float a = float.Parse(textBox1.Text);
            try
            {
                if (a < 0)
                {
                    MessageBox.Show($"Нельля найди корень из отрицательного числа");
                }
                else
                {
                    textBox3.Text = Convert.ToString(Math.Sqrt(a));
                }
            }
            catch (Exception)
            {
                throw new Exception("Ошибка при нахождении корня");
            }


        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string c = textBox3.Text;
            textBox1.Text = c;
            textBox2.Clear();
            textBox3.Clear();
            MessageBox.Show("Saved result:" + c);

        }

        private void Firstelem_TextChanged(object sender, EventArgs e)
        {

        }

        private void Secondelem_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        
    }
}
