using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public Task<T> CreateAsync (T entity);
        public Task UpdateAsync (T entity);
        public Task DeleteAsync (T entity);
        public Task<T> GetAsync (Guid Id);
        public Task<IEnumerable<T>> GetAllAsync();
    }
}
