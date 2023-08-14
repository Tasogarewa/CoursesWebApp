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
        public async Task<T> Create(T entity)
        {
             await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return  entity;


        }

        public  void Delete(T entity)
        {
           _dbSet.Remove(entity);
           _dbContext.SaveChangesAsync();
        }

        public async Task<T> GetAsync(Guid Id)
        {
            return await _dbSet.FindAsync(Id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }


        public  void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChangesAsync();
        }
       
    }
}
