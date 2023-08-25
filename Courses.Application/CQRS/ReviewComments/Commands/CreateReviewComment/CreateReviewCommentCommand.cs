using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.ReviewComments.Commands.CreateReviewComment
{
    public class CreateReviewCommentCommand:IRequest<Guid>
    {
        public string Text { get; set; }
        public Guid ReviewId { get; set; }
        public Guid UserId { get; set; }
        public string Replay { get; set; }
    }
}
