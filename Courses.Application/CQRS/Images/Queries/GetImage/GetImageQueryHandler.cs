using AutoMapper;
using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.CQRS.Courses.Queries.GetCourse;
using Tasogarewa.Application.Interfaces;

namespace Tasogarewa.Application.CQRS.Images.Queries.GetImage
{
    public class GetImageQueryHandler : IRequestHandler<GetImageQuery, ImageVm>
    {

        private readonly IMapper Mapper;
        private readonly IRepository<Image> ImagesRepository;
        public GetImageQueryHandler(Repository<Image> repository, IMapper mapper)
        {
            ImagesRepository = repository;
            Mapper = mapper;
        }

        public async Task<ImageVm> Handle(GetImageQuery request, CancellationToken cancellationToken)
        {
            var Image = await ImagesRepository.GetAsync(request.Id);
            if (Image == null)
            {
                throw new NotFoundException(nameof(Image), request.Id);
            }
            else
                return Mapper.Map<ImageVm>(Image);
        }
    }
}
