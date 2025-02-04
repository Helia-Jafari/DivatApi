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
    [ApiController]
    public class AdvertisementController : ControllerBase
    {
        private readonly DivarContext _context;
        //private readonly IStringLocalizer<AddController> _localizer;
        private readonly ILocalizationService _localizationService;
        private readonly IAdvertisementService _advertisementService;
        public List<Category> categories;
        //private readonly ILogger<HomeController> _logger;
        //private readonly IStringLocalizer<HomeController> _localizer;
        private readonly ICityService _cityService;
        private readonly ICategoryService _categoryService;

        List<List<Category>> cats = new List<List<Category>>();
        Dictionary<string, List<Category>> catsDictionary = new Dictionary<string, List<Category>>();
        public AdvertisementController(DivarContext db, IStringLocalizer<AddController> localizer, IAdvertisementService advertisementService, ILogger<HomeController> logger, IStringLocalizer<HomeController> localizer, ICityService cityService, ICategoryService categoryService, ILocalizationService localizationService)
        {
            //_localizer = localizer;
            _advertisementService = advertisementService;
            _localizationService = localizationService;
            _context = db;
            //_logger = logger;
            //_localizer = localizer;

            _cityService = cityService;
            _categoryService = categoryService;
            _advertisementService = advertisementService;
            _localizationService = localizationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAdvertisements()
        {
            var advertisements = await _context.Advertisements.ToListAsync();
            return Ok(advertisements);
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetAdvertisementById(int id)
        {
            var advertisement = await _context.Advertisements.FindAsync(id);
            if (advertisement is null)
            {
                return NotFound();
            }
            return Ok(advertisement);
        }
        [HttpPost]
        //[HttpPost("ads/add")]
        //[HttpPost("advertisements/add")]
        //[HttpPost("items/add")]
        [HttpPost("add")]
        [ValidateAntiForgeryToken]
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
        [HttpPut]
        //[HttpGet("edit/{id}")]
        //[HttpGet("advertisements/edit/{id:int:min(1)}")]
        //[HttpGet("ads/edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateAdvertisements(int id ,AddAdvertisementDto advertisementDto)
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
        [HttpDelete]
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



        [HttpGet("")]
        //[HttpGet("Home")]
        public async Task<IActionResult> Index()
        {
            var Viesws = await _advertisementService.GetAllAdvertisementsAsyncHomeVM();
            foreach (var ad in Viesws)
            {
                var breadcrumbs = await _categoryService.GetBreadcrumbsAsync((int)ad.CategoryId);

                ViewData["breadcrumbs" + ad.Id.ToString()] = breadcrumbs;
                catsDictionary["breadcrumbs" + ad.Id.ToString()] = breadcrumbs;
                this.cats.Add(breadcrumbs);

                var city = await _cityService.GetCityByIdAsync((int)ad.CityId);
                ViewData["city" + ad.Id.ToString()] = city.Name;
            }]
        }
        //[HttpGet("details/{id}")]
        //[HttpGet("ads/details/{id}")]
        //[HttpGet("ads/{id:int:min(1)}")]
        //[HttpGet("advertisements/details/{id}")]
        //[HttpGet("advertisements/{id:int:min(1)}")]
        public async Task<IActionResult> Details(int id)
        {
            ViewData["currentDate"] = DateTime.Now.ToString("D", CultureInfo.CurrentCulture);
            var Views = await _advertisementService.GetAllAdvertisementsAsyncHomeDetailsVM();
            var ad = Views.FirstOrDefault(a => a.Id == id);
            if (ad == null)
            {
                return NotFound("محصولی با این شناسه یافت نشد.");
            }
            return View(ad);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var view = await _advertisementService.GetAdvertisementByIdAsyncHomeEditVM(id);
        }
        public async Task<IActionResult> Edit(HomeEditViewModel model)
        {
            var view = await _advertisementService.GetAdvertisementByIdAsyncHomeDetailsVM(model.Id);]
        }
        [HttpPost("")]
        //[HttpPost("Home")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(string SearchString, string culture)
        {
            ViewData["currentDate"] = DateTime.Now.ToString("D", CultureInfo.CurrentCulture);
            var memberList = await _advertisementService.GetAllAdvertisementsAsyncHomeVM();
            foreach (var ad in memberList)
            {
                var breadcrumbs = await _categoryService.GetBreadcrumbsAsync((int)ad.CategoryId);
                ViewData["breadcrumbs" + ad.Id.ToString()] = breadcrumbs;
                catsDictionary["breadcrumbs" + ad.Id.ToString()] = breadcrumbs;
                this.cats.Add(breadcrumbs);
                var city = await _cityService.GetCityByIdAsync((int)ad.CityId);
                ViewData["city" + ad.Id.ToString()] = city.Name;
            }
            if (!ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(culture))
                {
                    var cultureInfo = new CultureInfo(culture);
                    CultureInfo.CurrentCulture = cultureInfo;
                    CultureInfo.CurrentUICulture = cultureInfo;
                    Response.Cookies.Append("culture", cultureInfo.Name, new CookieOptions
                    {
                        Expires = DateTimeOffset.UtcNow.AddYears(1), // تاریخ انقضا
                        HttpOnly = true, // فقط از طریق HTTP قابل دسترسی
                        SameSite = SameSiteMode.Lax // یا Strict یا None
                    });
                }
                return View("Index", memberList);
            }
            if (!SearchString.IsNullOrEmpty())
            {
                var ads = await _advertisementService.SearchAdvertisementsAsync(SearchString);

                foreach (var ad in ads)
                {
                    var breadcrumbs = await _categoryService.GetBreadcrumbsAsync((int)ad.CategoryId);

                    ViewData["breadcrumbs" + ad.Id.ToString()] = breadcrumbs;
                    catsDictionary["breadcrumbs" + ad.Id.ToString()] = breadcrumbs;
                    this.cats.Add(breadcrumbs);

                    //var city = await _context.Cities.FirstOrDefaultAsync(cat => cat.Id == ad.CityId);
                    var city = await _cityService.GetCityByIdAsync((int)ad.CityId);
                    ViewData["city" + ad.Id.ToString()] = city.Name;
                }



                // تغییر فرهنگ به مقداری که از URL گرفته شده است
                if (!string.IsNullOrEmpty(culture))
                {
                    var cultureInfo = new CultureInfo(culture);
                    CultureInfo.CurrentCulture = cultureInfo;
                    CultureInfo.CurrentUICulture = cultureInfo;

                    // ذخیره فرهنگ در کوکی
                    Response.Cookies.Append("culture", cultureInfo.Name, new CookieOptions
                    {
                        Expires = DateTimeOffset.UtcNow.AddYears(1), // تاریخ انقضا
                        HttpOnly = true, // فقط از طریق HTTP قابل دسترسی
                        SameSite = SameSiteMode.Lax // یا Strict یا None
                    });
                }



                return View("Index", ads);
            }



            // تغییر فرهنگ به مقداری که از URL گرفته شده است
            if (!string.IsNullOrEmpty(culture))
            {
                var cultureInfo = new CultureInfo(culture);
                CultureInfo.CurrentCulture = cultureInfo;
                CultureInfo.CurrentUICulture = cultureInfo;

                // ذخیره فرهنگ در کوکی
                Response.Cookies.Append("culture", cultureInfo.Name, new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddYears(1), // تاریخ انقضا
                    HttpOnly = true, // فقط از طریق HTTP قابل دسترسی
                    SameSite = SameSiteMode.Lax // یا Strict یا None
                });
            }



            return View("Index", memberList);

        }
        public ActionResult ChangeCulture(string culture)
        {
            _localizationService.ChangeCultureInfo(culture);
            return Redirect(Request.Headers["Referer"].ToString());
        }

    }
}
