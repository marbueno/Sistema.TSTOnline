using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Sistema.TSTOnline.Domain;

namespace Sistema.TSTOnline.Web.Filters
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            bool isDomainException = context.Exception is DomainException;

            if (isDomainException)
            {
                context.HttpContext.Response.ContentType = "application/json";
                context.HttpContext.Response.StatusCode = 500;
                var message = context.Exception is DomainException ? context.Exception.Message : "Ocorreu um erro na aplicação. Tente novamente.";
                context.Result = new JsonResult(message);
                context.ExceptionHandled = true;
            }

            base.OnException(context);
        }
    }
}