using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.WishedCourses.Commands.CreateWishedCourse
{
    public class CreateWishedCourseCommandHandler : IRequestHandler<CreateWishedCourseCommand, Guid>
    {
       private readonly IWishedCourseService _wishedCourseService;

        public CreateWishedCourseCommandHandler(IWishedCourseService wishedCourseService)
        {
            _wishedCourseService = wishedCourseService;
        }

        public async Task<Guid> Handle(CreateWishedCourseCommand request, CancellationToken cancellationToken)
        {
            return await _wishedCourseService.CreateWishedCourseAsync(request);
        }
    }
}
