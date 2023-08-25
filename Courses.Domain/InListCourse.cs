using Courses.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Domain
{
    public class InListCourse
    {
        public Guid Id { get; set; }
        public virtual UserNamedList UserNamedList { get; set; }   
        public virtual Course Course { get; set; }
    }
}
