using MediatR;

namespace Kitchen.UseCases.Configurations.Queries
{
    public interface IQueryHandler<in TQuery, TResult> : IRequestHandler<TQuery, TResult>
        where TQuery : IQuery<TResult> { }
}
