using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Interfaces;

namespace Tasogarewa.Persistance.Services
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly DbSet<T> _dbSet;
        private readonly DbContext _dbContext;
        public Repository() { }
        public Repository(DbContext Context)
        {
            _dbContext = Context;
            _dbSet = _dbContext.Set<T>();

        }
        public void Create(T entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChangesAsync();
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            _dbContext.SaveChangesAsync();
        }

        public T Get(Guid id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
       
    }
}
