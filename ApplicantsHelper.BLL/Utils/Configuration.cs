using ApplicantsHelper.BLL.Converters;
using ApplicantsHelper.BLL.Interfaces.Converters;
using ApplicantsHelper.BLL.Interfaces.Services;
using ApplicantsHelper.BLL.Services;
using ApplicantsHelper.DAL.Interfaces.Repositories;
using ApplicantsHelper.DAL.Repositories;
using ApplicantsHelper.DAL.Utils;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicantsHelper.BLL.Utils
{
    public static class Configuration
    {
        public static void ConfigureBllServices(this IServiceCollection services)
        {
            services.ConfigureDalRepositories();
            services.AddScoped(typeof(ISpecialtyService), typeof(SpecialtyService));
            services.AddScoped(typeof(IUniversityService), typeof(UniversityService));
            services.AddScoped(typeof(ISpecialtyConverter), typeof(SpecialtyConverter));
            services.AddScoped(typeof(IUniversityConverter), typeof(UniversityConverter));
        }
    }
}
