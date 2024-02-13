namespace Kitchen.UseCases.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IProjectRepository Projects { get; }
        IFoodCategoryRepository FoodCategories { get; }
        IFoodPriceHistoryRepository FoodPriceHistories { get; }
        IFoodRepository Foods { get; }
        Task SaveAsync();
    }
}
