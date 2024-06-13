using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AdressBook.Infrastructure.Middleware.Exceptions
{
    public class NotFoundException : HttpResponseException
    {
        public NotFoundException(string title, string description, string? internalMessage = null) : base(HttpStatusCode.NotFound, title, description, internalMessage)
        {
        }
    }
}
