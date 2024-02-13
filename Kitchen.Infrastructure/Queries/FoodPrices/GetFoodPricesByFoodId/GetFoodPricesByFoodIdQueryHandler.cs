using Kitchen.UseCases.Configurations.Queries;
using Kitchen.UseCases.Queries.FoodPrices.GetFoodPricesByFoodId;
using Microsoft.EntityFrameworkCore;

namespace Kitchen.Infrastructure.Queries.FoodPrices.GetFoodPricesByFoodId
{
    public class GetFoodPricesByFoodIdQueryHandler : IQueryHandler<GetFoodPricesByFoodIdQuery, IReadOnlyList<FoodPriceDto>>
    {

        private readonly KitchenDbContext _context;

        public GetFoodPricesByFoodIdQueryHandler(KitchenDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<FoodPriceDto>> Handle(GetFoodPricesByFoodIdQuery request, CancellationToken cancellationToken)
        {
            var foodPricesQuery = from fp in _context.FoodPrices
                                  where fp.FoodId == Guid.Parse(request.FoodId)
                                  select fp;

            var foodPrices = await foodPricesQuery.ToListAsync();

            return foodPrices.Select(x => new FoodPriceDto(
                x.Id,
                x.CreationDate,
                x.Price)).ToList();
        }
    }
}
