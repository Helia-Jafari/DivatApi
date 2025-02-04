using DivatApi.Models;
using System.ComponentModel.DataAnnotations;

namespace DivatApi.Dtos
{
    public class AddAdvertisementDto
    {
            [Required]
            //[Required(ErrorMessage = "This fild is required")]
            //[Required(ErrorMessage = (string)_localizer["RequiredInputError"])]
            //[Required(ErrorMessage = _localizer["RequiredInputError"])
            [MinLength(6)]
            //[MinLength(6)]
            [Display(Name = "Title")]
            public string Title { get; set; } = null!;

            [Required]
            public string Description { get; set; } = null!;

            public int? CategoryId { get; set; }

            public string? Longitude { get; set; }

            public string? Latitude { get; set; }

            [Required]
            public string? Brand { get; set; }

            [Required]
            public string? ItsModel { get; set; }

            [Required]
            public string? Color { get; set; }

            [Required]
            public int? FunctionKilometers { get; set; }

            [Required]
            public string? ChassisAndBodyCondition { get; set; }

            [Required]
            //[Range(10000000, 999999999)]
            public decimal? BasePrice { get; set; }

            public string? EngineCondition { get; set; }

            public string? ThirdPartyInsuranceTerm { get; set; }

            public string? Gearbox { get; set; }

            public bool DoYouWantToReplace { get; set; }

            public bool IsTheChatActivated { get; set; }

            public bool IsThePhoneCallActive { get; set; }

            public string? FrontChassisCondition { get; set; }

            public string? RearChassisCondition { get; set; }

            public string Nationality { get; set; } = null!;

            [Required]
            //[MinLength(10)]
            //[MaxLength(10)]
            public string NationalCode { get; set; } = null!;

            public int? CityId { get; set; }

            public virtual Category? Category { get; set; }

            public virtual City? City { get; set; }
        }
    }

