using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.MentorCourseChats.Queries.GetMentorCourseChats
{
    public class GetMentorCourseChatsQueryHandler : IRequestHandler<GetMentorCourseChatsQuery, MentorCourseChatListVm>
    {
        private readonly IMapper _mapper;
        private IRepository<Mentor> _mentorRepository;

        public GetMentorCourseChatsQueryHandler(IMapper mapper, IRepository<Mentor> mentorRepository)
        {
            _mapper = mapper;
            _mentorRepository = mentorRepository;
        }

        public async Task<MentorCourseChatListVm> Handle(GetMentorCourseChatsQuery request, CancellationToken cancellationToken)
        {
            var mentor = await _mentorRepository.GetAsync(request.MentorId);
            if (mentor == null || request.MentorId == Guid.Empty)
            {
                throw new NotFoundException(nameof(mentor), request.MentorId);
            }
            else
                return new MentorCourseChatListVm() { courseChatDtos = await _mapper.ProjectTo<MentorCourseChatDto>((IQueryable)mentor.CourseChats).ToListAsync() };
        }
    }
}
