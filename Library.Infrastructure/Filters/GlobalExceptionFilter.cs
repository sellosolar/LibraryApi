using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Library.Core.Exceptions
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (filterContext.Exception.GetType() == typeof(CustomException))
            {
                var exception = (CustomException)filterContext.Exception;

                var validation = new
                {
                    Status = 400,
                    Title = "Bad Request",
                    Detail = exception.Message
                };

                var json = new
                {
                    errors = new[] { validation }
                };

                filterContext.Result = new BadRequestObjectResult(json);
                filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                filterContext.ExceptionHandled = true;
            }
        }
    }
}
