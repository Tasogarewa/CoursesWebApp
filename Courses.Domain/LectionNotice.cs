using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Domain
{
    public  class LectionNotice
    {
        public Guid Id { get; set; }
        public virtual AppUser User { get; set; }
        public TimeSpan From { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public string Text { get; set; }
        public virtual Lection Lection { get; set; }
    }
}
