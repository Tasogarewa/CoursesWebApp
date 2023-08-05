using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Domain;

namespace Courses.Domain
{
    public class Chat
    {
      
        public Guid Id { get; set; }
       
        public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
        public virtual ICollection<Image> Images { get; set; } = new List<Image>();
        public virtual ICollection<AppUser> AppUsers { get; set; } = new List<AppUser>();
      
    }
}
