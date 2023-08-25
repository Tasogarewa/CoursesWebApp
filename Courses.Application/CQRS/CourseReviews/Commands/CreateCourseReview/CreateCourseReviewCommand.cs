using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.CourseReviews.Commands.CreateCourseReview
{
    public class CreateCourseReviewCommand:IRequest<Guid>
    {
        public Guid CourseId { get; set; }
        public Guid UserId { get; set; }
        public int RatingOfReview { get; set; }
        public virtual List<Image> Images { get; set; } = new List<Image>();
        public string Text { get; set; }
    }
}
