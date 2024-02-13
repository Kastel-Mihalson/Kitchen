using Kitchen.UseCases.Configurations.Queries;
using Kitchen.UseCases.Queries.FoodCategories.GetFoodCategoriesByProjectId;
using Kitchen.UseCases.Queries.FoodCategories.GetFoodCategory;
using Microsoft.EntityFrameworkCore;

namespace Kitchen.Infrastructure.Queries.FoodCategories.GetFoodCategoriesByProjectId
{
    public class GetFoodCategoryByProjectIdQueryHandler 
        : IQueryHandler<GetFoodCategoriesByProjectIdQuery, IReadOnlyList<FoodCategoryDto>>
    {
        private readonly KitchenDbContext _context;

        public GetFoodCategoryByProjectIdQueryHandler(KitchenDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<FoodCategoryDto>> Handle(
            GetFoodCategoriesByProjectIdQuery request, 
            CancellationToken cancellationToken)
        {
            var foodCategoriesQuery = from fc in _context.FoodCategories
                                      where fc.ProjectId == Guid.Parse(request.ProjectId)
                                      select fc;

            var foodCategories = await foodCategoriesQuery.ToListAsync();

            return foodCategories.Select(x => new FoodCategoryDto(
                x.Id,
                x.CreationDate,
                x.Name,
                x.Description,
                x.ProjectId)).ToList();
        }
    }
}
