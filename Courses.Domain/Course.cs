using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Domain;

namespace Courses.Domain
{
    public  class Course
    {
        public Guid Id { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public decimal Price { get; set; }
        public DateTime Expires { get; set; }
        [MinLength(4)]
        [MaxLength(30)]
        public string Name { get; set; }
        [MinLength(300)]
        [MaxLength(2000)]
        public string Description { get; set; }
        public virtual AppUser appUser { get; set; }
        public string FilePath { get; set; }
        public virtual ICollection<Image> Images { get; set; } = new List<Image>();
        public int Rating { get; set; }
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

   
    }
}
