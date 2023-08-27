using AutoMapper;
using Azure.Core;
using Courses.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.CQRS.Courses.Queries.GetCourse;
using Tasogarewa.Application.CQRS.Sections.Commands.CreateSection;
using Tasogarewa.Application.CQRS.Sections.Commands.DeleteSection;
using Tasogarewa.Application.CQRS.Sections.Commands.UpdateSection;
using Tasogarewa.Application.CQRS.Sections.Queries.GetSection;
using Tasogarewa.Application.CQRS.Sections.Queries.GetSections;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Persistance.Services
{
    public class SectionService : ISectionService
    {
        private readonly IRepository<Section> _sectionRepository;
        private readonly IRepository<Course> _courseRepository;
        private readonly IMapper _mapper;

        public SectionService(IRepository<Section> sectionRepository, IRepository<Course> courseRepository, IMapper mapper)
        {
            _sectionRepository = sectionRepository;
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateSectionAsync(CreateSectionCommand createSection)
        {
            var course = await _courseRepository.GetAsync(createSection.CourseId);
            NotFoundException<Course>.Throw(course, createSection.CourseId);
            var section = await _sectionRepository.CreateAsync(new Section() { Course = course, Name = createSection.Name });
            return section.Id;
        }

        public async Task<Unit> DeleteSectionAsync(DeleteSectionCommand deleteSection)
        {
            var section = await _sectionRepository.GetAsync(deleteSection.Id);
            NotFoundException<Section>.Throw(section, deleteSection.Id);
            await _sectionRepository.DeleteAsync(section);
            return Unit.Value;
        }

        public async Task<SectionVm> GetSectionAsync(GetSectionQuery getSection)
        {
            var section = await _sectionRepository.GetAsync(getSection.Id);
            NotFoundException<Section>.Throw(section, getSection.Id);
            return _mapper.Map<SectionVm>(section);
        }

        public async Task<SectionListVm> GetSectionsAsync(GetSectionsQuery getSections)
        {
            var course = await _courseRepository.GetAsync(getSections.CourseId);
            NotFoundException<Course>.Throw(course, getSections.CourseId);
            return new SectionListVm() { sectionDtos =  _mapper.ProjectTo<SectionDto>(course.Sections.AsQueryable()).ToList() };
        }

        public async Task<Guid> UpdateSectionAsync(UpdateSectionCommand updateSection)
        {
            var section = await _sectionRepository.GetAsync(updateSection.Id);
            NotFoundException<Section>.Throw(section, updateSection.Id);
            section.Lections = updateSection.Lections;
            section.Name = updateSection.Name;
            await _sectionRepository.UpdateAsync(section);
            return section.Id;
        }
    }
}
