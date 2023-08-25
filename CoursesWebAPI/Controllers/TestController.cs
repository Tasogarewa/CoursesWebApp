using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tasogarewa.Application.CQRS.Tests.Commands.CreateTest;
using Tasogarewa.Application.CQRS.Tests.Commands.DeleteTest;
using Tasogarewa.Application.CQRS.Tests.Commands.UpdateTest;
using Tasogarewa.Application.CQRS.Tests.Queries.GetTest;

namespace CoursesWebAPI.Controllers
{
    public class TestController:BaseController
    {
        [HttpGet]
        public async Task<ActionResult<TestVm>> Get(Guid testId)
        {
            var query = new GetTestQuery
            {
               Id = testId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateTestCommand createTestCommand)
        {
            var testId = await Mediator.Send(createTestCommand);
            return Ok(testId);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {
            var command = new DeleteTestCommand
            {
                Id = id

            };
            await Mediator.Send(command);
            return NoContent();
        }
        [HttpPut]
        public async Task<ActionResult<Guid>> Update([FromBody] UpdateTestCommand updateTestCommand)
        {
            await Mediator.Send(updateTestCommand);
            return NoContent();
        }
    }
}
