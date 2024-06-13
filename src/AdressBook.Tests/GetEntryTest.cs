using AdressBook.Domain.Entities;
using AdressBookApi.Queries;

namespace AdressBook.Tests
{
    public class GetEntryTest : BaseTest
    {
        [Fact]
        public async Task GetEntry_Task()
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
            await entryRepository.AddNewEntryAsync(entry);

            //Act
            var command = new GetEntryQuery.Query(1);
            var entryToCheck = await mediator.Send(command);

            //Assert
            Assert.NotNull(entryToCheck);
        }
    }
}
