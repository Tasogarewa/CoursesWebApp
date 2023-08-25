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
        public Task<T> Create (T entity);
        public Task Update (T entity);
        public Task Delete (T entity);
        public Task<T> GetAsync (Guid Id);
        public Task<IEnumerable<T>> GetAllAsync();
     
    }
}
