namespace AdressBookApi.Models
{
    public class AddEntry
    {
        public string Nick { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
        public string? Email { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
        public string? City { get; set; } = string.Empty;
        public string? PostalCode { get; set; } = string.Empty;
    }
}
