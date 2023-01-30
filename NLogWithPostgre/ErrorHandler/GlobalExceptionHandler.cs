using ErrorHandler.Exceptions;
using Logger;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;

namespace ErrorHandler
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public GlobalExceptionHandler(RequestDelegate next, ILogger logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }

        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            switch (exception)
            {
                case GenericCustomException genericException:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    return httpContext.Response.WriteAsync(JsonConvert.SerializeObject(new GenericError() { ErrorCode = genericException.ErrorCode, Message = genericException.Message }));
                case BadRequestCustomException badRequestCustomException:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return httpContext.Response.WriteAsync(JsonConvert.SerializeObject(new GenericError() { ErrorCode = badRequestCustomException.ErrorCode, Message = badRequestCustomException.Message }));
                case NotFoundCustomException notFoundException:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return httpContext.Response.WriteAsync(JsonConvert.SerializeObject(new NotFoundError() { ErrorCode = notFoundException.ErrorCode, Message = notFoundException.Message }));
                case UnauthorizedCustomException unauthorizedCustomException:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    return httpContext.Response.WriteAsync(JsonConvert.SerializeObject(new NotFoundError() { ErrorCode = unauthorizedCustomException.ErrorCode, Message = unauthorizedCustomException.Message }));
            }

            _logger.LogError(exception.ToString());

            return httpContext.Response.WriteAsync(JsonConvert.SerializeObject(new GenericError() { Message = "System Error" }));

        }
    }
}
