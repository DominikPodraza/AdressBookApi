using AdressBook.Application.Common.Interfaces;
using AdressBook.Domain.Entities;
using AdressBook.Infrastructure.Middleware.Exceptions;
using AdressBook.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;

namespace AdressBook.Infrastructure.Repositories
{
    internal class EntryRepository(DataContext dataContext) : IEntryRepository
    {
        public async Task AddNewEntryAsync(Entry entry)
        {
            await dataContext.Entries.AddAsync(entry);
            await dataContext.SaveChangesAsync();
        }

        public async Task DeleteEntryAsync(int id)
        {
            var entry = await GetEntryByIdAsync(id);
            dataContext.Entries.Remove(entry);
            await dataContext.SaveChangesAsync();
        }

        public async Task<List<Entry>> GetEntriesAsync()
        {
            var entries = await dataContext.Entries.ToListAsync();
            return entries;
        }

        public async Task<Entry> GetEntryByIdAsync(int id)
        {
            var entry = await dataContext.Entries.SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundException("Emtry", $"Nie znaleziono entry o id: {id}");
            return entry;
        }

        public async Task UpdateEntryAsync(Entry entry)
        {
            var editedEntry = await GetEntryByIdAsync(entry.Id) ?? throw new NotFoundException("Updated Entry", "Nie znaleziono wpisu do edycji");

            if (string.IsNullOrWhiteSpace(entry.Nick)) throw new BadRequestException("Login", "Pole loginu musi być wypełnione");
            if (string.IsNullOrWhiteSpace(entry.FirstName)) throw new BadRequestException("FirstName", "Pole imienia musi być wypełnione");
            if (string.IsNullOrWhiteSpace(entry.LastName)) throw new BadRequestException("LastName", "Pole nazwiaska musi być wypełnione");
            if (string.IsNullOrWhiteSpace(entry.Telephone)) throw new BadRequestException("Telephone", "Pole numeru telefonu musi być wypełnione");

            var isNickExist = await NickExist(entry.Nick);
            if (isNickExist) throw new BadRequestException("Updated Entry", "Taki nick juz istnieje!");

            editedEntry.Nick = entry.Nick;
            editedEntry.FirstName = entry.FirstName;
            editedEntry.LastName = entry.LastName;
            editedEntry.Email = entry.Email;
            editedEntry.Address = entry.Address;
            editedEntry.City = entry.City;
            editedEntry.PostalCode = entry.PostalCode;
            editedEntry.Telephone = entry.Telephone;

            await dataContext.SaveChangesAsync();
        }

        private async Task<Boolean> NickExist(string? nick)
        {
            return await dataContext.Entries.AnyAsync(x => x.Nick == nick);

        }
    }
}
