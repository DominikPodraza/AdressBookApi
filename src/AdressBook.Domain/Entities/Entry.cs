namespace AdressBook.Domain.Entities
{
    public class Entry
    {
        private string? _nick; 

        public int Id { get; set; }
        public required string Nick {
            get => _nick ?? string.Empty;
            set {
                if (string.IsNullOrWhiteSpace(value)) {
                    throw new Exception();
                }
                _nick = value; }
        }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Telephone { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;



    }
}
