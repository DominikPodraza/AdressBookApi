using AdressBook.Application.Common.Interfaces;
using AdressBook.Infrastructure.Persistance;

namespace AdressBook.Infrastructure.Repositories
{
    internal class EntryRepository(DataContext dataContext) : IEntryRepository
    {
        //public async Task<T> GetEntry_(int id)
        //{
        //    //await dataContext.Set<T>().SingleOrDefaultAsync(x => x.Id == id);
        //    //if (entry == null) return null;
        //    //return entry;
        //}

        //public async Task<Boolean> NickExist(string nick)
        //{
        //    return await dataContext.Entries.AnyAsync(x => x.Nick == nick);
        //}

    }
}
