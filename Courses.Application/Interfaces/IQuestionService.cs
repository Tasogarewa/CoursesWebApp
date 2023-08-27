
using MediatR;
using Tasogarewa.Application.CQRS.Questions.Commands.CreateQuestion;
using Tasogarewa.Application.CQRS.Questions.Commands.DeleteQuestion;
using Tasogarewa.Application.CQRS.Questions.Commands.UpdateQuestion;
using Tasogarewa.Application.CQRS.Questions.Queries.GetQuestion;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.Interfaces
{
    public interface IQuestionService
    {
        public Task<QuestionVm> GetQuestionAsync(GetQuestionQuery getQuestion);
        public Task<Guid> CreateQuestionAsync(CreateQuestionCommand createQuestion);
        public Task<Guid> UpdateQuestionAsync(UpdateQuestionCommand updateQuestion);
        public Task<Unit> DeleteQuestionAsync(DeleteQuestionCommand deleteQuestion);
    }
}
