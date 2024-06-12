using AdressBook.Application.Common.Interfaces;
using AdressBook.Domain.Entities;
using MediatR;

namespace AdressBookApi.Queries
{
    public static class GetAllAdressesQuery
    {
        public record Query() : IRequest<List<Entry>>;
        internal class Handler(IEntryRepository entryRepository) : IRequestHandler<Query, List<Entry>>
        {
           public async Task<List<Entry>> Handle(Query request, CancellationToken cancellationToken) => await entryRepository.GetEntriesAsync();
        }
    }
}
