using System;
using System.Web.UI.WebControls;
using System.Drawing;

namespace HtmlElements1
{
    public partial class FFE : System.Web.UI.Page
    {
        private string tag = "currentAddRotatorPosition";
        private string[] keywords = { "", "g1", "g2" };

        private int CuurentAddRotatorPosition
        {
            set
            {
                ViewState[tag] = value;
            }
            get
            {
                object value = ViewState[tag];
                if (value == null)
                    ViewState[tag] = 0;
                return (int) ViewState[tag];
            }
        }

        protected void ChangeViewButton_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = (MultiView1.ActiveViewIndex + 1) % 3;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "One shot";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox2.Text = "Two shot";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            TextBox3.Text = "Three shot";
        }

        protected void ChangeRotatorKeywordButton_Click(object sender, EventArgs e)
        {
            int newPosition = ++CuurentAddRotatorPosition % keywords.Length;
            AddRotator1.KeywordFilter = keywords[newPosition];
        }

        protected void Wizard1_NextButtonClick(object sender, WizardNavigationEventArgs e)
        {
            if (e.CurrentStepIndex == 3)
            {
                FirstNameResult.Text = FirstNameTextBox.Text;
                LastNameResult.Text = LastNameTextBox.Text;
                GenderResult.Text = GenderListBox.SelectedValue;
                DateOfBirthResult.Text = Calendar.SelectedDate.ToString();
                EmailAddressResult.Text = EmailAddressTextBox.Text;
                PhoneNumberResult.Text = MobilePhoneTextBox.Text;
                NativeLanguageResult.Text = NativeLanguageList.SelectedValue;

                string interests = "";
                foreach (ListItem li in InterestsList.Items)
                    if (li.Selected)
                        interests += li.Value + ", ";

                if (interests.Length > 0)
                    interests = interests.Remove(interests.Length - 2, 2);

                InterestsResult.Text = interests;
            }
        }

        protected void Wizard1_CancelButtonClick(object sender, EventArgs e)
        {
            Wizard wizard = (Wizard) sender;
            wizard.ActiveStepIndex = 0;

            FirstNameTextBox.Text = String.Empty;
            LastNameTextBox.Text = String.Empty;
            GenderListBox.SelectedIndex = -1;
            Calendar.SelectedDate = DateTime.Now;
            EmailAddressTextBox.Text = String.Empty;
            MobilePhoneTextBox.Text = String.Empty;
            NativeLanguageList.SelectedIndex = -1;
            InterestsList.SelectedIndex = -1;

            FirstNameResult.Text = String.Empty;
            LastNameResult.Text = String.Empty;
            GenderResult.Text = String.Empty;
            DateOfBirthResult.Text = String.Empty;
            EmailAddressResult.Text = String.Empty;
            PhoneNumberResult.Text = String.Empty;
            NativeLanguageResult.Text = String.Empty;
            InterestsResult.Text = String.Empty;
        }

        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {
            
        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            Menu menu = (Menu) sender;
            TextBox3.Text = menu.SelectedItem.Value;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}