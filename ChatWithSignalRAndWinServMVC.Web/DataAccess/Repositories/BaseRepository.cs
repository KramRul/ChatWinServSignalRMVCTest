using ChatWithSignalRAndWinServMVC.Web.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ChatWithSignalRAndWinServMVC.Web.DataAccess.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected DbContext dataBase;
        private DbSet<T> _dbSet;

        public BaseRepository(DbContext context)
        {
            dataBase = context;
            _dbSet = context.Set<T>();
        }

        public async Task<List<T>> GetAll()
        {
            var result = await _dbSet.ToListAsync();
            return result;
        }

        public async Task<T> Get(Guid id)
        {
            var result = await _dbSet.FindAsync(id);
            return result;
        }

        public async Task Create(T item)
        {
            _dbSet.Add(item);
            await dataBase.SaveChangesAsync();
        }

        public async Task Create(List<T> items)
        {
            _dbSet.AddRange(items);
            await dataBase.SaveChangesAsync();
        }

        public async Task Update(T item)
        {
            dataBase.Entry(item).State = EntityState.Modified;
            await dataBase.SaveChangesAsync();
        }

        public async Task Update(List<T> items)
        {
            dataBase.Entry(items).State = EntityState.Modified;
            await dataBase.SaveChangesAsync();
        }

        public async Task Delete(T item)
        {
            _dbSet.Remove(item);
            await dataBase.SaveChangesAsync();
        }

        public async Task<int> Count()
        {
            var result = await _dbSet.CountAsync();
            return result;
        }
    }
}