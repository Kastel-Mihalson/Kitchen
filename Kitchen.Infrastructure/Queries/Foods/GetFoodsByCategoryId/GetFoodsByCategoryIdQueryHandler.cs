using Kitchen.UseCases.Configurations.Queries;
using Kitchen.UseCases.Queries.Foods.GetFood;
using Kitchen.UseCases.Queries.Foods.GetFoodsByCategoryId;
using Microsoft.EntityFrameworkCore;

namespace Kitchen.Infrastructure.Queries.Foods.GetFoodsByCategoryId
{
    public class GetFoodsByCategoryIdQueryHandler : IQueryHandler<GetFoodsByCategoryIdQuery, IReadOnlyList<FoodDto>>
    {
        private readonly KitchenDbContext _context;

        public GetFoodsByCategoryIdQueryHandler(KitchenDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<FoodDto>> Handle(GetFoodsByCategoryIdQuery request, CancellationToken cancellationToken)
        {
            var foodsQuery = from f in _context.Foods
                             where f.CategoryId == Guid.Parse(request.CategoryId)
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
