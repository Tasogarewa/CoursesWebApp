using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Mapping;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.Baskets.Queries.GetBasket
{
    public class BasketVm:IMapWith<Basket>
    {
      public List<InBasketCourse> Courses = new List<InBasketCourse>();
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Basket, BasketVm>()
                .ForMember(x => x.Courses, opt => opt.MapFrom(x => x.Courses));
        }
    }
}
