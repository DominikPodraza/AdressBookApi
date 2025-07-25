﻿using AdressBook.Application.UseCases.Entry.Commands;
using AdressBook.Application.UseCases.Entry.Commands.AddEntry;
using AdressBook.Application.UseCases.Entry.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace AdressBookApi.Controllers
{
    [Route("api/adress-book")]
    [ApiController]
    public class AdressBookController(IMediator mediator) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetAllEntries()
        {
            var querry = new GetAllEntriesQuery.Query();
            return Ok(await mediator.Send(querry));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEntry(int id)
        {
            var querry = new GetEntryQuery.Query(id);
            return Ok(await mediator.Send(querry));
        }

        [HttpPost]
        public async Task<IActionResult> AddNewEntry([FromBody] AddEntryUseCase.Command command)
        {
            await mediator.Send(command);
            return Ok();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntry(int id)
        {
            var command = new DeleteEntryUseCase.Command(id);
            await mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEntry([FromBody] UpdateEntryUseCase.Command command)
        {
            await mediator.Send(command);
            return Ok();
        }

    }

}
