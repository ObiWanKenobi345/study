using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public int ColSize;
        private List<int> col = new List<int>();
        public Form1()
        {
            InitializeComponent();
        }

        private void GenButton_Click(object sender, EventArgs e)
        {
            col.Clear();
            CollectionTextBox.Clear();
            ColSize = int.Parse(SizeTextBox.Text);

            Random random = new Random();
            for (int i = 0; i < ColSize; i++)
            {
                col.Add(random.Next(0, 500));
            }
            foreach (var item in col)
            {
                CollectionTextBox.Text += (item.ToString() + Environment.NewLine);
            }
        }

        private void SortVozrButton_Click(object sender, EventArgs e)
        {
            newTextBox.Clear();
            var sort1 = from i in col
                        orderby i
                        select i;

            foreach (var item in sort1)
            {
                newTextBox.Text += (item.ToString() + Environment.NewLine);
            }
        }

        private void SortUbButton_Click(object sender, EventArgs e)
        {
            newTextBox.Clear();
            var sort2 = from i in col
                        orderby i descending
                        select i; 

            foreach (var item in sort2)
            {
                newTextBox.Text += (item.ToString() + Environment.NewLine);
            }
        }

        private void MinElemButton_Click(object sender, EventArgs e)
        {
            newTextBox.Clear();
            var minElem = col.Min();
            newTextBox.Text = minElem.ToString();
        }

        private void MaxElemButton_Click(object sender, EventArgs e)
        {
            newTextBox.Clear();
            var maxElem = col.Max();
            newTextBox.Text = maxElem.ToString();
            
        }

        private void SumElem_Click(object sender, EventArgs e)
        {
            newTextBox.Clear();
            var minElem = col.Sum();
            newTextBox.Text = minElem.ToString();
        }
    }
}
