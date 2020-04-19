using System;
using System.Web;
using System.Net.WebSockets;
using System.Threading.Tasks;
using System.Web.WebSockets;
using System.Threading;

public class WebSocketHandler : IHttpHandler
{
    private WebSocket webSocket;

    public bool IsReusable { get { return false; } }

    public void ProcessRequest(HttpContext context)
    {
        if (context.IsWebSocketRequest)
            context.AcceptWebSocketRequest(WebSocketRequest);
    }

    private async Task WebSocketRequest(AspNetWebSocketContext context)
    {
        webSocket = context.WebSocket;
        while (webSocket.State == WebSocketState.Open)
        {
            Thread.Sleep(2000);
            DateTime currentTime = DateTime.Now;
            string str = currentTime.Hour + ":" + currentTime.Minute + ":" + currentTime.Second;
            await Send(str);
        }
    }

    private async Task Send(string date)
    {
        var sendBuffer = new ArraySegment<byte>(System.Text.Encoding.UTF8.GetBytes(date));
        await webSocket.SendAsync(sendBuffer, WebSocketMessageType.Text, true, CancellationToken.None);
    }
}