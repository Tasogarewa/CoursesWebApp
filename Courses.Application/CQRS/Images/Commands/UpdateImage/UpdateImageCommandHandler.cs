using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.CQRS.Courses.Queries.GetCourse;
using Tasogarewa.Application.Interfaces;

namespace Tasogarewa.Application.CQRS.Images.Commands.UpdateImage
{
    public class UpdateImageCommandHandler : IRequestHandler<UpdateImageCommand, Guid>
    {
        private readonly IRepository<Image> ImagesRepository;
        public UpdateImageCommandHandler(IRepository<Image> repository)
        {
            ImagesRepository = repository;

        }
        public async Task<Guid> Handle(UpdateImageCommand request, CancellationToken cancellationToken)
        {
            var Image = await ImagesRepository.GetAsync(request.Id);
            if (Image == null || Image.Id != request.Id||Image.appUser.Id!=request.UserId)
            {
                throw new NotFoundException(nameof(Image), request.Id);
            }
            else
            {
                Image.Path = request.Path;
                ImagesRepository.Update(Image);
                return (Image.Id);
            }
        }
    }
}

