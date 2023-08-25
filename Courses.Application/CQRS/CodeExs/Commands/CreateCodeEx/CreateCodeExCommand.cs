using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.CodeExs.Commands.CreateCodeEx
{
    public class CreateCodeExCommand:IRequest<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Hint { get; set; }
        public  Guid LectionId { get; set; }
        public string Solution { get; set; }
        public  List<Image>? Images { get; set; } = new List<Image>();
    }
}
