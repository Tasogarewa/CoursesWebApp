using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.CQRS.Courses.Queries.GetCourses;

namespace Tasogarewa.Application.CQRS.Messages.Queries.GetMessages
{
    public class MessagesListVm
    {
        public List<MessagesDto> MessagesList { get; set; }
    }
}
