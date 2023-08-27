using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.UserArchivedCourses.Queries.GetArchivedCourses
{
    public class GetArchivedCoursesQuery:IRequest<ArchivedCourseVm>
    {
        public Guid UserId { get; set; }
    }
}
