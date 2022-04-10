using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantOrderApp.Api.Domain.Entities;

namespace RestaurantOrderApp.Api.Infra.Mapping
{
    public class MenuMap : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.DishType);
            builder.Property(u => u.TimeOfDay);
            builder.Property(u => u.Meal);
        }
    }
}
