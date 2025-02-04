using DivatApi.Dtos;
using DivatApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Drawing;

namespace DivatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisementController : ControllerBase
    {
        private readonly DivarContext _context;
        public AdvertisementController(DivarContext divarContext)
        {
            this._context = divarContext;
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
        public async Task<IActionResult> AddAdvertisements(AddAdvertisementDto advertisementDto)
        {
            var advertisement = new Advertisement
            {
                BasePrice = Convert.ToInt32(advertisementDto.BasePrice),
                CityId = advertisementDto.CityId,
                CategoryId = advertisementDto.CategoryId,
                City = advertisementDto.City,
                Category = advertisementDto.Category,
                FunctionKilometers = Convert.ToInt32(advertisementDto.FunctionKilometers),
                Color = advertisementDto.Color,
                Brand = advertisementDto.Brand,
                ChassisAndBodyCondition = advertisementDto.ChassisAndBodyCondition,
                Description = advertisementDto.Description,
                DoYouWantToReplace = advertisementDto.DoYouWantToReplace,
                EngineCondition = advertisementDto.EngineCondition,
                FrontChassisCondition = advertisementDto.FrontChassisCondition,
                Gearbox = advertisementDto.Gearbox,
                IsTheChatActivated = advertisementDto.IsTheChatActivated,
                IsThePhoneCallActive = advertisementDto.IsThePhoneCallActive,
                Latitude = advertisementDto.Latitude,
                Longitude = advertisementDto.Longitude,
                ItsModel = advertisementDto.ItsModel,
                NationalCode = advertisementDto.NationalCode,
                RearChassisCondition = advertisementDto.RearChassisCondition,
                Nationality = advertisementDto.Nationality,
                ThirdPartyInsuranceTerm = advertisementDto.ThirdPartyInsuranceTerm,
                Title = advertisementDto.Title,
                Status = "Active",
                InsertDate = DateTime.Now,
                UpdateDate = DateTime.Now
            };
            await _context.Advertisements.AddAsync(advertisement);
            _context.SaveChanges();
            return CreatedAtAction("AddAdvertisements", advertisement);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAdvertisements(int id ,AddAdvertisementDto advertisementDto)
        {
            var advertisement = await _context.Advertisements.FindAsync(id);
            if (advertisement is null)
            {
                return NotFound();
            }
            advertisement.Id = id;
            advertisement.BasePrice = Convert.ToInt32(advertisementDto.BasePrice);
            advertisement.CityId = advertisementDto.CityId;
            advertisement.CategoryId = advertisementDto.CategoryId;
            advertisement.City = advertisementDto.City;
            advertisement.Category = advertisementDto.Category;
            advertisement.FunctionKilometers = Convert.ToInt32(advertisementDto.FunctionKilometers);
            advertisement.Color = advertisementDto.Color;
            advertisement.Brand = advertisementDto.Brand;
            advertisement.ChassisAndBodyCondition = advertisementDto.ChassisAndBodyCondition;
            advertisement.Description = advertisementDto.Description;
            advertisement.DoYouWantToReplace = advertisementDto.DoYouWantToReplace;
            advertisement.EngineCondition = advertisementDto.EngineCondition;
            advertisement.FrontChassisCondition = advertisementDto.FrontChassisCondition;
            advertisement.Gearbox = advertisementDto.Gearbox;
            advertisement.IsTheChatActivated = advertisementDto.IsTheChatActivated;
            advertisement.IsThePhoneCallActive = advertisementDto.IsThePhoneCallActive;
            advertisement.Latitude = advertisementDto.Latitude;
            advertisement.Longitude = advertisementDto.Longitude;
            advertisement.ItsModel = advertisementDto.ItsModel;
            advertisement.NationalCode = advertisementDto.NationalCode;
            advertisement.RearChassisCondition = advertisementDto.RearChassisCondition;
            advertisement.Nationality = advertisementDto.Nationality;
            advertisement.ThirdPartyInsuranceTerm = advertisementDto.ThirdPartyInsuranceTerm;
            advertisement.Title = advertisementDto.Title;
            advertisement.Status = "Active";
            advertisement.InsertDate = DateTime.Now;
            advertisement.UpdateDate = DateTime.Now;
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
            _context.SaveChanges();
            return Ok(advertisement);
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteAdvertisement(int id)
        {
            var advertisement = await _context.Advertisements.FindAsync(id);
            if (advertisement is null)
            {
                return NotFound();
            }
            _context.Remove(advertisement);
            _context.SaveChanges();
            return Ok(advertisement);
        }
    }
}
