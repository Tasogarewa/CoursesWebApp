using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Questions.Commands.DeleteQuestion
{
    public class DeleteQuestionCommand:IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
