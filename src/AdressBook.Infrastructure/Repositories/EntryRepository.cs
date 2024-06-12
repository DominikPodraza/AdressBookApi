using AdressBook.Application.Common.Interfaces;
using AdressBook.Domain.Entities;
using AdressBook.Infrastructure.Persistance;
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
            var entries = await dataContext.Entries.ToListAsync();
            return entries;
        }

        public async Task<Entry> GetEntryByIdAsync(int id)
        {
            var entry = await dataContext.Entries.SingleOrDefaultAsync(x => x.Id == id);
            return entry;
        }

        public async Task UpdateEntryAsync(Entry entry)
        {
            dataContext.Entries.Update(entry);
            await dataContext.SaveChangesAsync();
        }
    }
}
