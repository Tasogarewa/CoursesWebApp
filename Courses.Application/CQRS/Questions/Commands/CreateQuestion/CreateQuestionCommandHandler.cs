using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.Questions.Commands.CreateQuestion
{
    public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, Guid>
    {
        private readonly IRepository<Test> _testRepository;
        private readonly IRepository<Question> _questionRepository;

        public CreateQuestionCommandHandler(IRepository<Test> testRepository, IRepository<Question> questionRepository)
        {
            _testRepository = testRepository;
            _questionRepository = questionRepository;
        }

        public async Task<Guid> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
        {
            var test = await _testRepository.GetAsync(request.TestId);
            var question = await _questionRepository.Create(new Question() { CorrectAnswer = request.CorrectAnswer, FirstAnswer = request.FirstAnswer, SecondAnswer = request.SecondAnswer, ThirdAnswer = request.ThirdAnswer, FourthAnswer = request.FourthAnswer, Name = request.Name, Test = test });
            return question.Id;
        }
    }
}
