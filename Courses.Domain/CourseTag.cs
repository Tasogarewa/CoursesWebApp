using Courses.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Domain
{
    public  class CourseTag
    {
        public Guid Id { get; set; }
        public Tags Tag { get; set; }
    }
}
