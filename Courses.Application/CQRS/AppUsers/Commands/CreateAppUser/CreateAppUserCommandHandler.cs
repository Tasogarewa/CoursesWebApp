using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.AppUsers.Commands.CreateAppUser
{
    public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommand, Guid>
    {
        private readonly IRepository<AppUser> _userRepository;
        private readonly IRepository<Mentor> _mentorRepository;

        public CreateAppUserCommandHandler(IRepository<AppUser> userRepository, IRepository<Mentor> mentorRepository, IRepository<Image> imageRepository)
        {
            _userRepository = userRepository;
            _mentorRepository = mentorRepository;
        }

        public async Task<Guid> Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
        {
            var mentor = await _mentorRepository.Create(new Mentor() { Email = request.Email, Name = request.Name, Surname = request.Surname});
            var user = await _userRepository.Create(new AppUser() { Email=request.Email, Name=request.Name, Surname = request.Surname, Mentor = mentor,Basket =new Basket(), UserWishList = new UserWishList(),LikedCourses=new LikedCourses(),UserNamedCourseList=new UserNamedCourseList(),ArchivedCourse = new ArchivedCourses() });
            return user.Id;
        }
    }
}
