using System.Web;

public class PostMathHandler : IHttpHandler
{
    public bool IsReusable { get { return false; } }

    public void ProcessRequest(HttpContext context)
    {
        HttpRequest request = context.Request;
        HttpResponse response = context.Response;

        string paramX = request["x"];
        string paramY = request["y"];

        int sum = 0;
        int x = 0;
        int y = 0;

        if (paramX != null)
            x = int.Parse(paramX);
        if (paramY != null)
            y = int.Parse(paramY);

        sum = x + y;

        response.Write(sum);
    }
}