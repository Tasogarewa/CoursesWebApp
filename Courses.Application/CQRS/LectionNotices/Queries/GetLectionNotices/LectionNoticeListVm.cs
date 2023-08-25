using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.LectionNotices.Queries.GetLectionNotices
{
    public class LectionNoticeListVm
    {
        public List<LectionNoticeDto> lectionNoticeDtos { get; set; }
    }
}
