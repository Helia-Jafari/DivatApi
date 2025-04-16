using DivatApi.Models;
using DivatApi.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Drawing;
using DivatApi.Interfaces;
using Microsoft.Extensions.Localization;
using DivatApi.Services;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.Globalization;

namespace DivatApi.Controllers
{
    [Route("api/[controller]")]
    //[Route("api/v{version:ApiVersion}/[controller]")]

    [ApiController]
    //[ApiVersion("2.0")]
    public class AdvertisementController : ControllerBase
    {
        private readonly DivarContext _context;
        //private readonly IStringLocalizer<AddController> _localizer;
        //private readonly ILocalizationService _localizationService;
        private readonly IAdvertisementService _advertisementService;
        public List<Category> categories;
        //private readonly ILogger<HomeController> _logger;
        //private readonly IStringLocalizer<HomeController> _localizer;
        private readonly ICityService _cityService;
        private readonly ICategoryService _categoryService;

        List<List<Category>> cats = new List<List<Category>>();
        Dictionary<string, List<Category>> catsDictionary = new Dictionary<string, List<Category>>();
        public AdvertisementController(DivarContext db, IAdvertisementService advertisementService,ICityService cityService, ICategoryService categoryService)
        {
            //_localizer = localizer;
            _advertisementService = advertisementService;
            //_localizationService = localizationService;
            _context = db;
            //_logger = logger;
            //_localizer = localizer;

            _cityService = cityService;
            _categoryService = categoryService;
            _advertisementService = advertisementService;
            //_localizationService = localizationService;
        }

        [HttpGet("GetAllAdvertisements")]
        //[ApiVersion("2.0")]
        public async Task<IActionResult> GetAllAdvertisements()
        {
            var advertisements = await _advertisementService.GetAllAdvertisementsAsync();
            return Ok(advertisements);
        }
        [HttpGet("GetAllAdvertisementsHome")]
        public async Task<IActionResult> GetAllAdvertisementsHome()
        {
            var advertisements = await _advertisementService.GetAllAdvertisementsAsyncHomeVM();
            return Ok(advertisements);
        }
        //[HttpGet("details/{id}")]
        //[HttpGet("ads/details/{id}")]
        //[HttpGet("ads/{id:int:min(1)}")]
        //[HttpGet("advertisements/details/{id}")]
        //[HttpGet("advertisements/{id:int:min(1)}")]
        [HttpGet("GetAdvertisementByIdDatails/{id:int}")]
        public async Task<IActionResult> GetAdvertisementByIdDatails(int id)
        {
            var ad = await _advertisementService.GetAdvertisementByIdAsyncHomeDetailsVM(id);
            return Ok(ad);
        }

        [HttpGet("GetAdvertisementByIdEdit/{id:int}")]
        public async Task<IActionResult> GetAdvertisementByIdEdit(int id)
        {
            var ad = await _advertisementService.GetAdvertisementByIdAsyncHomeEditVM(id);
            return Ok(ad);
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetAdvertisementById(int id)
        {
            var advertisement = await _advertisementService.GetAdvertisementByIdAsync(id);
            if (advertisement is null)
            {
                return NotFound();
            }
            return Ok(advertisement);
        }
        //[HttpPost]
        //[HttpPost("ads/add")]
        //[HttpPost("advertisements/add")]
        //[HttpPost("items/add")]
        [HttpPost("add")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAdvertisements(AddAdvertisementDto advertisementDto)
        {
            //var advertisement = new Advertisement
            //{
            //    BasePrice = Convert.ToInt32(advertisementDto.BasePrice),
            //    CityId = advertisementDto.CityId,
            //    CategoryId = advertisementDto.CategoryId,
            //    City = advertisementDto.City,
            //    Category = advertisementDto.Category,
            //    FunctionKilometers = Convert.ToInt32(advertisementDto.FunctionKilometers),
            //    Color = advertisementDto.Color,
            //    Brand = advertisementDto.Brand,
            //    ChassisAndBodyCondition = advertisementDto.ChassisAndBodyCondition,
            //    Description = advertisementDto.Description,
            //    DoYouWantToReplace = advertisementDto.DoYouWantToReplace,
            //    EngineCondition = advertisementDto.EngineCondition,
            //    FrontChassisCondition = advertisementDto.FrontChassisCondition,
            //    Gearbox = advertisementDto.Gearbox,
            //    IsTheChatActivated = advertisementDto.IsTheChatActivated,
            //    IsThePhoneCallActive = advertisementDto.IsThePhoneCallActive,
            //    Latitude = advertisementDto.Latitude,
            //    Longitude = advertisementDto.Longitude,
            //    ItsModel = advertisementDto.ItsModel,
            //    NationalCode = advertisementDto.NationalCode,
            //    RearChassisCondition = advertisementDto.RearChassisCondition,
            //    Nationality = advertisementDto.Nationality,
            //    ThirdPartyInsuranceTerm = advertisementDto.ThirdPartyInsuranceTerm,
            //    Title = advertisementDto.Title,
            //    Status = "Active",
            //    InsertDate = DateTime.Now,
            //    UpdateDate = DateTime.Now
            //};
            //await _context.Advertisements.AddAsync(advertisement);
            //_context.SaveChanges();
            var ad = await _advertisementService.AddAdvertisementAsync(advertisementDto);
            return CreatedAtAction("AddAdvertisements", ad);
        }
        [HttpPut("UpdateAdvertisements/{id:int}")]
        //[HttpGet("edit/{id}")]
        //[HttpGet("advertisements/edit/{id:int:min(1)}")]
        //[HttpGet("ads/edit/{id}")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateAdvertisements(int id ,EditAdvertisementDto advertisementDto)
        {
            //var advertisement = await _context.Advertisements.FindAsync(id);
            //if (advertisement is null)
            //{
            //    return NotFound();
            //}
            //advertisement.Id = id;
            //advertisement.BasePrice = Convert.ToInt32(advertisementDto.BasePrice);
            //advertisement.CityId = advertisementDto.CityId;
            //advertisement.CategoryId = advertisementDto.CategoryId;
            //advertisement.City = advertisementDto.City;
            //advertisement.Category = advertisementDto.Category;
            //advertisement.FunctionKilometers = Convert.ToInt32(advertisementDto.FunctionKilometers);
            //advertisement.Color = advertisementDto.Color;
            //advertisement.Brand = advertisementDto.Brand;
            //advertisement.ChassisAndBodyCondition = advertisementDto.ChassisAndBodyCondition;
            //advertisement.Description = advertisementDto.Description;
            //advertisement.DoYouWantToReplace = advertisementDto.DoYouWantToReplace;
            //advertisement.EngineCondition = advertisementDto.EngineCondition;
            //advertisement.FrontChassisCondition = advertisementDto.FrontChassisCondition;
            //advertisement.Gearbox = advertisementDto.Gearbox;
            //advertisement.IsTheChatActivated = advertisementDto.IsTheChatActivated;
            //advertisement.IsThePhoneCallActive = advertisementDto.IsThePhoneCallActive;
            //advertisement.Latitude = advertisementDto.Latitude;
            //advertisement.Longitude = advertisementDto.Longitude;
            //advertisement.ItsModel = advertisementDto.ItsModel;
            //advertisement.NationalCode = advertisementDto.NationalCode;
            //advertisement.RearChassisCondition = advertisementDto.RearChassisCondition;
            //advertisement.Nationality = advertisementDto.Nationality;
            //advertisement.ThirdPartyInsuranceTerm = advertisementDto.ThirdPartyInsuranceTerm;
            //advertisement.Title = advertisementDto.Title;
            //advertisement.Status = "Active";
            //advertisement.InsertDate = DateTime.Now;
            //advertisement.UpdateDate = DateTime.Now;

            //var newAdvertisement = new Advertisement
            //{
            //    Id = id,
            //    BasePrice = Convert.ToInt32(advertisementDto.BasePrice),
            //    CityId = advertisementDto.CityId,
            //    CategoryId = advertisementDto.CategoryId,
            //    City = advertisementDto.City,
            //    Category = advertisementDto.Category,
            //    FunctionKilometers = Convert.ToInt32(advertisementDto.FunctionKilometers),
            //    Color = advertisementDto.Color,
            //    Brand = advertisementDto.Brand,
            //    ChassisAndBodyCondition = advertisementDto.ChassisAndBodyCondition,
            //    Description = advertisementDto.Description,
            //    DoYouWantToReplace = advertisementDto.DoYouWantToReplace,
            //    EngineCondition = advertisementDto.EngineCondition,
            //    FrontChassisCondition = advertisementDto.FrontChassisCondition,
            //    Gearbox = advertisementDto.Gearbox,
            //    IsTheChatActivated = advertisementDto.IsTheChatActivated,
            //    IsThePhoneCallActive = advertisementDto.IsThePhoneCallActive,
            //    Latitude = advertisementDto.Latitude,
            //    Longitude = advertisementDto.Longitude,
            //    ItsModel = advertisementDto.ItsModel,
            //    NationalCode = advertisementDto.NationalCode,
            //    RearChassisCondition = advertisementDto.RearChassisCondition,
            //    Nationality = advertisementDto.Nationality,
            //    ThirdPartyInsuranceTerm = advertisementDto.ThirdPartyInsuranceTerm,
            //    Title = advertisementDto.Title,
            //    Status = "Active",
            //    InsertDate = DateTime.Now,
            //    UpdateDate = DateTime.Now
            //};
            //_context.Update(newAdvertisement);

            //_context.SaveChanges();


            var ad = await _advertisementService.UpdateAdvertisementAsync(advertisementDto);
            return Ok(ad);
        }
        [HttpDelete("DeleteAdvertisement/{id:int}")]
        public async Task<IActionResult> DeleteAdvertisement(int id)
        {
            await _advertisementService.DeleteAdvertisementAsync(id);
            //var advertisement = await _context.Advertisements.FindAsync(id);
            //if (advertisement is null)
            //{
            //    return NotFound();
            //}
            //_context.Remove(advertisement);
            //_context.SaveChanges();
            return Ok();
        }



        [HttpGet("SearchAdvertisement/{SearchString}")]
        //[HttpPost("Home")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> SearchAdvertisement(string SearchString)
        {
            var ads = await _advertisementService.SearchAdvertisementsAsync(SearchString);
            return Ok(ads);
        }

        //public ActionResult ChangeCulture(string culture)
        //{
        //    _localizationService.ChangeCultureInfo(culture);
        //    return Redirect(Request.Headers["Referer"].ToString());
        //}



        [HttpGet("GetCityByAdvertisementId/{id:int}")]
        public async Task<IActionResult> GetCityByAdvertisementId(int id)
        {
            var advertisement = await _advertisementService.GetCityByIdAsync(id);
            if (advertisement is null)
            {
                return NotFound();
            }
            return Ok(advertisement);
        }

        [HttpGet("GetCategoriesBreadcrumbs/{id:int}")]
        public async Task<IActionResult> GetCategoriesBreadcrumbs(int id)
        {
            var breadcrumbs = await _advertisementService.GetBreadcrumbsAsync(id);
            return Ok(breadcrumbs);
        }

    }
}
