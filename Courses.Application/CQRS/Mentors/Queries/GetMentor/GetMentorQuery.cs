﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Mentors.Queries.GetMentor
{
    public class GetMentorQuery:IRequest<MentorVm>
    {
        public Guid Id { get; set; }
    }
}
