using AdressBook.Application.Common.Interfaces;
using AdressBook.Application.UseCases.Entry.Commands.AddEntry;
using AdressBook.Application.UseCases.Entry.Commands.AddEntry.Dtos;
using MediatR;

namespace AdressBook.Application.UseCases.Entry.Queries
{
    public static class GetEntryQuery
    {
        public record Query(int id) : IRequest<EntryDto>;
        internal class Handler(IEntryRepository entryRepository) : IRequestHandler<Query, EntryDto>
        {
            public async Task<EntryDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var entry = await entryRepository.GetEntryByIdAsync(request.id);
                return new EntryDtoAdapter(entry);
            }
        }
    }
}