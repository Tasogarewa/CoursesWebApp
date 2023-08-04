using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common;
using Tasogarewa.Application.Interfaces;

namespace Tasogarewa.Application.CQRS.Courses.Commands.CreateCourse
{
    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, Guid>
    {
        private readonly IRepository<Course> CoursesRepository;
        private readonly IRepository<AppUser> AppUserRepository;

        public CreateCourseCommandHandler(Repository<Course> repository, Repository<AppUser> repositoryUser)
        {
            CoursesRepository = repository;
            AppUserRepository = repositoryUser;
        }

        public async Task<Guid> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await CoursesRepository.Create(new Course { Rating = 0, appUser = AppUserRepository.GetAsync(request.UserId), Expires = request.Expires, Description = request.Description, CreateAt = DateTime.Now, Images = request.Images, Name = request.Name, FilePath = request.FilePath, Price = request.Price });
            return course.Id;
        }
    }
}
