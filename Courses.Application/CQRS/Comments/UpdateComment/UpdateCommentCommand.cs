using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.Comments.UpdateComment
{
    public class UpdateCommentCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public string? Replay { get; set; }
    }
}
