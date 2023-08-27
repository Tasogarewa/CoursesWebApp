using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Mapping;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.Questions.Queries.GetQuestion
{
    public class QuestionVm:IMapWith<Question>
    {
        public string Name { get; set; }
        public string FirstAnswer { get; set; }
        public string SecondAnswer { get; set; }
        public string ThirdAnswer { get; set; }
        public string FourthAnswer { get; set; }
        public virtual Test Test { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Question, QuestionVm>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                 .ForMember(x => x.FirstAnswer, opt => opt.MapFrom(x => x.FirstAnswer))
                  .ForMember(x => x.SecondAnswer, opt => opt.MapFrom(x => x.SecondAnswer))
                   .ForMember(x => x.ThirdAnswer, opt => opt.MapFrom(x => x.ThirdAnswer))
                    .ForMember(x => x.FourthAnswer, opt => opt.MapFrom(x => x.FourthAnswer))
                    .ForMember(x => x.Test, opt => opt.MapFrom(x => x.Test));
        }
    }
}
