using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common;
using Tasogarewa.Application.Interfaces;

namespace Tasogarewa.Application.CQRS.Images.Commands.CreateImage
{
    public class CreateImageCommandHandler : IRequestHandler<CreateImageCommand, Guid>
    {
        private readonly IRepository<Image> ImagesRepository;
        private readonly IRepository<Course> CoursesRepository;
        private readonly IRepository<AppUser> UsersRepository;

        public CreateImageCommandHandler(Repository<Image> repository,Repository<Course> repository1, Repository<AppUser> repository2)
        {
            ImagesRepository = repository;
            CoursesRepository = repository1;
            UsersRepository = repository2;
        }

        public async Task<Guid> Handle(CreateImageCommand request, CancellationToken cancellationToken)
        {
            if (request.CourseId != null)
            {
                var image = await ImagesRepository.Create(new Image() { Id = request.Id, Path = request.Path, Course = await CoursesRepository.GetAsync((Guid)request.CourseId), appUser =await UsersRepository.GetAsync(request.UserId) });
                return image.Id;
            }
            else
            {
                var image = await ImagesRepository.Create(new Image() { Id = request.Id, Path = request.Path, appUser = await UsersRepository.GetAsync(request.UserId) });
                return image.Id;
            }
        }
    }
}
