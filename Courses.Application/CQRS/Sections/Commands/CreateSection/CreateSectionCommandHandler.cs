using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.Sections.Commands.CreateSection
{
    public class CreateSectionCommandHandler : IRequestHandler<CreateSectionCommand, Guid>
    {
        private readonly IRepository<Section> _sectionRepository;
        private readonly IRepository<Course> _courseRepository;

        public CreateSectionCommandHandler(IRepository<Section> sectionRepository, IRepository<Course> courseRepository)
        {
            _sectionRepository = sectionRepository;
            _courseRepository = courseRepository;
        }

        public async Task<Guid> Handle(CreateSectionCommand request, CancellationToken cancellationToken)
        {
            var section = await _sectionRepository.Create(new Section() { Course = await _courseRepository.GetAsync(request.CourseId), Name = request.Name });
            return section.Id;
        }
    }
}
