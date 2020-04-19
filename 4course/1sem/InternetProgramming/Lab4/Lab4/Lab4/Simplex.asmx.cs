using System.Web.Services;

namespace Lab4
{
    [WebService(Namespace = "http://KDI/", Description = "Kotov Web Service")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class Simplex : System.Web.Services.WebService
    {

        [WebMethod(Description = "Simply returnes \"Hello World\" string.", MessageName = "HelloWorld")]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod(Description = "Returns sum of two numbers.", MessageName = "AddNumbers")]
        public int Add(int x, int y)
        {
            return x + y;
        }

        [WebMethod(Description = "Returns two concatenated strings", MessageName = "ConcatenateStrings")]
        public string Concat(string s, double d)
        {
            return s + d;
        }

        [WebMethod(Description = "Returns sum of two objects", MessageName = "AddObjects")]
        public A Sum(A a1, A a2)
        {
            A result = new A();
            result.s = a1.s + a2.s;
            result.k = a1.k + a2.k;
            result.f = a1.f + a2.f;
            return result;
        }
        
        [WebMethod]
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json, UseHttpGet = false)]
        public int AddS(int x, int y)
        {
            return x + y;
        }
    }
}