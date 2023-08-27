using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.UserCourseChats.Queries.GetUserCourseChat
{
    public class GetUserCourseChatQueryHandler : IRequestHandler<GetUserCourseChatQuery, UserCourseChatVm>
    {
        private readonly ICourseChatService _courseChatService;

        public GetUserCourseChatQueryHandler(ICourseChatService courseChatService)
        {
            _courseChatService = courseChatService;
        }

        public async Task<UserCourseChatVm> Handle(GetUserCourseChatQuery request, CancellationToken cancellationToken)
        {
            return await _courseChatService.GetUserCourseChatAsync(request);
        }
    }
}
