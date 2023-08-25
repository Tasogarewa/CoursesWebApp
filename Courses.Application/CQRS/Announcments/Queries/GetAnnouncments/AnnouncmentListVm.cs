using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Announcments.Queries.GetAnnouncments
{
    public class AnnouncmentListVm
    {
        public List<AnnouncmentDto> AnnouncmentDtos { get; set; }
    }
}
