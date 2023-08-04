using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Courses.Commands.UpdateCourse
{
    public class UpdateCourseCommand:IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public DateTime Expires { get; set; }
        [MinLength(4)]
        [MaxLength(30)]
        public string Name { get; set; }
        [MinLength(300)]
        [MaxLength(2000)]
        public string Description { get; set; }
        public string FilePath { get; set; }
        public  ICollection<Image> Images { get; set; } = new List<Image>();
      
    }
}
