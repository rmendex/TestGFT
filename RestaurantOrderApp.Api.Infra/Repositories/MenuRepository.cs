using Microsoft.EntityFrameworkCore;
using RestaurantOrderApp.Api.Domain.Entities;
using RestaurantOrderApp.Api.Domain.Interfaces;
using RestaurantOrderApp.Api.Infra.Abstraction;
using RestaurantOrderApp.Api.Infra.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOrderApp.Api.Infra.Repositories
{
    public class MenuRepository : Repository<Menu>, IMenuRepository
    {
        public MenuRepository(MenuContext context) : base(context)
        {

        }
        public async Task<List<Menu>> GetDishesRepository(string TimeOfDay, List<int> DishType)
        {
            List<Menu> lstMenu = new List<Menu>();

            foreach (var dish in DishType)
            {
                lstMenu.AddRange((await _DbSet.ToListAsync())
                     .Where(a => a.TimeOfDay.Equals(TimeOfDay) && a.DishType == dish));
            }

            return lstMenu.OrderBy(x => x.DishType).ToList();
        }
    }
}
