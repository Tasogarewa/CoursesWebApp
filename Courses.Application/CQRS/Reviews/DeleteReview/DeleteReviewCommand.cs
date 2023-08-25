﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Reviews.DeleteReview
{
    public class DeleteReviewCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
