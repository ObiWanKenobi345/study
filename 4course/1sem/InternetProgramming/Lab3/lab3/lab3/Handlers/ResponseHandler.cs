using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace lab3.Handlers
{
    public class ResponseHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            context.Result = new TextPlainErrorResult
            {
                Request = context.ExceptionContext.Request, 
                Content = "Oops! Sorry! Something went wrong." +
                          "Please contact us, so we can try to fix it."
            };
        }

        public override bool ShouldHandle(ExceptionHandlerContext context)
        {
            return true;
        }

        private class TextPlainErrorResult : IHttpActionResult
        {
            public HttpRequestMessage Request { get; set; }

            public string Content { get; set; }

            public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
                HttpResponseMessage response =
                    new HttpResponseMessage(HttpStatusCode.InternalServerError)
                    {
                        Content = new StringContent(Content),
                        StatusCode = HttpStatusCode.BadRequest,
                        RequestMessage = Request
                    };
                return Task.FromResult(response);
            }
        }
    }
}