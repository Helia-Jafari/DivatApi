using DivatApi.Models;

namespace DivatApi.Interfaces
{
    public interface ICityService
    {
        Task<City> GetCityByIdAsync(int cityId);
    }
}
