namespace AdressBookApi.Models
{
    public class UpdateEntry
    {
        public int Id { get; set; }
        public required string Nick { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Telephone { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
    }
}
