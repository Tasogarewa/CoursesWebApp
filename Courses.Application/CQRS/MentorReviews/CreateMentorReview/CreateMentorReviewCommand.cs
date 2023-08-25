using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.MentorReviews.CreateMentorReview
{
    public class CreateMentorReviewCommand:IRequest<Guid>
    {
        public int RatingOfReview { get; set; }
        public Guid MentorId { get; set; }
        public Guid UserId { get; set; }
        public virtual List<Image> Images { get; set; } = new List<Image>();
        public string Text { get; set; }
    }
}
