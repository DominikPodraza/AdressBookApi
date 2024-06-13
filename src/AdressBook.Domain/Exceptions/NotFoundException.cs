using System.Net;

namespace AdressBook.Domain.Exceptions
{
    public class NotFoundException : HttpResponseException
    {
        public NotFoundException(string title, string description, string? internalMessage = null) : base(HttpStatusCode.NotFound, title, description, internalMessage)
        {
        }
    }
}
