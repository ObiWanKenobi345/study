using System;
using System.Web;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace PWS_01
{
    public class GetHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        /// <summary>
        /// Вам потребуется настроить этот обработчик в файле Web.config вашего 
        /// веб-сайта и зарегистрировать его с помощью IIS, чтобы затем воспользоваться им.
        /// см. на этой странице: https://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpHandler Members

        public bool IsReusable
        {
            // Верните значение false в том случае, если ваш управляемый обработчик не может быть повторно использован для другого запроса.
            // Обычно значение false соответствует случаю, когда некоторые данные о состоянии сохранены по запросу.
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            var session = context.Session;
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;
            int result = context.Session["result"] != null ? (int)context.Session["result"] : 0;

            if (session["stack"] == null) session["stack"] = new Stack<int>( );
            var stack = (Stack<int>)session["stack"];

            if (stack.Count == 0) stack.Push(0);

            var resultNumber = stack.Peek( ) + Convert.ToInt32(session["result"]);

            response.Write(JsonConvert.SerializeObject(resultNumber));
        }

        #endregion
    }
}
