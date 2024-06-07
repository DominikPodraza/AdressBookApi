using AdressBookApi.Adapters;
using AdressBookApi.Data;
using AdressBookApi.Entities;
using AdressBookApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace AdressBookApi.Controllers
{
    [Route("api/adress-book")]
    [ApiController]
    public class AdressBookControler(DataContext dataContext) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAdressBook()
        {
            return Ok(await dataContext.Entries.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEntry(int id)
        {   
            var entry = await GetEntry_(id);
            if (entry == null) return NotFound("Nie znaleziono wpisu");
            return Ok(entry);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewEntry(AddEntry addEntry)
        {
            var a = 1;

            var isNickExists = await NickExist(addEntry.Nick);

            if (!isNickExists)
            {
                var entry = new EntryAdapter(addEntry);
                await dataContext.Entries.AddAsync(entry);
                await dataContext.SaveChangesAsync();
                return Ok();
            }
            return BadRequest("Taki nick juz stnieje");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntry(int id)
        {
            var entry = await GetEntry_(id);

            if (entry == null) return NotFound("Nie znaleziono");

            dataContext.Remove(entry);

            return Ok(await dataContext.SaveChangesAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Entry>>> UpdateEntry(UpdateEntry updateEntry)
        {
            var editedEntry = await GetEntry_(updateEntry.Id);

            if (editedEntry == null) return NotFound("Nie znaleziono");

            if (updateEntry.Nick != editedEntry.Nick)
            { 
                var isNickExist = await NickExist(updateEntry.Nick);
                if (isNickExist)
                {
                    editedEntry.Nick = updateEntry.Nick;
                }
            }            

            editedEntry.FirstName = updateEntry.FirstName;
            editedEntry.LastName = updateEntry.LastName;
            editedEntry.Email = updateEntry.Email;
            editedEntry.Address = updateEntry.Address;
            editedEntry.City = updateEntry.City;
            editedEntry.PostalCode = updateEntry.PostalCode;
            editedEntry.Telephone = updateEntry.Telephone;

            await dataContext.SaveChangesAsync();
            return Ok();
        }

        private async Task<Entry?> GetEntry_(int id)
        {
            var entry = await dataContext.Entries.SingleOrDefaultAsync(x => x.Id == id);
            if (entry == null) return null;
            return entry;
        }

        private async Task<Boolean> NickExist(string nick)
        { 
            return await dataContext.Entries.AnyAsync(x => x.Nick == nick);

        }


    }

}
