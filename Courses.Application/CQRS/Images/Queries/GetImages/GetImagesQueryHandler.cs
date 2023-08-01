using AutoMapper;
using Courses.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.CQRS.Courses.Queries.GetCourse;
using Tasogarewa.Application.Interfaces;

namespace Tasogarewa.Application.CQRS.Images.Queries.GetImages
{
    public class GetImagesQueryHandler : IRequestHandler<GetImagesQuery, ImageListVm>
    {
        private readonly IMapper Mapper;
        private readonly IRepository<Image> ImagesRepository;
        public GetImagesQueryHandler(Repository<Image> repository, IMapper mapper)
        {
            ImagesRepository = repository;
            Mapper = mapper;
        }
        public async Task<ImageListVm> Handle(GetImagesQuery request, CancellationToken cancellationToken)
        {
            var Images = await ImagesRepository.GetAllAsync();
            if (Images == null)
            {
                throw new NotFoundException(nameof(Images), request.CourseId);
            }
            else return new ImageListVm() { ImagesList = await Mapper.ProjectTo<ImageDto>((IQueryable)Images.Where(x => x.Course.Id == request.CourseId)).ToListAsync()};
        }
    }
}
