using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Domain
{
    public class Lection
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
        public virtual Test? Tests { get; set; }
        public virtual CodeEx? CodeEx { get; set; }
        public virtual Section? Section { get; set; }
        public virtual ICollection<LectionNotice>? LectionNotices { get; set; }  
    }
}
