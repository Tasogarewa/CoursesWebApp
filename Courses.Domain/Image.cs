using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Domain
{
    public class Image
    {
        public Guid Id { get; set; }
        public AppUser appUser { get; set; } 
        public string Path { get; set; }
        public virtual Course Course { get; set; }
    }
}
