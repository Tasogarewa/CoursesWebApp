﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.CQRS.Comments.Queries.GetComments;

namespace Tasogarewa.Application.CQRS.Courses.Queries.GetCourses
{
    public class CourseListVm
    {
        public List<CourseDto> CoursesList { get; set; }
    }
}
