using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Domain
{
    public class Message
    {
        public Guid Id { get; set; }
        public virtual AppUser AppUser { get; set; }
        public DateTime Sended { get; set; }
        [MaxLength(1000)]
        public string Text { get; set; }
        public virtual Chat Chat { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public Message()=>
            Images = new List<Image>();
    }
}
