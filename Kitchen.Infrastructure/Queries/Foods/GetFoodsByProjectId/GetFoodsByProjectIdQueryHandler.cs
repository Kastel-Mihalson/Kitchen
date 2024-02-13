using Kitchen.UseCases.Configurations.Queries;
using Kitchen.UseCases.Queries.Foods.GetFood;
using Kitchen.UseCases.Queries.Foods.GetFoodsByProjectId;
using Microsoft.EntityFrameworkCore;

namespace Kitchen.Infrastructure.Queries.Foods.GetFoodsByProjectId
{
    public class GetFoodsByProjectIdQueryHandler : IQueryHandler<GetFoodsByProjectIdQuery, IReadOnlyList<FoodDto>>
    {
        private readonly KitchenDbContext _context;

        public GetFoodsByProjectIdQueryHandler(KitchenDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<FoodDto>> Handle(GetFoodsByProjectIdQuery request, CancellationToken cancellationToken)
        {
            var foodsQuery = from f in _context.Foods
                            where f.ProjectId == Guid.Parse(request.ProjectId)
                            select f;

            var foods = await foodsQuery.ToListAsync();

            return foods.Select(x => new FoodDto(
                x.Id,
                x.CreationDate,
                x.Name,
                x.Description,
                x.Price,
                x.Image,
                x.CategoryId,
                x.ProjectId)).ToList();
        }
    }
}
