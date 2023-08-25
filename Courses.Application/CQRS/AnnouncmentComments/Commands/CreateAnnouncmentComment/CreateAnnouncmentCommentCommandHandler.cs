using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.AnnouncmentComments.Commands.CreateAnnouncmentComment
{
    public class CreateAnnouncmentCommentCommandHandler:IRequestHandler<CreateAnnouncmentCommentCommand,Guid>
    {
        private readonly IRepository<Announcement> _announcmentRepository;
        private readonly IRepository<Comment> _commentRepository;
        private readonly IRepository<AppUser> _userRepository;

        public CreateAnnouncmentCommentCommandHandler(IRepository<Announcement> announcmentRepository, IRepository<Comment> commentRepository, IRepository<AppUser> userRepository)
        {
            _announcmentRepository = announcmentRepository;
            _commentRepository = commentRepository;
            _userRepository = userRepository;
        }

        public async Task<Guid> Handle(CreateAnnouncmentCommentCommand request, CancellationToken cancellationToken)
        {
            var announcment = await _announcmentRepository.GetAsync(request.AnnouncmentId);
            var user = await _userRepository.GetAsync(request.UserId);
            var comment = await _commentRepository.Create(new Comment() { CreateAt = DateTime.Now, Replay = request.Replay, Text = request.Text, User = user });
            announcment.Comments.Add(comment);
            await _announcmentRepository.Update(announcment);
            return announcment.Id;
        }
    }
}
