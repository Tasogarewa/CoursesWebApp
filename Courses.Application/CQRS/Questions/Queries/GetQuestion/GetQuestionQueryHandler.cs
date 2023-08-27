using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.Questions.Queries.GetQuestion
{
    public class GetQuestionQueryHandler:IRequestHandler<GetQuestionQuery,QuestionVm>
    {
        private IQuestionService _questionService;

        public GetQuestionQueryHandler(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        public async Task<QuestionVm> Handle(GetQuestionQuery request, CancellationToken cancellationToken)
        {
            return await _questionService.GetQuestionAsync(request);
        }
    }
}
