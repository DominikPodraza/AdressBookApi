using AdressBook.Domain.Entities;
using AdressBookApi.Queries;

namespace AdressBook.Tests
{
    public class GetAllEntriesTest : BaseTest
    {
        [Fact]
        public async Task GetAllEntries_Task()
        {
            //Arrange
            var entry = new Entry
            {
                Id = 1,
                FirstName = "Wojtek",
                LastName = "Król",
                Nick = "xMikuzoo",
                NumberPhones = new List<PhoneNumber>
                   {
                        new PhoneNumber
                        {

                            NumberPhoneId = 1,
                            Number = "123123123",
                            EntryId = 1,
                            IsDefault = true,
                        },
                        new PhoneNumber
                        {
                            NumberPhoneId = 2,
                            Number = "234234234",
                            EntryId = 1,
                            IsDefault = false,
                        },
                   },
                Address = "Radlna 82b",
                City = "Radlna",
                Email = "xmikuzoo@gmail.com",
                PostalCode = "33-121"
            };
            var entry2 = new Entry
            {
                Id = 2,
                FirstName = "Wojtek",
                LastName = "Król",
                Nick = "xMikuzoo",
                NumberPhones = new List<PhoneNumber>
                   {
                        new PhoneNumber
                        {

                            NumberPhoneId = 3,
                            Number = "123123123",
                            EntryId = 2,
                            IsDefault = true,
                        },
                        new PhoneNumber
                        {
                            NumberPhoneId = 4,
                            Number = "234234234",
                            EntryId = 2,
                            IsDefault = false,
                        },
                   },
                Address = "Radlna 82b",
                City = "Radlna",
                Email = "xmikuzoo@gmail.com",
                PostalCode = "33-121"
            };
            await entryRepository.AddNewEntryAsync(entry);
            await entryRepository.AddNewEntryAsync(entry2);

            //Act
            var command = new GetAllEntriesQuery.Query();
            var entryToCheck = await mediator.Send(command);

            //Assert
            Assert.NotNull(entryToCheck);
        }
    }
}
