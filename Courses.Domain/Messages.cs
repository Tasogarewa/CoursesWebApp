using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Domain
{
    public class Messages
    {
        public Guid Id { get; set; }
        public AppUser AppUser { get; set; }
        public DateTime Sended { get; set; }
        public string Text { get; set; }
        public Chats Chat { get; set; }
        public ICollection<Images> Images { get; set; }
        public Messages()=>
            Images = new List<Images>();
    }
}
