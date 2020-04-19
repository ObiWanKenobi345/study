using System;
using System.Web;

namespace Caching
{
    public partial class one : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Label1.Text += DateTime.Now.ToString() + "<br />";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        private static string GetDate(HttpContext context)
        {
            return "<b>" + DateTime.Now.ToString() + "</b>";
        }
    }
}