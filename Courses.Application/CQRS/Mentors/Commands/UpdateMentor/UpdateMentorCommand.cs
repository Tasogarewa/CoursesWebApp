using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.Mentors.Commands.UpdateMentor
{
    public class UpdateMentorCommand:IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Description { get; set; }
        public virtual Image Image { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public string? Web { get; set; }
        public string? YouTube { get; set; }
        public string? Twitter { get; set; }
        public string? Facebook { get; set; }
        public string? Instagram { get; set; }
        public string? GitHub { get; set; }
    }
}
