using AdressBookApi.Adapters;
using AdressBookApi.Data;
using AdressBookApi.Entities;
using AdressBookApi.Models;
using AdressBookApi.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace AdressBookApi.Controllers
{
    [Route("api/adress-book")]
    [ApiController]
    public class AdressBookControler(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAdressBook()
        {
            return Ok(await mediator.Send(new GetAllAdressesQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEntry(int id)
        {   
            return Ok(await mediator.Send(new GetEntryQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> AddNewEntry(AddEntry addEntry)
        {
            var query = new AddNewEntryQuery();
            var result = await mediator.Send(query);
            if (result.IsSuccess) {
                return Ok();
            }
            return BadRequest(result.ErrorMessage);

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

            if (string.IsNullOrWhiteSpace(updateEntry.Nick))
            {
                return BadRequest("Login musi być pełny");
            }
            if (string.IsNullOrWhiteSpace(updateEntry.FirstName))
            {
                return BadRequest("Imię musi być pełny");
            }
            if (string.IsNullOrWhiteSpace(updateEntry.LastName))
            {
                return BadRequest("Nazwisko musi być pełny");
            }
            if (string.IsNullOrWhiteSpace(updateEntry.Telephone))
            {
                return BadRequest("Telefon musi być pełny");
            }

            var isNickExist = await NickExist(updateEntry.Nick);
            if (isNickExist) return BadRequest("Taki login już istnieje");

            editedEntry.Nick = updateEntry.Nick;
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

    }

}
