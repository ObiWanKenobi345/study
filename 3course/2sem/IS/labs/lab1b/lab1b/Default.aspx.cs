using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lab1b
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.TextBox1.Text = "*" + this.TextBox1.Text + "*";
            String s = Request["__VIEWSTATE"];
            this.Label1.Text = "[" + s.Length + "]" + "[" + this.TextBox1.Text.Length + "]";
        }
    }
}