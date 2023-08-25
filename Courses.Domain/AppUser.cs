using Courses.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Domain
{
    public class AppUser
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public virtual Image? Image { get; set; } 
        public Guid MentorId { get; set; }
        public virtual Mentor Mentor { get; set; }
        public virtual ICollection<Notification>? Notifications { get; set; } = new List<Notification>();
        public virtual ICollection<CourseStudent>? Courses { get; set; }  = new List<CourseStudent>();
        public virtual UserNamedCourseList? UserNamedCourseList { get; set; } 
        public virtual ICollection<Chat>? Chats { get; set; } = new List<Chat>();
        public virtual ICollection<CourseChat>? CourseChats { get; set; } = new List<CourseChat>();
        public virtual ArchivedCourses ArchivedCourse { get; set; } 
        public virtual LikedCourses LikedCourses { get; set; }  
        public virtual UserWishList UserWishList { get; set; }
        public string Email { get; set; }
      public virtual Basket Basket { get; set; } 
       
    }
}
