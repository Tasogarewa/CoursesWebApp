using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.WishedCourses.Commands.DeleteWishedCourse
{
    public class DeleteWishedCourseCommandHandler : IRequestHandler<DeleteWishedCourseCommand, Unit>
    {
     private readonly IWishedCourseService _wishedCourseService;

        public DeleteWishedCourseCommandHandler(IWishedCourseService wishedCourseService)
        {
            _wishedCourseService = wishedCourseService;
        }

        public async Task<Unit> Handle(DeleteWishedCourseCommand request, CancellationToken cancellationToken)
        {
            return await _wishedCourseService.DeleteWishedCourseAsync(request);
        }
    }
}
