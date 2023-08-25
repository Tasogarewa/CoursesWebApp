using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.Tests.Commands.CreateTest
{
    public class CreateTestCommand:IRequest<Guid>
    {
        public string Name { get; set; }
        public Guid LectionId { get; set; }
        public string Description { get; set; }
        public virtual List<Question> Questions { get; set; } = new List<Question>();
    }
}
