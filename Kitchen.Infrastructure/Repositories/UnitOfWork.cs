using Kitchen.UseCases.Interfaces;

namespace Kitchen.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly KitchenDbContext _context;
        private IUserRepository _user;
        private IProjectRepository _project;
        private IFoodCategoryRepository _foodCategory;
        private IFoodRepository _foodRepository;
        private IFoodPriceHistoryRepository _foodPriceHistory;

        public UnitOfWork(KitchenDbContext context)
        {
            _context = context;
        }

        public IUserRepository Users
        {
            get
            {
                if (_user is null)
                {
                    _user = new UserRepository(_context);
                }

                return _user;
            }
        }

        public IProjectRepository Projects
        {
            get
            {
                if (_project is null)
                {
                    _project = new ProjectRepository(_context);
                }

                return _project;
            }
        }

        public IFoodCategoryRepository FoodCategories
        {
            get
            {
                if (_foodCategory is null)
                {
                    _foodCategory = new FoodCategoryRepository(_context);
                }

                return _foodCategory;
            }
        }

        public IFoodRepository Foods
        {
            get
            {
                if (_foodRepository is null)
                {
                    _foodRepository = new FoodRepository(_context);
                }

                return _foodRepository;
            }
        }

        public IFoodPriceHistoryRepository FoodPriceHistories
        {
            get
            {
                if (_foodPriceHistory is null)
                {
                    _foodPriceHistory = new FoodPriceHistoryRepository(_context);
                }

                return _foodPriceHistory;
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
