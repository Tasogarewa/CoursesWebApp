using Azure.Core;
using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.CQRS.CourseReviews.Commands.CreateCourseReview;
using Tasogarewa.Application.CQRS.Courses.Queries.GetCourse;
using Tasogarewa.Application.CQRS.MentorReviews.CreateMentorReview;
using Tasogarewa.Application.CQRS.Reviews.DeleteReview;
using Tasogarewa.Application.CQRS.Reviews.UpdateReview;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Persistance.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IRepository<Mentor> _mentorRepository;
        private readonly IRepository<Course> _courseRepository;
        private readonly IRepository<Review> _reviewRepository;
        private readonly IRepository<AppUser> _userRepository;


        public ReviewService(IRepository<Mentor> mentorRepository, IRepository<Course> courseRepository, IRepository<Review> reviewRepository, IRepository<AppUser> userRepository)
        {
            _mentorRepository = mentorRepository;
            _courseRepository = courseRepository;
            _reviewRepository = reviewRepository;
            _userRepository = userRepository;
        }

        public async Task<Guid> CreateCourseReviewAsync(CreateCourseReviewCommand createCourseReview)
        {
            var user = await _userRepository.GetAsync(createCourseReview.UserId);
            var course = await _courseRepository.GetAsync(createCourseReview.CourseId);
            NotFoundException<AppUser>.Throw(user, createCourseReview.UserId);
            NotFoundException<Course>.Throw(course, createCourseReview.CourseId);
            var review = await _reviewRepository.CreateAsync(new Review() { User = user, CreateAt = DateTime.Now, Images = createCourseReview.Images, RatingOfReview = createCourseReview.RatingOfReview, Text = createCourseReview.Text });
            user.Courses.FirstOrDefault(x => x.Course == course).Review = review;
            await _userRepository.UpdateAsync(user);
            return review.Id;
        }

        public async Task<Guid> CreateMentorReviewsAsync(CreateMentorReviewCommand createMentorReview)
        {
            var mentor = await _mentorRepository.GetAsync(createMentorReview.MentorId);
            var user = await _userRepository.GetAsync(createMentorReview.UserId);
            NotFoundException<AppUser>.Throw(user, createMentorReview.UserId);
            NotFoundException<Mentor>.Throw(mentor, createMentorReview.MentorId);
            var review = await _reviewRepository.CreateAsync(new Review() { CreateAt = DateTime.Now, User = user, Images = createMentorReview.Images, RatingOfReview = createMentorReview.RatingOfReview, Text = createMentorReview.Text });
            mentor.Reviews.Add(review);
            await _mentorRepository.UpdateAsync(mentor);
            return review.Id;
        }
        public async Task<Unit> DeleteReviewAsync(DeleteReviewCommand deleteReview)
        {
            var review = await _reviewRepository.GetAsync(deleteReview.Id);
            NotFoundException<Review>.Throw(review, deleteReview.Id);
            await _reviewRepository.DeleteAsync(review);
            return Unit.Value;
        }
        public async Task<Guid> UpdateReviewAsync(UpdateReviewCommand updateReview)
        {
            var review = await _reviewRepository.GetAsync(updateReview.Id);
            NotFoundException<Review>.Throw(review, updateReview.Id);
            review.UpdateAt = DateTime.Now;
            review.RatingOfReview = updateReview.RatingOfReview;
            review.Images = updateReview.Images;
            review.Text = updateReview.Text;
            await _reviewRepository.UpdateAsync(review);
            return review.Id;
        }
    }
}
