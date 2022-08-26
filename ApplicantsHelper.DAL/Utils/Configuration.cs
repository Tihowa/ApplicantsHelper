using ApplicantsHelper.DAL.Interfaces.Repositories;
using ApplicantsHelper.DAL.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ApplicantsHelper.DAL.Context;

namespace ApplicantsHelper.DAL.Utils
{
    public static class Configuration
    {
        public static void ConfigureDalRepositories(this IServiceCollection services)
        {
            string connectionString = GetConnectionString("appsettings.json", "DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped(typeof(ISpecialtyRepository),typeof(SpecialtyRepository));
            services.AddScoped(typeof(IUniversityRepository), typeof(UniversityRepository));
        }
        private static string GetConnectionString(string jsonFileName,string connectionStringName)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile(jsonFileName);
            var config = builder.Build();
            return config.GetConnectionString(connectionStringName);
        }
    }
}
