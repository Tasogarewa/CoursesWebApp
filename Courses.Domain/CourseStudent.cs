using Courses.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Domain
{
    public class CourseStudent
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public virtual AppUser User { get; set; }
        public Guid CourseId { get; set; }
        public virtual Course Course { get; set; }
        public int Lections { get; set; }
        public int CompletedLections {get; set; } 
        public virtual Review? Review { get; set; }

    }
}
