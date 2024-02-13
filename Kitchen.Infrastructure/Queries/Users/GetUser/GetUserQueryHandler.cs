using Kitchen.UseCases.Configurations.Queries;
using Kitchen.UseCases.Queries.Users.GetUser;
using Microsoft.EntityFrameworkCore;

namespace Kitchen.Infrastructure.Queries.Users.GetUser
{
    public class GetUserQueryHandler : IQueryHandler<GetUserQuery, UserDto>
    {
        private readonly KitchenDbContext _context;

        public GetUserQueryHandler(KitchenDbContext context)
        {
            _context = context;
        }

        public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var userQuery = from u in _context.Users
                            where u.Id == Guid.Parse(request.Id)
                            select u;

            var user = await userQuery.FirstOrDefaultAsync();

            return new UserDto(
                user.Id,
                user.Name,
                user.Email,
                user.CreationDate);
        }
    }
}
