using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.MentorReviews.CreateMentorReview
{
    public class CreateMentorReviewCommandHandler : IRequestHandler<CreateMentorReviewCommand, Guid>
    {
        private readonly IRepository<Mentor> _mentorRepository;
        private readonly IRepository<Review> _reviewRepository;
        private readonly IRepository<AppUser> _userRepository;

        public CreateMentorReviewCommandHandler(IRepository<Mentor> mentorRepository, IRepository<Review> reviewRepository, IRepository<AppUser> userRepository)
        {
            _mentorRepository = mentorRepository;
            _reviewRepository = reviewRepository;
            _userRepository = userRepository;
        }

        public async Task<Guid> Handle(CreateMentorReviewCommand request, CancellationToken cancellationToken)
        {
            var mentor = await _mentorRepository.GetAsync(request.MentorId);
            var user = await _userRepository.GetAsync(request.UserId);
            var review = await _reviewRepository.Create(new Review() { CreateAt = DateTime.Now, User = user, Images = request.Images, RatingOfReview = request.RatingOfReview, Text = request.Text });
            mentor.Reviews.Add(review);
            await _mentorRepository.Update(mentor);
            return review.Id;
        }
    }
}
