using Kitchen.UseCases.Configurations.Commands;
using Kitchen.UseCases.Configurations.Queries;

namespace Kitchen.UseCases.Configurations
{
    public interface IKitchenModule
    {
        Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command, CancellationToken cancellationToken = default);

        Task ExecuteCommandAsync(ICommand command, CancellationToken cancellationToken = default);

        Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default);
    }
}
