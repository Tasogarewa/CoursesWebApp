using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.CQRS.Courses.Queries.GetCourses;

namespace Tasogarewa.Application.CQRS.Images.Queries.GetImages
{
    public class ImageListVm
    {
        public List<ImageDto> ImagesList { get; set; }
    }
}
