using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common;
using Tasogarewa.Application.Interfaces;

namespace Tasogarewa.Application.CQRS.Images.Commands.CreateImage
{
    public class CreateImageCommandHandler : IRequestHandler<CreateImageCommand, Guid>
    {
        private readonly IRepository<Image> ImagesRepository;
      

        public CreateImageCommandHandler(Repository<Image> repository)
        {
            ImagesRepository = repository;
           
        }

        public async Task<Guid> Handle(CreateImageCommand request, CancellationToken cancellationToken)
        {
            var image = await ImagesRepository.Create(new Image() { Id = request.Id, Path = request.Path });
            return image.Id;
        }
    }
}
