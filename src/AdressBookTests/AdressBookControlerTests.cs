using AdressBookApi.Controllers;
using AdressBookApi.Data;
using AdressBookApi.Entities;
using AdressBookApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdressBookTests
{
    public class AdressBookControlerTests
    {
        private readonly DataContext _context;
        private readonly AdressBookControler _controller;

        private void LoadSampleData()
        {
            _context.Entries.Add(new Entry { FirstName = "Anna", Nick = "asd", LastName = "Nowak", Telephone = "987654321", Email = "anna.nowak@example.com", Address = "ul. Zielona 2", City = "Kraków", PostalCode = "30-002" });
            _context.Entries.Add(new Entry { FirstName = "Anna", Nick = "asd", LastName = "Nowak", Telephone = "987654321", Email = "anna.nowak@example.com", Address = "ul. Zielona 2", City = "Kraków", PostalCode = "30-002" });
            _context.SaveChanges();
        }

        public AdressBookControlerTests()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: $"TestDatabase-{Guid.NewGuid()}")
                .Options;

            _context = new DataContext(options);
            _controller = new AdressBookControler(_context);

            LoadSampleData();
        }


        [Fact]
        public async Task GetAdressBook_ReturnsOkResult()
        {
            // Arrange

            // Act
            var result = await _controller.GetAdressBook();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetEntry_ReturnsNotFound_ForInvalidId()
        {
            // Arrange
            int invalidId = -1;

            // Act
            var result = await _controller.GetEntry(invalidId);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }
        [Fact]
        public async Task GetEntry_ReturnsOkResult()
        {
            // Arrange
            int validId = 2;

            // Act
            var result = await _controller.GetEntry(validId);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task AddNewEntry_ReturnsOkResult()
        {

            // Arrange
            var entry = new AddEntry
            {
                FirstName = "Jan",
                Nick = "sad",
                LastName = "Kowalski",
                Telephone = "123456789",
                Email = "jan.kowalski@example.com",
                Address = "ul. Kwiatowa 1",
                City = "Warszawa",
                PostalCode = "00-001"
            };


            // Act
            var result = await _controller.AddNewEntry(entry);

            // Assert
            Assert.IsType<OkResult>(result);
        }
        
        [Fact]
        public async Task AddNewEntry_ReturnsNotFound()
        {

            // Arrange
            var entry = new AddEntry
            {
                Nick = "sad",
                FirstName = "Jan",
                LastName = "Kowalski",
                Telephone = "123456789",
                Email = "jan.kowalski@example.com",
                Address = "ul. Kwiatowa 1",
                City = "Warszawa",
                PostalCode = "00-001"
            };

            // Act
            //var result = await _controller.AddNewEntry(entry);

            // Assert
            await Assert.ThrowsAsync<InvalidOperationException>(async () => await _controller.AddNewEntry(entry));
        }

        [Fact]
        public async Task DeleteEntry_ReturnsNotFound_ForInvalidId()
        {
            // Arrange
            int invalidId = -1;

            // Act
            var result = await _controller.DeleteEntry(invalidId);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }
        [Fact]
        public async Task DeleteEntry_ReturnsOkResult()
        {
            // Arrange
            int validId = 1;

            // Act
            var result = await _controller.DeleteEntry(validId);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task UpdateEntry_ReturnsNotFound_ForInvalidId()
        {
            // Arrange
            var entry = new UpdateEntry
            {
                Id = 23,
                FirstName = "Jan",
                Nick = "asd",
                LastName = "Kowalski",
                Telephone = "123456789",
                Email = "jan.kowalski@example.com",
                Address = "ul. Kwiatowa 1",
                City = "Warszawa",
                PostalCode = "00-001"
            };

            // Act
            var result = await _controller.UpdateEntry(entry);

            // Assert
            Assert.IsType<ActionResult<List<Entry>>>(result);
        }
        [Fact]
        public async Task UpdateEntry_ReturnsOkResult()
        {
            // Arrange
            var entry = new UpdateEntry
            {
                Id = 23,
                FirstName = "Jan",
                Nick = "asd",
                LastName = "Kowalski",
                Telephone = "123456789",
                Email = "jan.kowalski@example.com",
                Address = "ul. Kwiatowa 1",
                City = "Warszawa",
                PostalCode = "00-001"
            };

            // Act
            var result = await _controller.UpdateEntry(entry);

            // Assert
            Assert.IsType<ActionResult<List<Entry>>>(result);
        }

    }
}
