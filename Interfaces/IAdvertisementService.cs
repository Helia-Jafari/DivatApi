using DivatApi.Models;
using DivatApi.Mapper;
using DivatApi.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DivatApi.Interfaces
{
    public interface IAdvertisementService
    {
        Task<Advertisement> GetAdvertisementByIdAsync(int id);
        Task<EditAdvertisementDto> GetAdvertisementByIdAsyncHomeEditVM(int id);
        Task<AdvertisementDetailsDto> GetAdvertisementByIdAsyncHomeDetailsVM(int id);


        Task<IEnumerable<Advertisement>> GetAllAdvertisementsAsync();
        Task<IEnumerable<HomeDto>> GetAllAdvertisementsAsyncHomeVM();
        Task<IEnumerable<AdvertisementDetailsDto>> GetAllAdvertisementsAsyncHomeDetailsVM();
        Task<Advertisement> AddAdvertisementAsync(AddAdvertisementDto advertisement);
        Task<Advertisement> UpdateAdvertisementAsync(EditAdvertisementDto model);
        Task DeleteAdvertisementAsync(int id);

        Task<List<Category>> GetBreadcrumbsAsync(int adId);

        Task<City> GetCityByIdAsync(int adId);

        //Task<List<Advertisement>> GetAllAdvertisementsAsync();

        Task<List<Advertisement>> SearchAdvertisementsAsync(string searchString);

        //Task<Advertisement> CreateAdvertisementAsync(Advertisement model);
    }
}
