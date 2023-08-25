using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.LectionNotices.Commands.CreateLectionNotice
{
    public class CreateLectionNoticeCommandHandler : IRequestHandler<CreateLectionNoticeCommand, Guid>
    {
        private readonly IRepository<Lection> _lectionRepository;
        private readonly IRepository<AppUser> _userRepository;
        private readonly IRepository<LectionNotice> _lectionNoticeRepository;

        public CreateLectionNoticeCommandHandler(IRepository<Lection> lectionRepository, IRepository<AppUser> userRepository, IRepository<LectionNotice> lectionNoticeRepository)
        {
            _lectionRepository = lectionRepository;
            _userRepository = userRepository;
            _lectionNoticeRepository = lectionNoticeRepository;
        }

        public async Task<Guid> Handle(CreateLectionNoticeCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(request.UserId);
            var lection = await _lectionRepository.GetAsync(request.LectionId);
            var lectionNotice = await _lectionNoticeRepository.Create(new LectionNotice() { CreateAt = DateTime.Now, From = request.From, Lection = lection, Text = request.Text, User = user });
            return lectionNotice.Id;
        }
    }
}
