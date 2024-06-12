using AdressBook.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AdressBook.Application.UseCases.Entry.Commands
{
    public static class AddEntryUseCase
    {
        public record Command() : IRequest;

        internal class Handler(IEntryRepository entryRepository) : IRequestHandler<Command>
        {
            public Task Handle(Command request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
