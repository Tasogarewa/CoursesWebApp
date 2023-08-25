using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.CourseReviews.Commands.CreateCourseReview
{
    public class CreateCourseReviewCommandHandler:IRequestHandler<CreateCourseReviewCommand,Guid>
    {
        private readonly IRepository<AppUser> _userRepository;
        private readonly IRepository<Course> _courseRepository;
        private readonly IRepository<Review> _reviewRepository;
        private readonly IRepository<CourseStudent> _courseStudentRepository;

        public CreateCourseReviewCommandHandler(IRepository<AppUser> userRepository, IRepository<Course> courseRepository, IRepository<Review> reviewRepository, IRepository<CourseStudent> courseStudentRepository)
        {
            _userRepository = userRepository;
            _courseRepository = courseRepository;
            _reviewRepository = reviewRepository;
            _courseStudentRepository = courseStudentRepository;
        }

        public async Task<Guid> Handle(CreateCourseReviewCommand request, CancellationToken cancellationToken)
        {
           var user = await _userRepository.GetAsync(request.UserId);
            var course = await _courseRepository.GetAsync(request.CourseId);
            var courseStudent =  _courseStudentRepository.GetAllAsync().Result.FirstOrDefault(x => x.CourseId == course.Id && x.UserId == user.Id);
            var review = await _reviewRepository.Create(new Review() { User=user, CreateAt = DateTime.Now, Images = request.Images, RatingOfReview = request.RatingOfReview, Text = request.Text });
            courseStudent.Review = review;
          await _courseStudentRepository.Update(courseStudent);
            return review.Id;
        }

    }
}
