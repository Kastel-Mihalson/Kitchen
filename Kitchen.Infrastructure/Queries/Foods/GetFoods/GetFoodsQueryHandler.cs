using Kitchen.UseCases.Configurations.Queries;
using Kitchen.UseCases.Queries.Foods.GetFood;
using Kitchen.UseCases.Queries.Foods.GetFoods;
using Microsoft.EntityFrameworkCore;

namespace Kitchen.Infrastructure.Queries.Foods.GetFoods
{
    public class GetFoodsQueryHandler : IQueryHandler<GetFoodsQuery, IReadOnlyList<FoodDto>>
    {
        private readonly KitchenDbContext _context;

        public GetFoodsQueryHandler(KitchenDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<FoodDto>> Handle(GetFoodsQuery request, CancellationToken cancellationToken)
        {
            var foodsQuery = from f in _context.Foods select f;

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
