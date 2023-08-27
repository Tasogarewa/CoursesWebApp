using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.Common.Exceptions
{
    public class NotFoundException<T>:Exception
    {
        public  NotFoundException(string name,object key):base($"Entity {name}({key}) not found")
        {
          
        }
        public static void Throw(T entity,object key)
        {
            if (entity == null || (Guid)key == Guid.Empty)
            {
                throw new NotFoundException<T>(nameof(entity), key);
            }
        }
        public static void ThrowRange(List<T> entities, object key)
        {
            if (entities.Count==0 || (Guid)key == Guid.Empty)
            {
                throw new NotFoundException<T>(nameof(entities), key);
            }
        }
    }
}
