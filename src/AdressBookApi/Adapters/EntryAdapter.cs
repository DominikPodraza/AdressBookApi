using AdressBookApi.Entities;
using AdressBookApi.Models;
using System.Diagnostics.CodeAnalysis;

namespace AdressBookApi.Adapters
{
    public class EntryAdapter : Entry
    {
        [SetsRequiredMembers]
        public EntryAdapter(AddEntry addEntry)
        {
            this.Nick = addEntry.Nick;
            this.FirstName = addEntry.FirstName;
            this.LastName = addEntry.LastName;
            this.Telephone = addEntry.Telephone;
            this.City = addEntry.City;
            this.PostalCode = addEntry.PostalCode;
            this.Address = addEntry.Address;
            this.Email = addEntry.Email;
        }
    }
}
