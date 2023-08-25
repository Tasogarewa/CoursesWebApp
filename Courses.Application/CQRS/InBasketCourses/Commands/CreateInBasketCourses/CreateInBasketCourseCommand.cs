using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.InBasketCourses.Commands.CreateInBasketCourses
{
    public class CreateInBasketCourseCommand:IRequest<Guid>
    {
        public Guid BasketId { get; set; }
        public Guid CurseId { get; set; }
    }
}
