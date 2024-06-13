namespace AdressBook.Domain.Entities
{
    public class Entry
    {
        private string? _nick; 
        public int Id { get; set; }
        public required string Nick { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public List<PhoneNumber>? NumberPhones { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
    }
}
