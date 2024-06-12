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
            this.Telephone = addEntry.Telephone;
            this.Email = addEntry.Email;
            this.Address = addEntry.Address;
            this.City = addEntry.City;
            this.PostalCode = addEntry.PostalCode;
        }
    }
}
