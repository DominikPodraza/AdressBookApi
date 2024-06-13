using AdressBook.Application.Common.Interfaces;
using AdressBook.Application.UseCases.Entry.Commands.AddEntry.Dtos;
using MediatR;

namespace AdressBook.Application.UseCases.Entry.Commands.AddEntry
{
    public static class AddEntryUseCase
    {

        public class Command : IRequest
        {
            public string? Nick { get; set; }
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public List<PhoneNumberDto>? NumberPhones { get; set; }
            public string? Email { get; set; } = string.Empty;
            public string? Address { get; set; } = string.Empty;
            public string? City { get; set; } = string.Empty;
            public string? PostalCode { get; set; } = string.Empty;
        }

        internal class Handler(IEntryRepository entryRepository) : IRequestHandler<Command>
        {
            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                var entry = new AddEntryAdapter(request);
                await entryRepository.AddNewEntryAsync(entry);
            }
        }
    }
}
