using AdressBook.Application.UseCases.Entry.Commands.AddEntry.Dtos;
using AdressBook.Domain.Entities;

namespace AdressBook.Application.Common.Interfaces
{
    public interface IEntryRepository
    {
        Task<List<Entry>> GetEntriesAsync();
        Task<Entry> GetEntryByIdAsync(int id);
        Task AddNewEntryAsync(Entry entry);
        Task UpdateEntryAsync(Entry entry);
        Task DeleteEntryAsync(int id);
        Task<Boolean> NickExist(string nick);
    }
}
