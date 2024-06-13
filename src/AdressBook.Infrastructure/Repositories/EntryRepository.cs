using AdressBook.Application.Common.Interfaces;
using AdressBook.Application.UseCases.Entry.Commands.AddEntry.Dtos;
using AdressBook.Application.UseCases.Entry.Queries;
using AdressBook.Domain.Entities;
using AdressBook.Domain.Exceptions;
using AdressBook.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

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
            return await dataContext.Entries.Include(x => x.NumberPhones).ToListAsync();
        }

        public async Task<Entry> GetEntryByIdAsync(int id)
        {
            return await dataContext.Entries.Include(x => x.NumberPhones).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundException("Entry", $"Nie znaleziono entry o id: {id}");
        }

        public async Task UpdateEntryAsync(Entry entry)
        {
            dataContext.Entries.Update(entry);
            await dataContext.SaveChangesAsync();
        }

        public async Task<Boolean> NickExist(string nick)
        {
            return await dataContext.Entries.AnyAsync(x => x.Nick == nick);

        }

    }
}
