using AutoMapper;
using Courses.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Mapping;

namespace Tasogarewa.Application.CQRS.Images.Queries.GetImages
{
    public class ImageDto:IMapWith<Image>
    {
        public Guid Id { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Image, ImageDto>().ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id));
        }
    }
}
