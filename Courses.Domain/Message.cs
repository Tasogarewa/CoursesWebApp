﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Domain;

namespace Courses.Domain
{
    public class Message
    {
        public Guid Id { get; set; }
        public virtual AppUser User { get; set; }
        public DateTime SendedAt { get; set; }
        public DateTime UpdateAt { get; set; }
        [MaxLength(1000)]
        public string Text { get; set; }
        public string? Replay { get; set; }
        public virtual Chat Chat { get; set; }
        public virtual ICollection<Image> Images { get; set; } = new List<Image>();

    }
}
