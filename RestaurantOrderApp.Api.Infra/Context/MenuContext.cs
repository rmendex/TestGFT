using Microsoft.EntityFrameworkCore;
using RestaurantOrderApp.Api.Domain.Entities;
using RestaurantOrderApp.Api.Infra.Mapping;

namespace RestaurantOrderApp.Api.Infra.Context
{
    public class MenuContext : DbContext
    {
        public MenuContext(DbContextOptions<MenuContext> options) : base(options)
        {

        }

        public DbSet<Menu> Menu { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MenuMap());

            modelBuilder.Entity<Menu>().HasData(
                new Menu()
                {
                    Id = 1,
                    DishType = 1,
                    TimeOfDay = "morning",
                    Meal = "eggs"
                },
                new Menu()
                {
                    Id = 2,
                    DishType = 2,
                    TimeOfDay = "morning",
                    Meal = "toast"
                },
                new Menu()
                {
                    Id = 3,
                    DishType = 3,
                    TimeOfDay = "morning",
                    Meal = "coffee"
                },
                new Menu()
                {
                    Id = 4,
                    DishType = 4,
                    TimeOfDay = "morning",
                    Meal = "Not Applicable"
                },
                new Menu()
                {
                    Id = 5,
                    DishType = 1,
                    TimeOfDay = "night",
                    Meal = "steak"
                },
                new Menu()
                {
                    Id = 6,
                    DishType = 2,
                    TimeOfDay = "night",
                    Meal = "potato"
                },
                new Menu()
                {
                    Id = 7,
                    DishType = 3,
                    TimeOfDay = "night",
                    Meal = "wine"
                },
                new Menu()
                {
                    Id = 8,
                    DishType = 4,
                    TimeOfDay = "night",
                    Meal = "cake"
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
