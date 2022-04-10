using System.Threading.Tasks;

namespace RestaurantOrderApp.Api.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetById(int id);
    }
}
