using AdressBook.Application.UseCases.Entry.Commands.AddEntry.Dtos;
using AdressBook.Domain.Entities;
using System.Diagnostics.CodeAnalysis;

namespace AdressBook.Application.UseCases.Entry.Queries
{
    public class EntryDtoAdapter : EntryDto
    {
        [SetsRequiredMembers]
        public EntryDtoAdapter(Domain.Entities.Entry entry)
        {
            this.Id = entry.Id;
            this.FirstName = entry.FirstName;
            this.LastName = entry.LastName;
            this.Nick = entry.Nick;
            this.NumberPhones = entry.NumberPhones.ConvertAll(x => new PhoneNumberDto { Number = x.Number, IsDefault = x.IsDefault});
            this.Email = entry.Email;
            this.Address = entry.Address;
            this.City = entry.City;
            this.PostalCode = entry.PostalCode;
        }
    }
}
