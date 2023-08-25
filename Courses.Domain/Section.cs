using Courses.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tasogarewa.Domain
{
    public class Section
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Lection>? Lections { get; set; } = new List<Lection>();
        public virtual Course Course { get; set; }
    }
}
