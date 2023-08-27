using Azure.Core;
using Courses.Domain;
using MediatR;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.CQRS.AnnouncmentComments.Commands.CreateAnnouncmentComment;
using Tasogarewa.Application.CQRS.Comments.DeleteComment;
using Tasogarewa.Application.CQRS.Comments.UpdateComment;
using Tasogarewa.Application.CQRS.CourseComments.Commands.CreateCourseComment;
using Tasogarewa.Application.CQRS.MentorComments.Commands.CreateMentorComment;
using Tasogarewa.Application.CQRS.ReviewComments.Commands.CreateReviewComment;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Persistance.Services
{
    public class CommentService : ICommentService
    {
        private readonly IRepository<Comment> _commentRepository;
        private readonly IRepository<Mentor> _mentorRepository;
        private readonly IRepository<Announcement> _announcmentRepository;
        private readonly IRepository<Course> _courseRepository;
        private readonly IRepository<Review> _reviewRepository;
        private readonly IRepository<AppUser> _userRepository;

        public CommentService(IRepository<Comment> commentRepository, IRepository<Mentor> mentorRepository, IRepository<Announcement> announcmentRepository, IRepository<Course> courseRepository, IRepository<Review> reviewRepository, IRepository<AppUser> userRepository)
        {
            _commentRepository = commentRepository;
            _mentorRepository = mentorRepository;
            _announcmentRepository = announcmentRepository;
            _courseRepository = courseRepository;
            _reviewRepository = reviewRepository;
            _userRepository = userRepository;
        }

        public async Task<Guid> CreateAnnouncmentCommentAsync(CreateAnnouncmentCommentCommand createAnnouncmentComment)
        {
            var annoucment = await _announcmentRepository.GetAsync(createAnnouncmentComment.AnnouncmentId);
            var user = await _userRepository.GetAsync(createAnnouncmentComment.UserId);
            NotFoundException<Announcement>.Throw(annoucment, createAnnouncmentComment.AnnouncmentId);
            NotFoundException<AppUser>.Throw(user, createAnnouncmentComment.UserId);
            var comment = await _commentRepository.CreateAsync(new Comment() { CreateAt = DateTime.Now, Replay = createAnnouncmentComment.Replay, Text = createAnnouncmentComment.Text, User = user });
            annoucment.Comments.Add(comment);
            await _announcmentRepository.UpdateAsync(annoucment);
            return comment.Id;
        }

        public async Task<Guid> CreateCourseCommentAsync(CreateCourseCommentCommand createCourseComment)
        {
            var course = await _courseRepository.GetAsync(createCourseComment.CourseId);
            var user = await _userRepository.GetAsync(createCourseComment.UserId);
            NotFoundException<AppUser>.Throw(user, createCourseComment.UserId);
            NotFoundException<Course>.Throw(course, createCourseComment.CourseId);
            var comment = await _commentRepository.CreateAsync(new Comment() { CreateAt = DateTime.Now, Rating = 0, Replay = createCourseComment.Replay, Text = createCourseComment.Text, User = user});
            course.Comments.Add(comment);
            await _courseRepository.UpdateAsync(course);
            return comment.Id;
        }

        public async Task<Guid> CreateMentorCommentAsync(CreateMentorCommentCommand createMentorComment)
        {
            var mentor = await _mentorRepository.GetAsync(createMentorComment.MentorId);
            var user = await _userRepository.GetAsync(createMentorComment.UserId);
            NotFoundException<AppUser>.Throw(user, createMentorComment.UserId);
            NotFoundException<Mentor>.Throw(mentor, createMentorComment.MentorId); 
            var comment = await _commentRepository.CreateAsync(new Comment() { CreateAt = DateTime.Now, Replay = createMentorComment.Replay, Text = createMentorComment.Text, User = user });
            mentor.Comments.Add(comment);
           await _mentorRepository.UpdateAsync(mentor);
            return comment.Id;
        }

        public async Task<Guid> CreateReviewCommentAsync(CreateReviewCommentCommand createReviewComment)
        {
            var review = await _reviewRepository.GetAsync(createReviewComment.ReviewId);
            var user = await _userRepository.GetAsync(createReviewComment.UserId);
            NotFoundException<AppUser>.Throw(user, createReviewComment.UserId);
            NotFoundException<Review>.Throw(review, createReviewComment.ReviewId);
            var comment = await _commentRepository.CreateAsync(new Comment() { CreateAt = DateTime.Now, Replay = createReviewComment.Replay, Text = createReviewComment.Text, User = user });
            review.Comments.Add(comment);
            await _reviewRepository.UpdateAsync(review);
            return comment.Id;
        }

        public async Task<Unit> DeleteCommentAsync(DeleteCommentCommand deleteCommentCommand)
        {
            var comment = await _commentRepository.GetAsync(deleteCommentCommand.Id);
            NotFoundException<Comment>.Throw(comment, deleteCommentCommand.Id);
            await _commentRepository.DeleteAsync(comment);
            return Unit.Value;
        }

        public async Task<Guid> UpdateCommentAsync(UpdateCommentCommand updateCommentCommand)
        {
            var comment = await _commentRepository.GetAsync(updateCommentCommand.Id);
            NotFoundException<Comment>.Throw(comment, updateCommentCommand.Id);
            comment.UpdateAt = DateTime.Now;
            comment.Text = updateCommentCommand.Text;
            comment.Replay = updateCommentCommand.Replay;
            await _commentRepository.UpdateAsync(comment);
            return comment.Id;
        }
    }
}
