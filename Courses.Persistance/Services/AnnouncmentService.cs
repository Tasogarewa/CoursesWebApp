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
using Tasogarewa.Application.CQRS.Announcments.Commands.CreateAnnouncments;
using Tasogarewa.Application.CQRS.Announcments.Commands.DeleteAnnouncments;
using Tasogarewa.Application.CQRS.Announcments.Commands.UpdateAnnouncments;
using Tasogarewa.Application.CQRS.Announcments.Queries.GetAnnouncments;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Persistance.Services
{
    public class AnnouncmentService : IAnnouncmentService
    {
        private readonly IRepository<Announcement> _announcmentRepository;
        private readonly IMapper _mapper;

        public AnnouncmentService(IRepository<Announcement> announcmentRepository, IMapper mapper)
        {
            _announcmentRepository = announcmentRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateAnnouncmentAsync(CreateAnnouncmentCommand announcementCreate)
        {
            var announcment = await _announcmentRepository.CreateAsync(new Announcement() { CreateAt =DateTime.Now, Images= announcementCreate.Images, Text= announcementCreate.Text, CourseId = announcementCreate.CourseId, MentorId = announcementCreate.MentorId});
            return announcment.Id;
        }

        public async Task<Unit> DeleteAnnouncmentAsync(DeleteAnnouncmentCommand deleteAnnouncmentCommand)
        {
            var announcment = await _announcmentRepository.GetAsync(deleteAnnouncmentCommand.Id);
            NotFoundException<Announcement>.Throw(announcment, deleteAnnouncmentCommand.Id);
            await _announcmentRepository.DeleteAsync(announcment);
            return Unit.Value;
        }

        public async Task<AnnouncmentListVm> GetAnnouncmentsAsync(GetAnnouncmentsQuery announcmentsQuery)
        {
            var announcments = await _announcmentRepository.GetAllAsync();
            NotFoundException<Announcement>.ThrowRange(announcments.ToList(), announcmentsQuery.CourseId);
            return new AnnouncmentListVm() { AnnouncmentDtos =  _mapper.ProjectTo<AnnouncmentDto>(announcments.Where(x => x.CourseId == announcmentsQuery.CourseId).AsQueryable()).ToList() };
        }

        public async Task<Guid> UpdateAnnoucmentAsync(UpdateAnnouncmentCommand announcementUpdate)
        {
            var announcment = await _announcmentRepository.GetAsync(announcementUpdate.Id);
            NotFoundException<Announcement>.Throw(announcment, announcementUpdate.Id);
            announcment.UpdateAt = DateTime.Now;
            announcment.Images = announcementUpdate.Images;
            announcment.Text = announcementUpdate.Text;
            await _announcmentRepository.UpdateAsync(announcment);
            return announcment.Id;
        }
    }
}
