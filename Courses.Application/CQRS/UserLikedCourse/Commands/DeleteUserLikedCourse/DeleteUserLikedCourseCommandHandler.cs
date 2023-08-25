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
        private readonly IRepository<LikedCourse> _likedCourse;

        public DeleteUserLikedCourseCommandHandler(IRepository<LikedCourse> likedCourse)
        {
            _likedCourse = likedCourse;
        }

        public async Task<Unit> Handle(DeleteUserLikedCourseCommand request, CancellationToken cancellationToken)
        {
            var likedCourse = await _likedCourse.GetAsync(request.Id);
            if (likedCourse == null||request.Id==Guid.Empty)
            {
                throw new NotFoundException(nameof(likedCourse), request.Id);
            }
            else
            {
                await _likedCourse.Delete(likedCourse);
            }
            return Unit.Value;
        }
    }
}
