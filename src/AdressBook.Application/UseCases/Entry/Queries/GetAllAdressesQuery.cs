using AdressBookApi.Entities;
using MediatR;

namespace AdressBookApi.Queries
{
    public class GetAllAdressesQuery : IRequest<List<Entry>>
    {
    }
}
