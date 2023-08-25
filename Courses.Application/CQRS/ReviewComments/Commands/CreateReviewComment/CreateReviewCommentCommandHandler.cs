using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.ReviewComments.Commands.CreateReviewComment
{
    public class CreateReviewCommentCommandHandler : IRequestHandler<CreateReviewCommentCommand, Guid>
    {
        private readonly IRepository<Review> _reviewRepository;
        private readonly IRepository<Comment> _commentRepository;
        private readonly IRepository<AppUser> _userRepository;

        public CreateReviewCommentCommandHandler(IRepository<Review> reviewRepository, IRepository<Comment> commentRepository, IRepository<AppUser> userRepository)
        {
            _reviewRepository = reviewRepository;
            _commentRepository = commentRepository;
            _userRepository = userRepository;
        }

        public async Task<Guid> Handle(CreateReviewCommentCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(request.UserId);
            var review = await _reviewRepository.GetAsync(request.ReviewId);
            var comment = await _commentRepository.Create(new Comment() { CreateAt = DateTime.Now, Replay = request.Replay, Text = request.Text, User = user });
           review.Comments.Add(comment);
           await _reviewRepository.Update(review);
            return comment.Id;
        }
    }
}
