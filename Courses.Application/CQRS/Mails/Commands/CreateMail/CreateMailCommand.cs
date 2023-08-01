using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Mails.Commands.CreateMail
{
    public class CreateMailCommand:IRequest<Guid>
    {
       public Guid Id { get; set; }
        public string Description { get; set; }
        public string Header { get; set; }
        public virtual AppUser MailTo { get; set; }
    }
}
