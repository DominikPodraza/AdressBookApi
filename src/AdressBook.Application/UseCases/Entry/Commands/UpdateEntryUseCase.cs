using AdressBook.Application.Common.Interfaces;
using AdressBook.Application.UseCases.Entry.Commands.AddEntry.Dtos;
using AdressBook.Domain.Entities;
using AdressBook.Domain.Exceptions;
using MediatR;

namespace AdressBook.Application.UseCases.Entry.Commands
{
    public static class UpdateEntryUseCase
    {
        public record Command : IRequest
        {
            public int Id { get; set; }
            public string? Nick { get; set; }
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public List<PhoneNumberDto>? NumberPhones { get; set; }
            public string Email { get; set; } = string.Empty;
            public string Address { get; set; } = string.Empty;
            public string City { get; set; } = string.Empty;
            public string PostalCode { get; set; } = string.Empty;
        }
        internal class Handler(IEntryRepository entryRepository) : IRequestHandler<Command>
        {
            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                var editedEntry = await entryRepository.GetEntryByIdAsync(request.Id) ?? throw new NotFoundException("Updated Entry", "Nie znaleziono wpisu do edycji");

                if (string.IsNullOrWhiteSpace(request.Nick)) throw new BadRequestException("Login", "Pole loginu musi być wypełnione");
                if (string.IsNullOrWhiteSpace(request.FirstName)) throw new BadRequestException("FirstName", "Pole imienia musi być wypełnione");
                if (string.IsNullOrWhiteSpace(request.LastName)) throw new BadRequestException("LastName", "Pole nazwiaska musi być wypełnione");
                if (request.NumberPhones == null) throw new BadRequestException("Telephone", "Pole numeru telefonu musi być wypełnione");
                var isPhoneNumbersExist = request.NumberPhones?.Any(x =>  string.IsNullOrWhiteSpace(x.Number));
                if (isPhoneNumbersExist == null || isPhoneNumbersExist == true) throw new BadRequestException("Telephone", "Pole numeru telefonu musi być wypełnione");

                var isNickExist = await entryRepository.NickExist(request.Nick);
                if (isNickExist) throw new BadRequestException("Updated Entry", "Taki nick juz istnieje!");

                editedEntry.Nick = request.Nick;
                editedEntry.FirstName = request.FirstName;
                editedEntry.LastName = request.LastName;
                editedEntry.Email = request.Email;
                editedEntry.Address = request.Address;
                editedEntry.City = request.City;
                editedEntry.PostalCode = request.PostalCode;
                editedEntry.NumberPhones = request.NumberPhones.ConvertAll(x => new PhoneNumber { Number = x.Number, IsDefault = x.IsDefault });
                await entryRepository.UpdateEntryAsync(editedEntry);
            }
        }
    }
}
