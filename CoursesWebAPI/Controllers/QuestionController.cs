﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tasogarewa.Application.CQRS.Notifications.Queries.GetNotifications;
using Tasogarewa.Application.CQRS.Questions.Commands.CreateQuestion;
using Tasogarewa.Application.CQRS.Questions.Commands.DeleteQuestion;
using Tasogarewa.Application.CQRS.Questions.Commands.UpdateQuestion;
using Tasogarewa.Application.CQRS.Questions.Queries.GetQuestion;

namespace CoursesWebAPI.Controllers
{
    public class QuestionController:BaseController
    {
        [HttpGet]
        public async Task<ActionResult<QuestionVm>> GetAll(Guid questionId)
        {
            var query = new GetQuestionQuery
            {
                Id = questionId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateQuestionCommand  createQuestionCommand)
        {
            var questionId = await Mediator.Send(createQuestionCommand);
            return Ok(questionId);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {
            var command = new DeleteQuestionCommand
            {
                Id = id

            };
            await Mediator.Send(command);
            return NoContent();
        }
        [HttpPut]
        public async Task<ActionResult<Guid>> Update([FromBody] UpdateQuestionCommand updateQuestionCommand)
        {
            await Mediator.Send(updateQuestionCommand);
            return NoContent();
        }
    }
}
