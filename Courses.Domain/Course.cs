using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Domain;

namespace Courses.Domain
{
    public enum Tags
    {
        FullStackDevelop,
        FrontEndDevelop,
        BackEndDevelop,
        QA,
        Python,
        Java,
        UIUX,
        HTML,
        CSS,
        JavaScript,
        React,
        Angular,
        Vue,
        Kotlin,
        Swift,
        ArtificialIntelligence,
        Sql,
        GameDevelop,
        DevOps,
        CSharp,
        CPlusPlus,
        C,
        Ruby,
        Scala,
        Go,
        Frameworks

    }

    public  class Course
    {
        public Guid Id { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public decimal Price { get; set; }
        public int Views { get; set; }
        [MinLength(4)]
        [MaxLength(30)]
        public string Name { get; set; }
        [MinLength(300)]
        [MaxLength(2000)]
        public string Description { get; set; }
        public string Goals { get; set; }
        public string Requierments { get; set; }
        public virtual CourseChat? Chat { get; set; } 
        public virtual ICollection<CourseTag> CourseTags { get; set; } = new List<CourseTag>();
        public virtual ICollection<Announcement>? Announcements { get; set; } = new List<Announcement>();
        public virtual ICollection<Section>? Sections { get; set; }=new List<Section>();
        public Guid MentorId { get; set; }
        public virtual Mentor Mentor { get; set; } 
        public virtual ICollection<CourseStudent>? CourseStudents { get; set; } = new List<CourseStudent>();
        public virtual ICollection<Image>? Images { get; set; } = new List<Image>();
        public int Rating { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; } = new List<Comment>();
        public bool IsChecked { get; set; } = false;
   
    }
}
