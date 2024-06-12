using AdressBook.Application.Common.Interfaces;
using AdressBook.Domain.Entities;
using MediatR;

namespace AdressBookApi.Queries
{
    public static class GetEntryQuery
    {
        public record Query(int id) : IRequest<Entry>;
        internal class Handler(IEntryRepository entryRepository) : IRequestHandler<Query, Entry>
        {
            public async Task<Entry> Handle(Query request, CancellationToken cancellationToken) => await entryRepository.GetEntryByIdAsync(request.id);
        }
    }
}