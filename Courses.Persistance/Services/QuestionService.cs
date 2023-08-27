using AutoMapper;
using Azure.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.CQRS.Questions.Commands.CreateQuestion;
using Tasogarewa.Application.CQRS.Questions.Commands.DeleteQuestion;
using Tasogarewa.Application.CQRS.Questions.Commands.UpdateQuestion;
using Tasogarewa.Application.CQRS.Questions.Queries.GetQuestion;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Persistance.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IRepository<Question> _questionRepository;
        private readonly IRepository<Test> _testRepository;
        private readonly IMapper _mapper;

        public QuestionService(IRepository<Question> questionRepository, IRepository<Test> testRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _testRepository = testRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateQuestionAsync(CreateQuestionCommand createQuestion)
        {
            var test = await _testRepository.GetAsync(createQuestion.TestId);
            NotFoundException<Test>.Throw(test, createQuestion.TestId);
            var question = await _questionRepository.CreateAsync(new Question() { CorrectAnswer = createQuestion.CorrectAnswer, FirstAnswer = createQuestion.FirstAnswer, SecondAnswer = createQuestion.SecondAnswer, ThirdAnswer = createQuestion.ThirdAnswer, FourthAnswer = createQuestion.FourthAnswer, Name = createQuestion.Name, Test = test });
            return question.Id;
        }
        public async Task<Unit> DeleteQuestionAsync(DeleteQuestionCommand deleteQuestion)
        {
            var question = await _questionRepository.GetAsync(deleteQuestion.Id);
            NotFoundException<Question>.Throw(question, deleteQuestion.Id);
            await _questionRepository.DeleteAsync(question);
            return Unit.Value;
        }
        public async Task<QuestionVm> GetQuestionAsync(GetQuestionQuery getQuestion)
        {
            var question = await _questionRepository.GetAsync(getQuestion.Id);
            NotFoundException<Question>.Throw(question, getQuestion.Id);
            return _mapper.Map<QuestionVm>(question);
        }
        public async Task<Guid> UpdateQuestionAsync(UpdateQuestionCommand updateQuestion)
        {
            var question = await _questionRepository.GetAsync(updateQuestion.Id);
            NotFoundException<Question>.Throw(question, updateQuestion.Id);
            question.FourthAnswer = updateQuestion.FourthAnswer;
            question.ThirdAnswer = updateQuestion.ThirdAnswer;
            question.FirstAnswer = updateQuestion.FirstAnswer;
            question.SecondAnswer = updateQuestion.SecondAnswer;
            question.Name = updateQuestion.Name;
            question.CorrectAnswer = updateQuestion.CorrectAnswer;
            await _questionRepository.UpdateAsync(question);
            return question.Id;
        }
    }
}
