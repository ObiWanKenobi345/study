using System.Web.Services;

[WebService(Namespace = "http://io.github.kotelliada/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class Service : System.Web.Services.WebService
{
    public Service () {}

    [WebMethod]
    public string HelloWorld() {
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
}