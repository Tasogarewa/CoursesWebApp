using Courses.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Domain
{
    public class CodeEx
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public string Hint { get; set; }
        public Guid LectionId { get; set; }
        public virtual Lection Lection { get; set; }
        public string Solution { get; set; }   
        public virtual ICollection<Image>? Images { get; set; } = new List<Image>();
    }
}
