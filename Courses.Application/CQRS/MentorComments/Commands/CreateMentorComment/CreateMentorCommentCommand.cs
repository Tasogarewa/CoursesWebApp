using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.MentorComments.Commands.CreateMentorComment
{
    public class CreateMentorCommentCommand:IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public Guid MentorId { get; set; }
        public string Text { get; set; }
        public string Replay { get; set; }
    }
}
