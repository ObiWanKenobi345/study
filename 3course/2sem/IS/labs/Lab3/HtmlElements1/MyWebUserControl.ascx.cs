using System;

namespace HtmlElements1
{
    public partial class MyWebUserControl : System.Web.UI.UserControl
    {
        public String Surname
        {
            set { this.SurnameTextBox.Text = value; }
            get { return this.SurnameTextBox.Text; }
        }

        public String FirstName
        {
            set { this.NameTextBox.Text = value; }
            get { return this.NameTextBox.Text; }
        }

        public String MiddleName
        {
            set { this.MiddleNameTextBox.Text = value; }
            get { return this.MiddleNameTextBox.Text; }
        }

        public String DateOfBirth
        {
            set { this.DateOfBirthTextBox.Text = value; }
            get { return this.DateOfBirthTextBox.Text; }
        }

        public int Gender
        {
            set { this.GenderList.SelectedIndex = value; }
            get { return this.GenderList.SelectedIndex; }
        }

        public int Faculty
        {
            set { this.FacultyList.SelectedIndex = value; }
            get { return this.FacultyList.SelectedIndex; }
        }

        public String Group
        {
            set { this.GroupTextBox.Text = value; }
            get { return this.GroupTextBox.Text; }
        }

        public String StartYear
        {
            set { this.StartYearTextBox.Text = value; }
            get { return this.StartYearTextBox.Text; }
        }

        public String EnterButtonText
        {
            set { this.EnterButton.Text = value; }
            get { return this.EnterButton.Text; }
        }

        public String CancelButtonText
        {
            set { this.CancelButton.Text = value; }
            get { return this.CancelButton.Text; }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Surname = FirstName = MiddleName = DateOfBirth = Group = StartYear = String.Empty;
            Gender = Faculty = -1;
        }

        protected void EnterButton_Click(object sender, EventArgs e)
        {

        }
    }
}