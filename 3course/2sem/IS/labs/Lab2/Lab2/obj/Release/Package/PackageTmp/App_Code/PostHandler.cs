using System.Web;

public class PostHandler : IHttpHandler
{
    public bool IsReusable { get { return false; } }

    public void ProcessRequest(HttpContext context)
    {
        HttpRequest request = context.Request;
        HttpResponse response = context.Response;

        string parmA = request["ParmA"];
        string parmB = request["ParmB"];

        string result = "POST-Http-SAS:";

        if (parmA != null)
            result += "ParmA = " + parmA;
        if (parmB != null)
            result += ", ParmB = " + parmB;

        response.Write(result);
    }
}