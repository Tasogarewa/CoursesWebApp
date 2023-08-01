using AutoMapper;
using Courses.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.Interfaces;

namespace Tasogarewa.Application.CQRS.Comments.Queries.GetComments
{
    public class GetCommentsQueryHandler : IRequestHandler<GetCommentsQuery, CommentListVm>
    {
        private readonly IMapper Mapper;
        private readonly IRepository<Comment> CommentRepository;

        public GetCommentsQueryHandler(IMapper mapper,Repository<Comment> repository)
        {
            Mapper = mapper;
            CommentRepository = repository;
        }

        public async Task<CommentListVm> Handle(GetCommentsQuery request, CancellationToken cancellationToken)
        {
            var comm = await CommentRepository.GetAllAsync();
            
            if (comm == null)
            {
                throw new NotFoundException(nameof(comm), request.CourseId);
            }
            else
                return new CommentListVm { CommentsList = await Mapper.ProjectTo<CommentsDto>((IQueryable)comm.Where(x=>x.Course.Id==request.CourseId)).ToListAsync() };
        }
    }
}
