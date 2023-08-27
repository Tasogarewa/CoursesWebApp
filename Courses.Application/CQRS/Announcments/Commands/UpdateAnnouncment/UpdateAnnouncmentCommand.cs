using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Announcments.Commands.UpdateAnnouncments
{
    public class UpdateAnnouncmentCommand:IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public  List<Image> Images { get; set; }
        
    }
}
