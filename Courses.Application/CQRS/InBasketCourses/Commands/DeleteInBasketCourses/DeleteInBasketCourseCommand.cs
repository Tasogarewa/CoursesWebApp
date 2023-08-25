using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.InBasketCourses.Commands.DeleteInBasketCourses
{
    public class DeleteInBasketCourseCommand:IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
