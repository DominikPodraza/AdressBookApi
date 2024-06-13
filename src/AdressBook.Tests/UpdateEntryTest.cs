using AdressBook.Application.UseCases.Entry.Commands;
using AdressBook.Application.UseCases.Entry.Commands.AddEntry;
using AdressBook.Application.UseCases.Entry.Commands.AddEntry.Dtos;
using AdressBook.Domain.Entities;
using AdressBook.Infrastructure.Repositories;

namespace AdressBook.Tests
{
    public class UpdateEntryTest : BaseTest
    {
        [Fact]
        public async Task UpdateEntry_Test()
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

            string firstName = "Bartek";
            string lastName = "Król";
            string nick = "Królik";
            string phoneNumber1 = "456456456";
            string phoneNumber2 = "765678236";
            string adress = "Radlna 82b";
            string city = "Radlna";
            string email = "zjeb@gmail.com";
            string postalCode = "33-121";

            var command = new UpdateEntryUseCase.Command
            {
                Id = 1,
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
