using DivatApi.Interfaces;
using DivatApi.Models;
using DivatApi.Repositories;
using DivatApi.Services;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Globalization;

namespace DivatApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<DivarContext>();

            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            //builder.Services.AddSingleton<ILocalizationService, LocalizationService>();
            builder.Services.AddScoped<IAdvertisementService, AdvertisementService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<ICityService, CityService>();
            builder.Services.AddScoped<ISearchSpecification<Advertisement>, AdvertisementSearchSpecificationService>();

            //builder.Services.AddDistributedMemoryCache(options =>
            //{
            //    options.Configuration = "localhost:6379"; // ???? Redis Server (?? ???? ?????)
            //    options.InstanceName = "InventoryCache_";  // ?????? ??????? ??
            //}               );
            builder.Services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = "127.0.0.1:6379"; // ???? Redis Server
                options.InstanceName = "Sample";  // ?????? ??????? ??
            });

            builder.Services.AddMemoryCache();

            builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    });


            builder.Services.AddEndpointsApiExplorer();
            //builder.Services.adds

            builder.Services.AddSwaggerGen();

            builder.Services.AddLocalization(options => options.ResourcesPath = "Localization");
            var supportedCultures = new[]
            {
    new CultureInfo("en-US"),new CultureInfo("fa-IR")
};
            var requestLocalizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("fa-IR"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures,
                RequestCultureProviders = [
                    new QueryStringRequestCultureProvider(),
        new CookieRequestCultureProvider(),
        new AcceptLanguageHeaderRequestCultureProvider()
                ]
            };
            // /?culture=fa-IR&ui-culture=fa-IR

            var app = builder.Build();

            app.UseRequestLocalization(requestLocalizationOptions);

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
