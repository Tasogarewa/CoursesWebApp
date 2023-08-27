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
        private readonly ICourseChatService _courseChatService;

        public GetMentorCourseChatsQueryHandler(ICourseChatService courseChatService)
        {
            _courseChatService = courseChatService;
        }

        public async Task<MentorCourseChatListVm> Handle(GetMentorCourseChatsQuery request, CancellationToken cancellationToken)
        {
            return await _courseChatService.GetMentorCourseChatsAsync(request);
        }
    }
}
