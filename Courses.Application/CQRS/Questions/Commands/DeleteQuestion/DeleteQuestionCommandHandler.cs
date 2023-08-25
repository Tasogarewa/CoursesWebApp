using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.Questions.Commands.DeleteQuestion
{
    public class DeleteQuestionCommandHandler : IRequestHandler<DeleteQuestionCommand, Unit>
    {
        private readonly IRepository<Question> _questionRepository;

        public DeleteQuestionCommandHandler(IRepository<Question> questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<Unit> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
        {
            var question = await _questionRepository.GetAsync(request.Id);
            if(question == null||request.Id==Guid.Empty)
            {
                throw new NotFoundException(nameof(question), request.Id);
            }
            else
               await _questionRepository.Delete(question);
            return Unit.Value;
        }
    }
}
