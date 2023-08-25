using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Domain
{
    public class Test
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid LectionId { get; set; }
        public virtual Lection Lection { get; set; }
        public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
    }
}
