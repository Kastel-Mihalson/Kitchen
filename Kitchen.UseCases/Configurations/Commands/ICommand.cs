using MediatR;

namespace Kitchen.UseCases.Configurations.Commands
{
    public interface ICommand : IRequest { }

    public interface ICommand<out TResult> : IRequest<TResult> { }
}
