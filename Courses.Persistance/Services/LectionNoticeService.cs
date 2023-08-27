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
using Tasogarewa.Application.CQRS.LectionNotices.Commands.CreateLectionNotice;
using Tasogarewa.Application.CQRS.LectionNotices.Commands.DeleteLectionNotice;
using Tasogarewa.Application.CQRS.LectionNotices.Commands.UpdateLectionNotice;
using Tasogarewa.Application.CQRS.LectionNotices.Queries.GetLectionNotices;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Tasogarewa.Persistance.Services
{
    public class LectionNoticeService : ILectionNoticeService
    {
        private readonly IRepository<Lection> _lectionRepository;
        private readonly IRepository<LectionNotice> _lectionNoticeRepository;
        private readonly IRepository<AppUser> _userNoticeRepository;
        private readonly IMapper _mapper;

        public LectionNoticeService(IRepository<Lection> lectionRepository, IRepository<LectionNotice> lectionNoticeRepository, IRepository<AppUser> userNoticeRepository, IMapper mapper)
        {
            _lectionRepository = lectionRepository;
            _lectionNoticeRepository = lectionNoticeRepository;
            _userNoticeRepository = userNoticeRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateLectionNoticeAsync(CreateLectionNoticeCommand createLectionNotice)
        {
            var user = await _userNoticeRepository.GetAsync(createLectionNotice.UserId);
            var lection = await _lectionRepository.GetAsync(createLectionNotice.LectionId);
            NotFoundException<AppUser>.Throw(user, createLectionNotice.UserId);
            NotFoundException<Lection>.Throw(lection, createLectionNotice.LectionId);
            var lectionNotice = await _lectionNoticeRepository.CreateAsync(new LectionNotice() { CreateAt = DateTime.Now, From = createLectionNotice.From, Lection = lection, Text = createLectionNotice.Text, User = user });
            return lectionNotice.Id;
        }
        public async Task<Unit> DeleteLectionNoticeAsync(DeleteLectionNoticeCommand deleteLectionNotice)
        {
            var lectionNotice = await _lectionNoticeRepository.GetAsync(deleteLectionNotice.Id);
            NotFoundException<LectionNotice>.Throw(lectionNotice, deleteLectionNotice.Id);
            await _lectionNoticeRepository.DeleteAsync(lectionNotice);
            return Unit.Value;
        }

        public async Task<LectionNoticeListVm> GetLectionNoticesAsync(GetLectionNoticesQuery getLectionNotices)
        {
            var lection = await _lectionRepository.GetAsync(getLectionNotices.LectionId);
            var lectionNotices = await _lectionNoticeRepository.GetAllAsync();
            NotFoundException<Lection>.Throw(lection, getLectionNotices.LectionId);
            return new LectionNoticeListVm() { lectionNoticeDtos = _mapper.ProjectTo<LectionNoticeDto>(lectionNotices.Where(x => x.Lection == lection).AsQueryable()).ToList() };
        }

        public async Task<Guid> UpdateLectionNoticeAsync(UpdateLectionNoticeCommand updateLectionNotice)
        {
            var lectionNotice = await _lectionNoticeRepository.GetAsync(updateLectionNotice.Id);
            NotFoundException<LectionNotice>.Throw(lectionNotice, updateLectionNotice.Id);
            lectionNotice.UpdateAt = DateTime.Now;
            lectionNotice.Text = updateLectionNotice.Text;
            lectionNotice.From = updateLectionNotice.From;
            await _lectionNoticeRepository.UpdateAsync(lectionNotice);
            return lectionNotice.Id;
        }
    }
}
