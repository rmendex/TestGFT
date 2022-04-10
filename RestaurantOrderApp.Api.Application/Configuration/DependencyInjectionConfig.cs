using Microsoft.Extensions.DependencyInjection;
using RestaurantOrderApp.Api.Domain.Interfaces;
using RestaurantOrderApp.Api.Infra.Repositories;
using System;

namespace RestaurantOrderApp.Api.Application.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            #region Repositories
            services.AddTransient<IMenuRepository, MenuRepository>();
            #endregion
        }
    }
}
