using System.Collections.Generic;
using System.Linq;
using lab4.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace lab4.Data {

    public class SampleData
    {
        public static void Intialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope()) {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.EnsureCreated();

                if (context.Provinces.Any()) return;
                var provinces = GetProvinces().ToArray();
                context.Provinces.AddRange(provinces);
                context.SaveChanges();

                if (context.Cities.Any()) return;
                var cities = GetCities(context).ToArray();
                context.Cities.AddRange(cities);
                context.SaveChanges();

            }
        }

        public static List<Province> GetProvinces() {
            List<Province> provinces = new List<Province> {
                new Province() { ProvinceCode = "BC", ProvinceName = "British Columbia" },
                new Province() { ProvinceCode = "AB", ProvinceName = "Alberta" },
                new Province() { ProvinceCode = "SK", ProvinceName = "Saskatchewan" },
            };
            return provinces;
        }

        public static List<City> GetCities(ApplicationDbContext context) {
            List<City> cities = new List<City> {
                new City() { 
                    CityName = "Vancouver", Population = 4000000,
                    ProvinceCode = context.Provinces.Find("BC").ProvinceCode
                },
                new City() { 
                    CityName = "Pemberton", Population = 2500,
                    ProvinceCode = context.Provinces.Find("BC").ProvinceCode
                },
                new City() { 
                    CityName = "Whistler", Population = 11500,
                    ProvinceCode = context.Provinces.Find("BC").ProvinceCode
                },
                new City() { 
                    CityName = "Calgary", Population = 1200000,
                    ProvinceCode = context.Provinces.Find("AB").ProvinceCode
                },
                new City() { 
                    CityName = "Edmonton", Population = 930000,
                    ProvinceCode = context.Provinces.Find("AB").ProvinceCode
                },
                new City() { 
                    CityName = "Medicine Hat", Population = 63000,
                    ProvinceCode = context.Provinces.Find("AB").ProvinceCode
                },
                new City() {
                    CityName = "Saskatoon", Population = 246000,
                    ProvinceCode = context.Provinces.Find("SK").ProvinceCode
                },
                new City() { 
                    CityName = "Regina", Population = 215000,
                    ProvinceCode = context.Provinces.Find("SK").ProvinceCode
                },
                new City() { 
                    CityName = "Moosejaw", Population = 33000,
                    ProvinceCode = context.Provinces.Find("SK").ProvinceCode
                },
            };
            return cities;
        }

    }

}