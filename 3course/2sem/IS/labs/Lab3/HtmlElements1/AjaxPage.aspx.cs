using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HtmlElements1
{
    public partial class AjaxPage : System.Web.UI.Page
    {
        private int Counter1
        {
            get
            {
                object counter1 = ViewState["counter1"];
                if (counter1 == null)
                    ViewState["counter1"] = 0;
                return (int) ViewState["counter1"];
            }

            set
            {
                ViewState["counter1"] = value;
            }
        }

        private int Counter2
        {
            get
            {
                object counter2 = ViewState["counter2"];
                if (counter2 == null)
                    ViewState["counter2"] = 0;
                return (int)ViewState["counter2"];
            }

            set
            {
                ViewState["counter2"] = value;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(15000);
            Label1.Text = "Button 1 clicked";
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            Label1.Text = "CheckBox1 checked";
        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Label1.Text = "RadioButton1 checked";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            throw new ApplicationException("Server side error occurred");
        }

        protected void AsyncPostBackButton_Click(object sender, EventArgs e)
        {
            Label2.Text = "AsyncPostBack";
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            ++Counter1;
            Counter1Label.Text = Counter1.ToString();
        }

        protected void Timer2_Tick(object sender, EventArgs e)
        {
            ++Counter2;
            Counter2Label.Text = Counter2.ToString();
        }

        protected void RefreshTime_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(4000);
            TimeLabel.Text = DateTime.Now.ToString();
        }
    }
}