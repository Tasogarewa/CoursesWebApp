using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.UserLikedCourse.Commands.DeleteUserLikedCourse
{
    public class DeleteUserLikedCourseCommandHandler : IRequestHandler<DeleteUserLikedCourseCommand, Unit>
    {
        private readonly ILikedCourseService _likedCourseService;

        public DeleteUserLikedCourseCommandHandler(ILikedCourseService likedCourseService)
        {
            _likedCourseService = likedCourseService;
        }

        public async Task<Unit> Handle(DeleteUserLikedCourseCommand request, CancellationToken cancellationToken)
        {
            return await _likedCourseService.DeleteLikedCourseAsync(request);
        }
    }
}
