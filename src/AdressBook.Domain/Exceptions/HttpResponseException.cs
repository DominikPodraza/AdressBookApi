using System.Net;

namespace AdressBook.Domain.Exceptions
{
    public record ExceptionMessage(string Title, string Description);

    public class HttpResponseException : Exception
    {
        public HttpResponseException(HttpStatusCode statusCode, string title, string description, string? internalMessage = null) : this(statusCode, new ExceptionMessage(title, description), internalMessage)
        {
        }
        public HttpResponseException(HttpStatusCode statusCode, ExceptionMessage message, string? internalMessage = null)
        {
            StatusCode = statusCode;
            Value = message;
            InternalMessage = internalMessage;
        }

        public HttpStatusCode StatusCode { get; }
        public ExceptionMessage Value { get; }
        public string? InternalMessage { get; }

    }
}
