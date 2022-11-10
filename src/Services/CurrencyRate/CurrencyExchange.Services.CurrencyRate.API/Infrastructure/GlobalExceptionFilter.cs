using System;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CurrencyExchange.Services.CurrencyRate.API.Infrastructure
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<GlobalExceptionFilter> logger;

        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
        {
            this.logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            logger.LogError(new EventId(context.Exception.HResult),
                context.Exception,
                context.Exception.Message);

            var errorDetails = new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Detail = context.Exception.Message,
            };

            context.Result = new BadRequestObjectResult(errorDetails);
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            context.ExceptionHandled = true;
        }
    }
}