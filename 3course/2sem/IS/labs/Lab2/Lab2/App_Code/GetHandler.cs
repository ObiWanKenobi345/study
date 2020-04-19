using System.Web;

public class GetHandler : IHttpHandler
{
    public bool IsReusable { get { return false; } }

    public void ProcessRequest(HttpContext context)
    {
        HttpRequest request = context.Request;
        HttpResponse response = context.Response;

        string parmA = request.QueryString["ParmA"];
        string parmB = request.QueryString["ParmB"];

        string result = "GET-Http-SAS:";

        if (parmA != null)
            result += "ParmA = " + parmA;
        if (parmB != null)
            result += ", ParmB = " + parmB;

        response.Write(result);
    }
}