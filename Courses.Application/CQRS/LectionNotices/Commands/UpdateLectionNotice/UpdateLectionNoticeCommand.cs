using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.LectionNotices.Commands.UpdateLectionNotice
{
    public class UpdateLectionNoticeCommand:IRequest<Guid>
    {
        public Guid Id { get; set; }
        public TimeSpan From { get; set; }
        public string Text { get; set; }
    }
}
