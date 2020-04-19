using System;
using System.Collections.Generic;
using System.Web.Http;
using Lab2.Models;

namespace Lab2.Controllers
{
    public class ValuesController : ApiController
    {
        private static int result = 0;
        private static Stack<int> stack = new Stack<int>();

        public Result Get()
        {
            var response = new Result();
            response.result = calculateResult();
            return response;
        }

        public Result Post([FromBody]Result request)
        {
            result = request.result;
            var response = new Result();
            response.result = calculateResult();
            return response;
        }

        public Add Put([FromBody]Add request)
        {
            stack.Push(request.add);
            return request;
        }

        public Pop Delete()
        {
            var response = new Pop();
            try
            {
                var element = stack.Pop();
                response.pop = element;
                response.error = null;
                return response;
            }
            catch (InvalidOperationException)
            {
                response.pop = null;
                response.error = "Stack is empty!";
                return response;
            }
        }

        [NonAction]
        private int calculateResult()
        {
            try
            {
                int lastValue = stack.Peek();
                return result + lastValue;
            }
            catch (InvalidOperationException)
            {
                return result;
            }
        }
    }
}