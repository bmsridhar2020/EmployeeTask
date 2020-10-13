using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTask.ActionFilter
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if(context == null | context.ExceptionHandled)
            {
                return;
            }
            HttpResponse response = context.HttpContext.Response;
            response.StatusCode = StatusCodes.Status500InternalServerError;
            response.ContentType = "application/json";
            response.WriteAsync("Error in the application.Kindly contact system admin.");
        }
    }
}
