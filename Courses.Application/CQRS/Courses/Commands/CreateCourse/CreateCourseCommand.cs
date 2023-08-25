using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.Courses.Commands.CreateCourse
{
    public class CreateCourseCommand:IRequest<Guid>
    {

        public string Name { get; set; }
        public  List<CourseTag> CourseTags { get; set; } = new List<CourseTag>();
        public Guid MentorId { get; set; }
    }
}
