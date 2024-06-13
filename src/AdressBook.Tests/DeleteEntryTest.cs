using AdressBook.Application.UseCases.Entry.Commands;
using AdressBook.Application.UseCases.Entry.Commands.AddEntry.Dtos;
using AdressBook.Domain.Entities;
using AdressBook.Domain.Exceptions;

namespace AdressBook.Tests
{
    public class DeleteEntryTest : BaseTest
    {
        [Fact]
        public async Task DeleteEntry_Test()
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

            var command = new DeleteEntryUseCase.Command(1);

            // Act
            await mediator.Send(command);

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(()=> entryRepository.GetEntryByIdAsync(1));
        }

    }
}
