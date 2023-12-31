﻿using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.UserArchivedCourse.Commands.CreateArchivedCourse
{
    public class CreateArchivedCourseCommand:IRequest<Guid>
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
      
    }
}
