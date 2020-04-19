using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace lab2
{
    public partial class Form1 : Form
    {
        List<Team> team = new List<Team>();
        List<Plane> plane = new List<Plane>();

        public Form1()
        {          
            InitializeComponent();

            TypeComboBox.Items.AddRange(new string[] { "Пассажирский", "Грузовой", "Военный" });
            ModelComboBox.Items.AddRange(new string[] { "Airbus", "Boeing", "Embraer" });

            team.Add(new Team("Валерий", "пилот", 30, 5));
            team.Add(new Team("Николай", "пилот", 42, 12));
            team.Add(new Team("Анна", "пилот", 22, 2));
            team.Add(new Team("Мария", "пилот", 23, 3));

            foreach (Team i in team)
            {
                TeamListBox.Items.Add(i);
            }           

            
        }
       
        public class Team
        {
            string name;
            string work;
            int age;
            int exp; 

            public string Name { get => name; set => name = value; }
            public string Work { get => work; set => work = value; }
            public int Age { get => age; set => age = value; }
            public int Exp { get => exp; set => exp = value; }

            public Team(string _name, string _work, int _age, int _exp)
            {
                Name = _name;
                Work = _work;
                Age = _age;
                Exp = _exp;
            }

            public Team()
            {
                Name = " ";
                Work = " ";
                Age = 0;
                Exp = 0;
            }
            public override string ToString()
            {
                return Name + ", " + Work + ", возраст: " + Age + ", стаж: " + Exp;
            }
        }
        
        public class Plane
        {
            private int _id;
            private string _type;
            private string _model;
            private Team _team;
            private int _places;
            private int _year;
            private int capacity;
            private DateTime _teh;

            public int Id { get => _id; set => _id = value; }
            public string Type { get => _type; set => _type = value; }
            public string Model { get => _model; set => _model = value; }
            public Team Team { get => _team; set => _team = value; }
            public int Places { get => _places; set => _places = value; }
            public int Year { get => _year; set => _year = value; }
            public int Capacity { get => capacity; set => capacity = value; }
            public DateTime Teh { get => _teh; set => _teh = value; }


            public Plane()
            {
                Id = 0;
                Type = "";
                Model = "";
                Team = new Team();
                Places = 0;
                Year = 0;
                Capacity = 0;
                Teh = new DateTime();              
                                
            }

            public Plane(int id, string type, string model, Team team, int places, int year, int capacity,
                DateTime teh)
            {
                Id = id;
                Type = type;
                Model = model;
                Team = team;
                Places = places;
                Year = year;
                Capacity = capacity;
                Teh = teh;                
            }            

            public override string ToString()
            {
                return "Id: " + Id + ", Тип: " + Type + ", Модель: " + Model + ", Экипаж: " + Team.ToString() 
                    + ", Места: " + Places + ", Год выпуска: " + Year + ", Грузоподъёмн.: " + Capacity.ToString() 
                    + ", Дата тех. обсл.: " + Teh.Date.ToString();
                
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (IdTextBox.Text == String.Empty)
                {
                    MessageBox.Show($"Введите id");
                }
                if (TypeComboBox.Text == String.Empty)
                {
                    MessageBox.Show($"Выберите тип");
                }
                if (ModelComboBox.Text == String.Empty)
                {
                    MessageBox.Show($"Выберите модель");
                }
                if (TeamListBox.Text == String.Empty)
                {
                    MessageBox.Show($"Выберите члена команды");
                }
                if (PlacesTextBox.Text == String.Empty)
                {
                    MessageBox.Show($"Введите количество мест");
                }
                if (YearTextBox.Text == String.Empty)
                {
                    MessageBox.Show($"Введите год");
                }
                if (trackBar1.Value == 0)
                {
                    MessageBox.Show($"Укажите грузоподъемность");
                }
                else
                {
                    plane.Add(new Plane(int.Parse(IdTextBox.Text), TypeComboBox.SelectedItem.ToString(),
               ModelComboBox.SelectedItem.ToString(), TeamListBox.SelectedItem as Team,
               int.Parse(PlacesTextBox.Text), int.Parse(YearTextBox.Text), int.Parse(trackBar1.Value.ToString()),
               monthCalendar1.SelectionRange.Start));

                    infoBox.Clear();

                    for (int i = 0; i < plane.Count; i++) { infoBox.Text += plane[i].ToString() + Environment.NewLine; }
                }
            }
            catch (Exception)
            {
                throw new Exception("Ошибка ввода");
            }

           
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Plane>));

            using (FileStream fs = new FileStream("E:/Для учёбы/2 курс/2 сем/ООП/labs/lab3/planes.xml", 
                FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, plane);
            }
        }

        private void UploadButton_Click(object sender, EventArgs e)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Plane>));

            using (FileStream fs = new FileStream("E:/Для учёбы/2 курс/2 сем/ООП/labs/lab3/planes.xml", 
                FileMode.OpenOrCreate))
            {
                plane = (List<Plane>)formatter.Deserialize(fs);
            }

            infoBox.Clear();

            for (int i = 0; i < plane.Count; i++) { infoBox.Text += plane[i].ToString() + Environment.NewLine; }

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            trackBar1.Minimum = 50;
            trackBar1.Maximum = 150;
            label9.Text = String.Format("Тонн: {0}", trackBar1.Value);
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm {Text = "About"};
            aboutForm.Show();
        }

        private void ClearButton1_Click(object sender, EventArgs e)
        {
            infoBox.Clear();
        }

        private void ClearButton2_Click(object sender, EventArgs e)
        {
            ResultListView.Items.Clear();
        }

        private void TypeSearchButton_Click(object sender, EventArgs e)
        {
            var sample = SearchTextBox.Text;
            var regexp = new Regex(sample);
            
            ResultListView.Clear();
            foreach (Plane i in plane)
            {
                if (regexp.IsMatch(i.Type))
                {
                    ResultListView.Items.Add(i.ToString());
                }
                
            }
        }
              

        private void PlacesSearchButton_Click(object sender, EventArgs e)
        {
            foreach (Plane i in plane)
            {
                if (i.Places == int.Parse(SearchTextBox.Text))
                {
                    ResultListView.Clear();
                    ResultListView.Items.Add(i.ToString());
                }
            }
        }

        
        private void CapacitySearchButton_Click(object sender, EventArgs e)
        {
            foreach (Plane i in plane)
            {
                if (i.Capacity == int.Parse(SearchTextBox.Text))
                {
                    ResultListView.Clear();
                    ResultListView.Items.Add(i.ToString());
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<string>));

            List<string> planeList = new List<string>
            {
               ResultListView.Items.ToString()
            };
            
            using (FileStream fs = new FileStream("E:/Для учёбы/2 курс/2 сем/ООП/labs/lab3/resultSearch.xml",
                FileMode.OpenOrCreate))
            {
                ResultListView.Items.Clear();
                formatter.Serialize(fs, planeList);
            }
            

        }
       
        private void NameSortButton_Click(object sender, EventArgs e)
        {

            XDocument xdoc = XDocument.Load("E:/Для учёбы/2 курс/2 сем/ООП/labs/lab3/planes.xml");
            var names =
            (from p in xdoc.Descendants("Plane")
             orderby p.Element("Model").Value ascending
             select new
             {
                 Id = p.Element("Id").Value,
                 Type = p.Element("Type").Value,
                 Model = p.Element("Model").Value,
                 
             });

            ResultListView.Clear();
            foreach (var p in names)
            {
                ResultListView.Items.Add(p.Model);
                ResultListView.Items.Add(p.Id);
                ResultListView.Items.Add(p.Type);
                

            }
        }

        private void IdSearchButton_Click(object sender, EventArgs e)
        {
            XDocument xdoc = XDocument.Load("E:/Для учёбы/2 курс/2 сем/ООП/labs/lab3/planes.xml");
            var ids =
            (from p in xdoc.Descendants("Plane")
             orderby p.Element("Id").Value ascending
             select new
             {
                 Type = p.Element("Type").Value,
                 Model = p.Element("Model").Value,
                 Id = p.Element("Id").Value,

             });

            ResultListView.Clear();
            foreach (var p in ids)
            {
                ResultListView.Items.Add(p.Id);
                ResultListView.Items.Add(p.Model);
                ResultListView.Items.Add(p.Type);
            }
        }

        private void YearSearchButton_Click(object sender, EventArgs e)
        {
            XDocument xdoc = XDocument.Load("E:/Для учёбы/2 курс/2 сем/ООП/labs/lab3/planes.xml");
            var years =
            (from p in xdoc.Descendants("Plane")
             orderby p.Element("Year").Value ascending
             select new
             {
                 Year = p.Element("Year").Value,
                 Model = p.Element("Model").Value,
                 Id = p.Element("Id").Value,
                 Type = p.Element("Type").Value,
             });

            ResultListView.Clear();
            foreach (var p in years)
            {
                ResultListView.Items.Add(p.Year);
                ResultListView.Items.Add(p.Id);
                ResultListView.Items.Add(p.Model);
                ResultListView.Items.Add(p.Type);
            }
        }

        private void ResultListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void IdTextBox_TextChanged(object sender, EventArgs e)
        {
                        
        }
    }
}
