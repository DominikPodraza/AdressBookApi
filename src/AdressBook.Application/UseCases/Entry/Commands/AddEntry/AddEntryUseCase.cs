using AdressBook.Application.Common.Interfaces;
using AdressBook.Application.UseCases.Entry.Commands.AddEntry.Dtos;
using AdressBook.Domain.Exceptions;
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

                if (string.IsNullOrWhiteSpace(request.Nick)) throw new BadRequestException("Login", "Pole loginu musi być wypełnione");
                if (string.IsNullOrWhiteSpace(request.FirstName)) throw new BadRequestException("FirstName", "Pole imienia musi być wypełnione");
                if (string.IsNullOrWhiteSpace(request.LastName)) throw new BadRequestException("LastName", "Pole nazwiaska musi być wypełnione");
                if (request.NumberPhones == null) throw new BadRequestException("Telephone", "Pole numeru telefonu musi być wypełnione");
                var isPhoneNumbersExist = request.NumberPhones?.Any(x => string.IsNullOrWhiteSpace(x.Number));
                if (isPhoneNumbersExist == null || isPhoneNumbersExist == true) throw new BadRequestException("Telephone", "Pole numeru telefonu musi być wypełnione");

                if (request.Nick == entry.Nick)
                {
                var isNickExist = await entryRepository.NickExist(request.Nick);
                    await entryRepository.AddNewEntryAsync(entry);
                    if (isNickExist) throw new BadRequestException("Updated Entry", "Taki nick juz istnieje!");
                    return;
                }
                await entryRepository.AddNewEntryAsync(entry);

            }
        }
    }
}
