using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.Questions.Commands.UpdateQuestion
{
    public class UpdateQuestionCommandHandler : IRequestHandler<UpdateQuestionCommand, Guid>
    {
        private readonly IRepository<Question> _questionRepository;

        public UpdateQuestionCommandHandler(IRepository<Question> questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<Guid> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
        {
            var question = await _questionRepository.GetAsync(request.Id);
            if (question == null||request.Id==Guid.Empty) 
            {
                throw new NotFoundException(nameof(question), request.Id);
            }
            else
            {
                question.FourthAnswer = request.FourthAnswer;
                question.ThirdAnswer =request.ThirdAnswer;
                question.FirstAnswer = request.FirstAnswer;
                question.SecondAnswer = request.SecondAnswer;
                question.Name = request.Name;
                question.CorrectAnswer= request.CorrectAnswer;
                await _questionRepository.Update(question);
                return question.Id;
            }
        }
    }
}
