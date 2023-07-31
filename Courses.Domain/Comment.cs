﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Domain
{
    public class Comment
    {
        public DateTime Create { get; set; }
        [MaxLength(1000)]
        public string Text { get; set; } 
        public  virtual AppUser appUser { get; set; }
        public string Replay { get; set; }
        public int Rating { get; set; }

    }
}
