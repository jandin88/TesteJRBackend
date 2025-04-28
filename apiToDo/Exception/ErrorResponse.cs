using System;


// Classe de erro personalizada, ela que vai ser chamada no middleware
namespace apiToDo.Exception
{
    public class ErrorResponse: System.Exception
    {
        public int statusCode { get; }

        public override string Message { get; }

        public ErrorResponse(int codError, string msg)
        : base(msg)
        {
            statusCode = codError;
            Message = msg;
        }
    }
}