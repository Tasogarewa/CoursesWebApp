using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Domain
{
    public class Mail
    {
        public Guid Id { get; set; }
        public string Header { get; set; }
        public DateTime Sended { get; set; }
        public string Description { get; set; }
        public virtual AppUser MailTo { get; set; }
        public string MailFrom { get; } = "Tasogarewa@gmail.com";
        
    }
}
