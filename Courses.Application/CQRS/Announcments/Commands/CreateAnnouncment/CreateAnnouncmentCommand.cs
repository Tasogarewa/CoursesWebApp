using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Announcments.Commands.CreateAnnouncments
{
    public class CreateAnnouncmentCommand:IRequest<Guid>
    {
        public Guid MentorId { get; set; }
        public Guid CourseId { get; set; }
        public List<Image> Images { get; set; }
        public string Text { get; set; }
        
    }
}
