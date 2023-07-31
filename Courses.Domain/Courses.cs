using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Domain
{
    public  class Courses
    {
        public Guid Id { get; set; }
        public DateTime CreateAt { get; set; }
        public decimal price { get; set; }
        public DateTime Expires { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string FilePath { get; set; }
        public ICollection<Images> Images { get; set; }
        public int Rating { get; set; }
        public ICollection<Comments> Comments { get; set; }

        public Courses() => 
            Images = new List<Images>();
            Comments = new List<Images>();
    }
}
