// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestaurantOrderApp.Api.Infra.Context;

namespace RestaurantOrderApp.Api.Infra.Migrations
{
    [DbContext(typeof(MenuContext))]
    partial class MenuContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RestaurantOrderApp.Api.Domain.Entities.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DishType")
                        .HasColumnType("int");

                    b.Property<string>("Meal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TimeOfDay")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Menu");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DishType = 1,
                            Meal = "eggs",
                            TimeOfDay = "morning"
                        },
                        new
                        {
                            Id = 2,
                            DishType = 2,
                            Meal = "toast",
                            TimeOfDay = "morning"
                        },
                        new
                        {
                            Id = 3,
                            DishType = 3,
                            Meal = "coffee",
                            TimeOfDay = "morning"
                        },
                        new
                        {
                            Id = 4,
                            DishType = 4,
                            Meal = "Not Applicable",
                            TimeOfDay = "morning"
                        },
                        new
                        {
                            Id = 5,
                            DishType = 1,
                            Meal = "steak",
                            TimeOfDay = "night"
                        },
                        new
                        {
                            Id = 6,
                            DishType = 2,
                            Meal = "potato",
                            TimeOfDay = "night"
                        },
                        new
                        {
                            Id = 7,
                            DishType = 3,
                            Meal = "wine",
                            TimeOfDay = "night"
                        },
                        new
                        {
                            Id = 8,
                            DishType = 4,
                            Meal = "cake",
                            TimeOfDay = "night"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
