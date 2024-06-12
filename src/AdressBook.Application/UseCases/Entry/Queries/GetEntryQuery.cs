using AdressBookApi.Entities;
using MediatR;

namespace AdressBookApi.Queries
{
    public class GetEntryQuery : IRequest<Entry>
    {
        public int Id { get; set; }
    }
}