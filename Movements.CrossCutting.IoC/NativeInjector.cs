using Microsoft.Extensions.DependencyInjection;
using System;
using Template.Application.Interfaces;
using Template.Application.Services;
using Template.Data.Repositories;
using Template.Domain.Interfaces;

namespace Template.CrossCutting.IoC
{
    public static class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {

            #region Services
            
            services.AddScoped<IMovementService, MovementService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICosifService, CosifService>();

            #endregion

            #region Repositories
            
            services.AddScoped<IMovementRepository, MovementRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICosifRepository, CosifRepository>();

            #endregion
        }
    }
}
