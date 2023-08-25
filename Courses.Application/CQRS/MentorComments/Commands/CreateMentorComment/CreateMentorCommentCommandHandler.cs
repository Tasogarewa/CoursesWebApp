using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.MentorComments.Commands.CreateMentorComment
{
    public class CreateMentorCommentCommandHandler : IRequestHandler<CreateMentorCommentCommand, Guid>
    {
        private readonly IRepository<Mentor> _mentorRepository;
        private readonly IRepository<Comment> _commentRepository;
        private readonly IRepository<AppUser> _userRepository;

        public CreateMentorCommentCommandHandler(IRepository<Mentor> mentorRepository, IRepository<Comment> commentRepository, IRepository<AppUser> userRepository)
        {
            _mentorRepository = mentorRepository;
            _commentRepository = commentRepository;
            _userRepository = userRepository;
        }

        public async Task<Guid> Handle(CreateMentorCommentCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(request.UserId);
            var mentor = await _mentorRepository.GetAsync(request.MentorId);
            var comment = await _commentRepository.Create(new Comment() { CreateAt = DateTime.Now, Replay = request.Replay, Text = request.Text, User = user });
            mentor.Comments.Add(comment);
            await _mentorRepository.Update(mentor);
            return comment.Id;
        }
    }
}
