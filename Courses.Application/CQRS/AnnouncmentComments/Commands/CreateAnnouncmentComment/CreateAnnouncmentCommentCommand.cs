using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.AnnouncmentComments.Commands.CreateAnnouncmentComment
{
    public class CreateAnnouncmentCommentCommand:IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public Guid AnnouncmentId { get; set; }
        public string Text { get; set; }
        public string Replay { get; set; }
    }
}
