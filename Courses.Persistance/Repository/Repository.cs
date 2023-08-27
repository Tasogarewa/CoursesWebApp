using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Interfaces;

namespace Tasogarewa.Persistance.Common
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly DbSet<T> _dbSet;
        private readonly DbContext _dbContext;
        public Repository(TasogarewaDbContext Context)
        {
            _dbContext = Context;
            _dbSet = _dbContext.Set<T>();

        }
        public async Task<T> CreateAsync(T entity)
        {
             await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return  entity;


        }

        public async Task  DeleteAsync(T entity)
        {
         _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> GetAsync(Guid Id)
        {
            return await _dbSet.FindAsync(Id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }


        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
       
    }
}
