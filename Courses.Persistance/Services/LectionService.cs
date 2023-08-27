using AutoMapper;
using Azure.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.CQRS.Lections.Commands.CreateLection;
using Tasogarewa.Application.CQRS.Lections.Commands.DeleteLection;
using Tasogarewa.Application.CQRS.Lections.Commands.UpdateLection;
using Tasogarewa.Application.CQRS.Lections.Queries.GetLection;
using Tasogarewa.Application.CQRS.Lections.Queries.GetLections;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Persistance.Services
{
    public class LectionService : ILectionService
    {
        private readonly IRepository<Section> _sectionRepository;
        private readonly IRepository<Lection> _lectionRepository;
        private readonly IRepository<CodeEx> _codeExRepository;
        private readonly IRepository<Test> _testRepository;
        private readonly IMapper _mapper;

        public LectionService(IRepository<Section> sectionRepository, IRepository<Lection> lectionRepository, IRepository<CodeEx> codeExRepository, IRepository<Test> testRepository, IMapper mapper)
        {
            _sectionRepository = sectionRepository;
            _lectionRepository = lectionRepository;
            _codeExRepository = codeExRepository;
            _testRepository = testRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateLectionAsync(CreateLectionCommand createLection)
        {
            var section = await _sectionRepository.GetAsync(createLection.SectionId);
            NotFoundException<Section>.Throw(section, createLection.SectionId);
            var lection = await _lectionRepository.CreateAsync(new Lection() { Name = createLection.Name, Section = section });
            return lection.Id;
        }

        public async Task<Unit> DeleteLectionAsync(DeleteLectionCommand deleteLection)
        {
            var lection = await _lectionRepository.GetAsync(deleteLection.Id);
            NotFoundException<Lection>.Throw(lection, deleteLection.Id);
            await _lectionRepository.DeleteAsync(lection);
            return Unit.Value;
        }

        public async Task<LectionVm> GetLectionAsync(GetLectionQuery getLection)
        {
            var lection = await _lectionRepository.GetAsync(getLection.Id);
            NotFoundException<Lection>.Throw(lection, getLection.Id);
            return _mapper.Map<LectionVm>(lection);
        }

        public async Task<LectionListVm> GetLectionsAsync(GetLectionsQuery getLections)
        {
            var lections = await _lectionRepository.GetAllAsync();
            var section = await _sectionRepository.GetAsync(getLections .SectionId);
            NotFoundException<Section>.Throw(section, getLections.SectionId);
            NotFoundException<Lection>.ThrowRange(lections.ToList(), getLections.SectionId);
            return new LectionListVm() { lectionDtos = _mapper.ProjectTo<LectionDto>(lections.Where(x => x.Section == section).AsQueryable()).ToList() };
        }

        public async Task<Guid> UpdateLectionAsync(UpdateLectionCommand updateLection)
        {
            var codeEx = await _codeExRepository.GetAsync(updateLection.CodeExId);
            var test = await _testRepository.GetAsync(updateLection.TestId);
            var lection = await _lectionRepository.GetAsync(updateLection.Id);
            NotFoundException<Lection>.Throw(lection, updateLection.Id);
            NotFoundException<Test>.Throw(test, updateLection.TestId);
            NotFoundException<CodeEx>.Throw(codeEx, updateLection.CodeExId);
            lection.Description = updateLection.Description;
            lection.FilePath = updateLection.FilePath;
            lection.Name = updateLection.Name;
            lection.CodeEx = codeEx;
            lection.Tests = test;
            await _lectionRepository.UpdateAsync(lection);
            return lection.Id;
        }

    
    }
}
