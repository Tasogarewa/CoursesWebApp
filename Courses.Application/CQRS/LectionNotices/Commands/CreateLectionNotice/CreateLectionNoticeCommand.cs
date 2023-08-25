using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.LectionNotices.Commands.CreateLectionNotice
{
    public class CreateLectionNoticeCommand:IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public TimeSpan From { get; set; }
        public string Text { get; set; }
        public Guid LectionId { get; set; }
    }
}
