﻿using Courses.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Domain
{
    public class Notification
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public DateTime Create { get; set; }
        public virtual Image Image { get;set;}
        public virtual AppUser appUser { get; set; }
    }
}
