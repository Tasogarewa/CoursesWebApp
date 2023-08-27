using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.InListCourses.Commands.CreateInListCourses
{
    public class CreateInListCourseCommandHandler : IRequestHandler<CreateInListCourseCommand, Guid>
    {
    private readonly IListCourseService _listCourseService;

        public CreateInListCourseCommandHandler(IListCourseService listCourseService)
        {
            _listCourseService = listCourseService;
        }

        public async Task<Guid> Handle(CreateInListCourseCommand request, CancellationToken cancellationToken)
        {
            return await _listCourseService.CreateInListCourseAsync(request);
        }
    }
}
