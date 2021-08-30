using System;

namespace Domain.SeedWork
{
    public class HandlerException : Exception
    {
        public int StatusCode { get; set; } = 500;
        public string MessageException
        {
            get => $"HandlerException: {MessageException} Message: {base.Message}, StackTrace: {base.StackTrace}, InnerException: {base.InnerException}, Data: {base.Data}";

            set => MessageException = value;
        }

        public HandlerException(int statusCode, string messageException)
        {
            StatusCode = statusCode;
            MessageException = messageException;
        }
    }
}