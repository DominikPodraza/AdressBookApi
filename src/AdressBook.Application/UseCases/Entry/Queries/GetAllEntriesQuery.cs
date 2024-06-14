using AdressBook.Application.Common.Interfaces;
using AdressBook.Application.UseCases.Entry.Commands.AddEntry.Dtos;
using MediatR;

namespace AdressBook.Application.UseCases.Entry.Queries
{
    public static class GetAllEntriesQuery
    {
        public record Query() : IRequest<List<EntryDto>>;
        internal class Handler(IEntryRepository entryRepository) : IRequestHandler<Query, List<EntryDto>>
        {
            public async Task<List<EntryDto>> Handle(Query request, CancellationToken cancellationToken)
            {
               var allEntries = await entryRepository.GetEntriesAsync();
                var allEntriesDto = allEntries.ConvertAll(x => new EntryDto { 
                    Id = x.Id,
                    FirstName = x.FirstName, 
                    LastName = x.LastName,
                    Nick = x.Nick, 
                    Address = x.Address, 
                    City = x.City, 
                    Email = x.Email, 
                    NumberPhones = x.NumberPhones?.ConvertAll(y => new PhoneNumberDto { 
                        IsDefault = y.IsDefault, 
                        Number = y.Number
                    }) ?? [],
                    PostalCode = x.PostalCode 
                });

                return allEntriesDto;
            }
        }
    }
}
