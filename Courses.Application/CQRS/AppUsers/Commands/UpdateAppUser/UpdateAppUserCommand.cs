using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.AppUsers.Commands.UpdateAppUser
{
    public class UpdateAppUserCommand:IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public virtual Image? Image { get; set; }
        public string Email { get; set; }
    }
}
