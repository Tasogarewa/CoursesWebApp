using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.CQRS.Courses.Queries.GetCourses;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.MentorCourseChats.Queries.GetMentorCourseChat
{
    public class GetMentorCourseChatQueryHandler : IRequestHandler<GetMentorCourseChatQuery, MentorCourseChatVm>
    {
        private readonly ICourseChatService _courseChatService;

        public GetMentorCourseChatQueryHandler(ICourseChatService courseChatService)
        {
            _courseChatService = courseChatService;
        }

        public async Task<MentorCourseChatVm> Handle(GetMentorCourseChatQuery request, CancellationToken cancellationToken)
        {
            return await _courseChatService.GetMentorCourseChatAsync(request);

        }
    }
}
