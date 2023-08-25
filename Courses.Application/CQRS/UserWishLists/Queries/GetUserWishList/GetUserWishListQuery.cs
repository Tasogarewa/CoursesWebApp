using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.UserWishLists.Queries.GetUserWishList
{
    public class GetUserWishListQuery:IRequest<UserWishListVm>
    {
        public Guid UserId { get; set; }
    }
}
