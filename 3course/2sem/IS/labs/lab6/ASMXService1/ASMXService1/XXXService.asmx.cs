using System.Web.Services;

namespace ASMXService1
{
    [WebService(Namespace = "http://kotelliada.github.io/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class XXXService : System.Web.Services.WebService
    {
        private const string KEY = "KEY";

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public int Add(int x, int y)
        {
            return x + y;
        }

        [WebMethod]
        public int Sub(int x, int y)
        {
            return x - y;
        }

        [WebMethod]
        public int Mul(int x, int y)
        {
            return x * y;
        }

        [WebMethod(EnableSession = true)]
        public void SetString(string value)
        {
            this.Session[KEY] = value;
        }

        [WebMethod(EnableSession = true)]
        public string GetString()
        {
            string value = "EMPTY!";
            if (this.Session[KEY] != null)
                value = (string)this.Session[KEY];
            return value;
        }

        [WebMethod]
        public void setInt(int value)
        {
            this.Application[KEY] = value;
        }

        [WebMethod]
        public int getInt()
        {
            int value = -1;
            if (this.Application[KEY] != null)
                value = (int)this.Application[KEY];
            return value;
        }
    }
}