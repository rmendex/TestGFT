using Microsoft.EntityFrameworkCore;
using RestaurantOrderApp.Api.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace RestaurantOrderApp.Api.Infra.Abstraction
{
    public abstract class Repository<T> : IDisposable, IRepository<T> where T : class
    {
        private readonly DbContext _Db;
        public readonly DbSet<T> _DbSet;
        private T _t;

        public Repository(DbContext context)
        {
            _Db = context;
            _DbSet = _Db.Set<T>();
        }

        public virtual async Task<T> GetById(int id)
        {
            try
            {
                _t = await _DbSet.FindAsync(id);
            }
            catch (Exception e)
            {
                throw e;
            }
            return _t;
        }

        public void Dispose()
        {
            _Db.Dispose();
        }
    }
}
