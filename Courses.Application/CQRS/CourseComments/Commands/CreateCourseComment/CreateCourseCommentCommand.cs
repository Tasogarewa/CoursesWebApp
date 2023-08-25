using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.CourseComments.Commands.CreateCourseComment
{
    public class CreateCourseCommentCommand:IRequest<Guid>
    {
  
        public string Text { get; set; }
      public Guid UserId { get; set; }
        public Guid CourseId { get; set; }
        public string Replay { get; set; }
    }
}
