using Kitchen.UseCases.Configurations;
using Kitchen.UseCases.Configurations.Commands;
using Kitchen.UseCases.Configurations.Queries;
using MediatR;

namespace Kitchen.Infrastructure.Configurations
{
    public class KitchenModule : IKitchenModule
    {
        private readonly IMediator _mediator;

        public KitchenModule(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<TResult> ExecuteCommandAsync<TResult>(
            ICommand<TResult> command,
            CancellationToken cancellationToken = default)
        {
            return _mediator.Send(command, cancellationToken);
        }

        public Task ExecuteCommandAsync(
            ICommand command,
            CancellationToken cancellationToken = default)
        {
            return _mediator.Send(command, cancellationToken);
        }

        public Task<TResult> ExecuteQueryAsync<TResult>(
            IQuery<TResult> query,
            CancellationToken cancellationToken = default)
        {
            return _mediator.Send(query, cancellationToken);
        }
    }
}
