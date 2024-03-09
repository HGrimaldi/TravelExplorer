using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Web.API.Middlewares
{
    public class GlobalExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;

        public GlobalExceptionHandlingMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception occurred: {Message}", ex.Message);

                var problemDetails = new ProblemDetails
                {
                    Status = (int)HttpStatusCode.InternalServerError,
                    Title = "Internal Server Error",
                    Detail = "An unexpected error occurred while processing your request."
                };

                if (ex is ValidationException validationException)
                {
                    problemDetails.Status = (int)HttpStatusCode.BadRequest;
                    problemDetails.Title = "Validation Error";
                    problemDetails.Detail = validationException.Message;
                }

                context.Response.StatusCode = problemDetails.Status ?? (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync(JsonSerializer.Serialize(problemDetails));
            }
        }
    }
}
