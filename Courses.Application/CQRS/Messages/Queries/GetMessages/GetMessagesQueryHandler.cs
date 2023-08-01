using AutoMapper;
using Courses.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.CQRS.Courses.Queries.GetCourses;
using Tasogarewa.Application.Interfaces;

namespace Tasogarewa.Application.CQRS.Messages.Queries.GetMessages
{
    public class GetMessagesQueryHandler : IRequestHandler<GetMessagesQuery, MessagesListVm>
    {
        private readonly IMapper Mapper;
        private readonly IRepository<Message> MessagesRepository;
        public GetMessagesQueryHandler(Repository<Message> repositoryMessages, IMapper mapper)
        {
            MessagesRepository = repositoryMessages;
            Mapper = mapper;
        }
        public async Task<MessagesListVm> Handle(GetMessagesQuery request, CancellationToken cancellationToken)
        {
            var messages = await MessagesRepository.GetAllAsync();
            if (messages == null)
            {
                throw new NotFoundException(nameof(messages), 0);
            }
            else
                return new MessagesListVm() { MessagesList = await Mapper.ProjectTo<MessagesDto>((IQueryable)messages).ToListAsync() };
        }
    }
}
