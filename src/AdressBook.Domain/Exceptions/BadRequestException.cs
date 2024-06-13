using System.Net;

namespace AdressBook.Domain.Exceptions
{
    public class BadRequestException : HttpResponseException
    {
        public BadRequestException(string title, string description, string? internalMessage = null) : base(HttpStatusCode.BadRequest, title, description, internalMessage)
        {
        }
    }
}
