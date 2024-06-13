using AdressBook.Domain.Entities;
using System.Diagnostics.CodeAnalysis;

namespace AdressBook.Application.UseCases.Entry.Commands.AddEntry
{
    public class AddEntryAdapter : Domain.Entities.Entry
    {
        [SetsRequiredMembers]
        public AddEntryAdapter(AddEntryUseCase.Command addEntry)
        {
            this.FirstName = addEntry.FirstName;
            this.LastName = addEntry.LastName;
            this.Nick = addEntry.Nick;
            this.NumberPhones = addEntry.NumberPhones.ConvertAll(x => new PhoneNumber { Number = x.Number, IsDefault = x.IsDefault});
            this.Email = addEntry.Email;
            this.Address = addEntry.Address;
            this.City = addEntry.City;
            this.PostalCode = addEntry.PostalCode;
        }
    }
}
