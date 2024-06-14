namespace AdressBook.Application.UseCases.Entry.Commands.AddEntry.Dtos
{
    public class EntryDto

    {
        public int Id { get; set; }
        public required string Nick { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public List<PhoneNumberDto>? NumberPhones { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
    }
}
