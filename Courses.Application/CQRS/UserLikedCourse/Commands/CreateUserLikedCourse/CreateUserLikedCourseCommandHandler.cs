using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.UserLikedCourse.Commands.CreateUserLikedCourse
{
    public class CreateUserLikedCourseCommandHandler : IRequestHandler<CreateUserLikedCourseCommand, Guid>
    {
        private readonly ILikedCourseService _likedCourseService;

        public CreateUserLikedCourseCommandHandler(ILikedCourseService likedCourseService)
        {
            _likedCourseService = likedCourseService;
        }

        public async Task<Guid> Handle(CreateUserLikedCourseCommand request, CancellationToken cancellationToken)
        {
             return await _likedCourseService.CreateLikedCourseAsync(request); 
        }
    }
}
