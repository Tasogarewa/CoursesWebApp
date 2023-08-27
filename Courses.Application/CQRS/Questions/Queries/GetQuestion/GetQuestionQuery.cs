using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Questions.Queries.GetQuestion
{
    public class GetQuestionQuery:IRequest<QuestionVm>
    {
        public Guid Id { get; set; }
    }
}
