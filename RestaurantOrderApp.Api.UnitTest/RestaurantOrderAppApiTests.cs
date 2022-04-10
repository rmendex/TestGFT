using Microsoft.EntityFrameworkCore;
using Moq;
using RestaurantOrderApp.Api.Domain.Entities;
using RestaurantOrderApp.Api.Infra.Context;
using RestaurantOrderApp.Api.Infra.Repositories;
using RestaurantOrderApp.Api.Infra.Resources.Queries;
using System.Collections.Generic;
using Xunit;

namespace RestaurantOrderApp.Api.UnitTest
{
    public class RestaurantOrderAppApiTests
    {
        [Fact(DisplayName = "Get dishes from database")]
        public async void NeedToGetDishesInDataBase()
        {
            //Arrange
            var _menuContext = new Mock<MenuContext>();
            string TimeOfDay = "morning";
            List<int> DishType = new List<int>() { 1, 2, 3 };

            #region Create In Memory Database
            
            var options = new DbContextOptionsBuilder<MenuContext>()
            .UseInMemoryDatabase(databaseName: "BaseTesteGFT")
            .Options;

            //// Create mocked Context by seeding Data as per Schema///
            using (var context = new MenuContext(options))
            {
                context.Menu.Add(new Menu
                {
                    Id = 1,
                    DishType = 1,
                    TimeOfDay = "morning",
                    Meal = "eggs"
                });

                context.Menu.Add(new Menu
                {
                    Id = 2,
                    DishType = 2,
                    TimeOfDay = "morning",
                    Meal = "toast"
                });

                context.Menu.Add(new Menu
                {
                    Id = 3,
                    DishType = 3,
                    TimeOfDay = "morning",
                    Meal = "coffee"
                });

                context.Menu.Add(new Menu
                {
                    Id = 4,
                    DishType = 4,
                    TimeOfDay = "morning",
                    Meal = "Not Applicable"
                });

                context.Menu.Add(new Menu
                {
                    Id = 5,
                    DishType = 1,
                    TimeOfDay = "night",
                    Meal = "steak"
                });

                context.Menu.Add(new Menu
                {
                    Id = 6,
                    DishType = 2,
                    TimeOfDay = "night",
                    Meal = "potato"
                });

                context.Menu.Add(new Menu
                {
                    Id = 7,
                    DishType = 3,
                    TimeOfDay = "night",
                    Meal = "wine"
                });

                context.Menu.Add(new Menu
                {
                    Id = 8,
                    DishType = 4,
                    TimeOfDay = "night",
                    Meal = "cake"
                });

                context.SaveChanges();
            }
            #endregion

            #region ExpectedOutcome
            List<Menu> lstExpectedOutcome = new List<Menu>()
            {
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
                }
            };
            #endregion

            //Act and Assert
            #region Use a context instance with data to run the test for your business code
            using (var context = new MenuContext(options))
            {
                MenuRepository menuRepository = new MenuRepository(context);
                List<Menu> result = await menuRepository.GetDishesRepository(TimeOfDay, DishType);

                Assert.Equal(lstExpectedOutcome, result);
            }
            #endregion
        }

        [Fact(DisplayName = "Request different ordered dish types - no case sensitive")]
        public void Request_DifferentDishesTypesNoCaseSensitive_ReturnsOrderedDishesTypes()
        {
            #region Arrange
            List<Menu> lstMenuFromDataBase = new List<Menu>()
            {
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
                }
            };

            GetDishesQuery getDishesQueryInput = new GetDishesQuery()
            {
                TimeOfDay = "Morning",
                DishType = new List<int>() { 1, 2, 3 }
            };

            string expectedOutcome = "eggs, toast, coffee";
            #endregion

            #region Act
            GetDishesQueryHandler getDishesQueryHandler = new GetDishesQueryHandler();

            var result = getDishesQueryHandler.OrderProcessed(getDishesQueryInput, lstMenuFromDataBase);
            #endregion

            //Assert
            Assert.Equal(expectedOutcome, result);
        }

        [Fact(DisplayName = "Request different ordered dish types")]
        public void Request_DifferentDishesTypes_ReturnsOrderedDishesTypes()
        {
            #region Arrange
            List<Menu> lstMenuFromDataBase = new List<Menu>()
            {
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
                }
            };

            GetDishesQuery getDishesQueryInput = new GetDishesQuery()
            {
                TimeOfDay = "morning",
                DishType = new List<int>() { 1, 2, 3 }
            };

            string expectedOutcome = "eggs, toast, coffee";
            #endregion

            #region Act
            GetDishesQueryHandler getDishesQueryHandler = new GetDishesQueryHandler();

            var result = getDishesQueryHandler.OrderProcessed(getDishesQueryInput, lstMenuFromDataBase);
            #endregion

            //Assert
            Assert.Equal(expectedOutcome, result);
        }

        [Fact(DisplayName = "Request multiples dish types of the same type")]
        public void Request_MultiplesDishesTypesOfTheSameType_ReturnsOrderedDishesTypesWithMultiplesDishesTypes()
        {
            #region Arrange
            List<Menu> lstMenuFromDataBase = new List<Menu>()
            {
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
                    Id = 6,
                    DishType = 2,
                    TimeOfDay = "night",
                    Meal = "potato"
                },
                new Menu()
                {
                    Id = 8,
                    DishType = 4,
                    TimeOfDay = "night",
                    Meal = "cake"
                }
            };

            GetDishesQuery getDishesQueryInput = new GetDishesQuery()
            {
                TimeOfDay = "night",
                DishType = new List<int>() { 1, 2, 2, 4 }
            };

            string expectedOutcome = "steak, potato(x2), cake";
            #endregion

            #region Act
            GetDishesQueryHandler getDishesQueryHandler = new GetDishesQueryHandler();

            var result = getDishesQueryHandler.OrderProcessed(getDishesQueryInput, lstMenuFromDataBase);
            #endregion

            //Assert
            Assert.Equal(expectedOutcome, result);
        }

        [Fact(DisplayName = "Request dish types with error")]
        public void Request_DishesTypesWithError_ReturnsOrderedDishesTypesWithError()
        {
            #region Arrange
            List<Menu> lstMenuFromDataBase = new List<Menu>()
            {
                new Menu()
                {
                    Id = 5,
                    DishType = 1,
                    TimeOfDay = "night",
                    Meal = "steak"
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
                }
            };

            GetDishesQuery getDishesQueryInput = new GetDishesQuery()
            {
                TimeOfDay = "morning",
                DishType = new List<int>() { 1, 1, 2, 3, 5 }
            };

            string expectedOutcome = "steak, error";
            #endregion

            #region Act
            GetDishesQueryHandler getDishesQueryHandler = new GetDishesQueryHandler();

            var result = getDishesQueryHandler.OrderProcessed(getDishesQueryInput, lstMenuFromDataBase);
            #endregion

            //Assert
            Assert.Equal(expectedOutcome, result);
        }

        [Fact(DisplayName = "Request dish types with error - Not Applicable")]
        public void Request_DishesTypesWithError_ReturnsOrderedDishesTypesWithErrorNotApplicable()
        {
            #region Arrange
            List<Menu> lstMenuFromDataBase = new List<Menu>()
            {
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
                }
            };

            GetDishesQuery getDishesQueryInput = new GetDishesQuery()
            {
                TimeOfDay = "morning",
                DishType = new List<int>() { 1, 2, 3, 4 }
            };

            string expectedOutcome = "eggs, toast, coffee, error";
            #endregion

            #region Act
            GetDishesQueryHandler getDishesQueryHandler = new GetDishesQueryHandler();

            var result = getDishesQueryHandler.OrderProcessed(getDishesQueryInput, lstMenuFromDataBase);
            #endregion

            //Assert
            Assert.Equal(expectedOutcome, result);
        }


    }
}
