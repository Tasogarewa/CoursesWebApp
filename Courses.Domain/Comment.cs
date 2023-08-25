using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Domain;

namespace Courses.Domain
{
    public class Comment
    {
        public Guid Id { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        [MaxLength(1000)]
        public string Text { get; set; } 
        public  virtual AppUser User { get; set; }
        public string Replay { get; set; }
        public int Rating { get; set; }

    }
}
