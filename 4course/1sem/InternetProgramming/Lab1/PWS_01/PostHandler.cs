﻿using System;
using System.Web;
using Newtonsoft.Json;
namespace PWS_01
{
    public class PostHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
            session["result"] = Convert.ToInt32(request.Params["result"]);
            response.Write(JsonConvert.SerializeObject(session["result"]));
        }

        #endregion
    }
}
