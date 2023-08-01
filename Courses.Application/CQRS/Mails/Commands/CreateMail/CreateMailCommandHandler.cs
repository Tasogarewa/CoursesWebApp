using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common;
using Tasogarewa.Application.Interfaces;

namespace Tasogarewa.Application.CQRS.Mails.Commands.CreateMail
{
    public class CreateMailCommandHandler : IRequestHandler<CreateMailCommand, Guid>
    {
        private readonly IRepository<Mail> MailRepository;
        public CreateMailCommandHandler(Repository<Mail> repository)
        {
            MailRepository = repository;
        }

        public async Task<Guid> Handle(CreateMailCommand request, CancellationToken cancellationToken)
        {
            var Mail = await MailRepository.Create(new Mail() { Id = request.Id, Header = request.Header, Description = request.Description, MailTo = request.MailTo, Sended = DateTime.Now }) ;
            return Mail.Id;
        }
    }
}
