﻿using Courses.Domain;
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

namespace Tasogarewa.Application.CQRS.Images.Commands.DeleteImage
{
    public class DeleteImageCommandHandler:IRequestHandler<DeleteImageCommand,Unit>
    {
        private readonly IRepository<Image> ImagesRepository;


        public DeleteImageCommandHandler(Repository<Image> repository)
        {
            ImagesRepository = repository;

        }

        public async Task<Unit> Handle(DeleteImageCommand request, CancellationToken cancellationToken)
        {
            var Image = await ImagesRepository.GetAsync(request.Id);
            if (Image == null || Image.Id != request.Id)
            {
                throw new NotFoundException(nameof(Image), request.Id);
            }
            else
                ImagesRepository.Delete(Image);
            return Unit.Value;
        }
    }
}
