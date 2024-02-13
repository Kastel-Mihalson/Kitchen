using Kitchen.UseCases.Configurations.Queries;
using Kitchen.UseCases.Queries.Users.GetUser;
using Kitchen.UseCases.Queries.Users.GetUsers;
using Microsoft.EntityFrameworkCore;

namespace Kitchen.Infrastructure.Queries.Users.GetUsers
{
    public class GetUsersQueryHandler : IQueryHandler<GetUsersQuery, IReadOnlyList<UserDto>>
    {
        private readonly KitchenDbContext _context;

        public GetUsersQueryHandler(KitchenDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var userQuery = from u in _context.Users select u;
            var users = await userQuery.ToListAsync();

            return users.Select(x => new UserDto(
                x.Id,
                x.Name,
                x.Email,
                x.CreationDate)).ToList();
        }
    }
}
