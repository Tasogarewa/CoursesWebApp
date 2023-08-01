using AutoMapper;
using Courses.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Mapping;

namespace Tasogarewa.Application.CQRS.Images.Queries.GetImage
{
    public class ImageVm:IMapWith<Image>
    {
        public Guid Id { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Image, ImageVm>().ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id));
        }
    }
}
