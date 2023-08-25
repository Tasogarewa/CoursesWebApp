using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.UserWishLists.Queries.GetUserWishList
{
    public class GetUserWishListQueryValidator:AbstractValidator<GetUserWishListQuery>
    {
        public GetUserWishListQueryValidator() 
        {
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
        }
    }
}
