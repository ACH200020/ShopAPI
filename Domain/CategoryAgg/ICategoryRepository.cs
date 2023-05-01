using Common.Domian.Repository;

namespace Shop.Domain.CategoryAgg
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<bool> DeleteCategory(long categoryId);
    }
}