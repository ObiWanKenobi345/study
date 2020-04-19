using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HtmlElements1
{
    public partial class PlausibilityСheck : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownList1.Items.Add("Item 1");
                DropDownList1.Items.Add("Item 2");
                DropDownList1.Items.Add("Item 3");
            }
        }

        protected void SimpleNumberValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            int value = int.Parse(args.Value);

            for (var i = 2; i < value; i++)
                if (value % i == 0) {
                    args.IsValid = false;
                    return;
                }
            args.IsValid = (value != 1);
        }
    }
}