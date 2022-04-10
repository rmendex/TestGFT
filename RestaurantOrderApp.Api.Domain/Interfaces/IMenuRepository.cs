using RestaurantOrderApp.Api.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantOrderApp.Api.Domain.Interfaces
{
    public interface IMenuRepository : IRepository<Menu>
    {
        Task<List<Menu>> GetDishesRepository(string TimeOfDay, List<int> DishType);
    }
}
