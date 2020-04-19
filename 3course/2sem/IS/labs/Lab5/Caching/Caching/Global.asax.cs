using System;
using System.Web;

namespace Caching
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
        }

        public override string GetVaryByCustomString(HttpContext context, string custom)
        {
            if (custom == "minorversion")
                return "Version=" + context.Request.Browser.MinorVersion.ToString();
            return base.GetVaryByCustomString(context, custom);
        }
    }
}