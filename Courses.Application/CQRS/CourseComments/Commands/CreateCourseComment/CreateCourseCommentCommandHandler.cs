using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.CourseComments.Commands.CreateCourseComment
{
    public class CreateCourseCommentCommandHandler : IRequestHandler<CreateCourseCommentCommand, Guid>
    {
        private readonly IRepository<Comment> _commentRepository;
        private readonly IRepository<Course> _courseRepository;
        private readonly IRepository<AppUser> _userRepository;

        public CreateCourseCommentCommandHandler(IRepository<Comment> commentRepository, IRepository<Course> courseRepository, IRepository<AppUser> userRepository)
        {
            _commentRepository = commentRepository;
            _courseRepository = courseRepository;
            _userRepository = userRepository;
        }

        public async Task<Guid> Handle(CreateCourseCommentCommand request, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.GetAsync(request.CourseId);
            var comment = await _commentRepository.Create(new Comment() { CreateAt = DateTime.Now, Rating = 0, Replay = request.Replay, Text = request.Text, User = await _userRepository.GetAsync(request.UserId) });
             course.Comments.Add(comment);
            await _courseRepository.Update(course);
            return comment.Id;        
        }

    }
}
