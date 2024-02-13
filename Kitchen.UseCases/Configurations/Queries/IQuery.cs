using MediatR;

namespace Kitchen.UseCases.Configurations.Queries
{
    public interface IQuery<out TResult> : IRequest<TResult> { }
}
