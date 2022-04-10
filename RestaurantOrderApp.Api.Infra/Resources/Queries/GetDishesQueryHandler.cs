using MediatR;
using RestaurantOrderApp.Api.Domain.Entities;
using RestaurantOrderApp.Api.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RestaurantOrderApp.Api.Infra.Resources.Queries
{
    public class GetDishesQueryHandler : IRequestHandler<GetDishesQuery, string>
    {
        private readonly IMenuRepository _menuRepository;

        public GetDishesQueryHandler()
        {
            
        }

        public GetDishesQueryHandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<string> Handle(GetDishesQuery request, CancellationToken cancellationToken)
        {
            //DataBase
            var lstMenu = await _menuRepository.GetDishesRepository(request.TimeOfDay.ToLower(), request.DishType);

            //Business Logic
            return OrderProcessed(request, lstMenu);
            
        }

        public string OrderProcessed(GetDishesQuery request, List<Menu> lstMenu)
        {
            
            StringBuilder meals = new StringBuilder();
            var countDishes = 0;
            var mealsFormatted = string.Empty;

            List<int> itemsNotFound;

            List<int> lstTemp = lstMenu.Select(x => x.DishType).ToList();

            itemsNotFound = request.DishType.Where(x => !lstTemp.Contains(x)).ToList();

            List<Menu> lstTransfer = new List<Menu>();

            foreach (var item in itemsNotFound)
            {

                lstTransfer = new List<Menu>(){
                new Menu
                {
                    DishType = item,
                    Meal = "Not Applicable"
                } };
            }

            lstMenu.AddRange(lstTransfer);

            lstMenu.OrderBy(x => x.DishType);

            foreach (var menu in lstMenu)
            {
                countDishes = lstMenu.Where(x => x.DishType == menu.DishType).Count();

                if (menu.Meal.Contains("Not Applicable"))
                {
                    return mealsFormatted = meals.Append("error").ToString();
                }

                if (!meals.ToString().Contains(menu.Meal) && (menu.Meal.Contains("coffee") || menu.Meal.Contains("potato")))
                {
                    if (countDishes > 1)
                        meals.Append($@"{menu.Meal}(x{countDishes}), ");
                    else
                        meals.Append($@"{menu.Meal}, ");
                }
                else if (meals.ToString().Contains(menu.Meal) && !(menu.Meal.Contains("coffee") || menu.Meal.Contains("potato")))
                {
                    return mealsFormatted = meals.Append("error").ToString();
                }
                else
                {
                    if (!meals.ToString().Contains(menu.Meal))
                        meals.Append($@"{menu.Meal}, ");
                }
            }

            mealsFormatted = meals.ToString().Remove(meals.Length - 2);

            return mealsFormatted;
        }
    }
}
