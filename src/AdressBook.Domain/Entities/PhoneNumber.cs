using System.ComponentModel;

namespace AdressBook.Domain.Entities
{
    public class PhoneNumber
    {
        public int NumberPhoneId { get; set; }
        public string? Number { get; set; }

        [DefaultValue(false)]
        public bool IsDefault { get; set; }
        public int EntryId { get; set; }
        public Entry? Entry { get; set; }
    }
}
