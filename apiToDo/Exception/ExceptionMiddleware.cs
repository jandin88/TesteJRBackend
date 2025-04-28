using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;


//classe  ExceptionMiddleware responsavel por capturar exceção  e retornar um json com o erro para o usuario
namespace apiToDo.Exception
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (System.Exception e)
            {
                await HandleExceptionAsync(context, e);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, System.Exception exception)
        {
            context.Response.ContentType = "application/json";
            int statusCode = 400;
            String mensagem = "Aconteceu um erro inesperado";

            if (exception is ErrorResponse errorResponse)
            {
                statusCode = errorResponse.statusCode;
                mensagem = errorResponse.Message;
            }

            var response = new
            {
                status = statusCode,
                error = mensagem
            };

            context.Response.StatusCode = statusCode;

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}