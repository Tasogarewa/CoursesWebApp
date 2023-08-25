using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.Courses.Commands.UpdateCourse
{
    public class UpdateCourseCommand:IRequest<Guid>
    {
        public Guid Id { get; set; }

        public decimal Price { get; set; }

        public string Name { get; set; }
  
        public string Description { get; set; }
        public string Goals { get; set; }
        public string Requierments { get; set; }

        public  List<Section> Sections { get; set; } = new List<Section>();
        public  List<Image> Images { get; set; } = new List<Image>();

    }
}
