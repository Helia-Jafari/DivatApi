using DivatApi.Models;

namespace DivatApi.Interfaces
{
    public interface ICategoryService
    {
        //Task<List<Category>> GetCategoriesAsync();
        Task<List<Category>> GetBreadcrumbsAsync(int categoryId);
    }
}
