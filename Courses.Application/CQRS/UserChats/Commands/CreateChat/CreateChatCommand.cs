﻿using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.UserChats.Commands.CreateChat
{
    public class CreateChatCommand:IRequest<Guid>
    {
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public AppUser User { get; set; }
    }
}
