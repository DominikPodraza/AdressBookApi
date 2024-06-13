using AdressBook.Application.UseCases.Entry.Commands.AddEntry;
using AdressBook.Application.UseCases.Entry.Commands.AddEntry.Dtos;

namespace AdressBook.Tests
{
    public class AddEntryTest : BaseTest
    {
        [Fact]
        public async Task AddEntry_Test()
        {
            // Arrange
            string firstName = "Wojtek";
            string lastName = "Król";
            string nick = "xMikuzoo";
            string phoneNumber1 = "123123123";
            string phoneNumber2 = "234234234";
            string adress = "Radlna 82b";
            string city = "Radlna";
            string email = "xmikuzoo@gmail.com";
            string postalCode = "33-121";

            var command = new AddEntryUseCase.Command
            {
                FirstName = firstName,
                LastName = lastName,
                Nick = nick,
                NumberPhones = new List<PhoneNumberDto>
                    {
                        new PhoneNumberDto
                        {
                            Number = phoneNumber1,
                            IsDefault = true,
                        },
                        new PhoneNumberDto
                        {
                            Number = phoneNumber2,
                            IsDefault = false,
                        },
                    },
                Address = adress,
                City = city,
                Email = email,
                PostalCode = postalCode

            };

            // Act
            await mediator.Send(command);

            // Assert
            var entryToCheck = await entryRepository.GetEntryByIdAsync(1);
            Assert.Equal(firstName, entryToCheck.FirstName);
            Assert.Equal(lastName, entryToCheck.LastName);
            Assert.Equal(nick, entryToCheck.Nick);
            Assert.Equal(phoneNumber1, entryToCheck.NumberPhones[0].Number);
            Assert.Equal(phoneNumber2, entryToCheck.NumberPhones[1].Number);
            Assert.Equal(adress, entryToCheck.Address);
            Assert.Equal(city, entryToCheck.City);
            Assert.Equal(email, entryToCheck.Email);
            Assert.Equal(postalCode, entryToCheck.PostalCode);
        }
    }
}
