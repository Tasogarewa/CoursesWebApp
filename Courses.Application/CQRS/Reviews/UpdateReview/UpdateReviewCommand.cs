using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.Reviews.UpdateReview
{
    public class UpdateReviewCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public int RatingOfReview { get; set; }
        public virtual List<Image>? Images { get; set; } = new List<Image>();
        public string Text { get; set; }
    }
}
