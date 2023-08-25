using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.UserCourseChats.Queries.GetUserCourseChats
{
    public class UserCourseChatListVm
    {
        public List<UserCourseChatDto> courseChatDtos { get; set; }
    }
}
