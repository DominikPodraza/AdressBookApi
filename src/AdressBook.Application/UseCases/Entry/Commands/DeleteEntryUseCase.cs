using AdressBook.Application.Common.Interfaces;
using MediatR;

namespace AdressBook.Application.UseCases.Entry.Commands
{
    public static class DeleteEntryUseCase
    {
        public record Command(int id) : IRequest;

        internal class Handler(IEntryRepository entryRepository) : IRequestHandler<Command>
        {
            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                await entryRepository.DeleteEntryAsync(request.id);
            }
        }
    }
}
