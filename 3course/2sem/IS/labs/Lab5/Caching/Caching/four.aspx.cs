using System;

namespace Caching
{
    public partial class four : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String x = "";
            foreach (String s in Request.QueryString)
                x += " " + s + " = " + Request[s];
            this.Label1.Text += x + ": " + DateTime.Now.ToString() + "<br />";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}