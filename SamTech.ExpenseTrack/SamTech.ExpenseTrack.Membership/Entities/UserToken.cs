using System;

using Microsoft.AspNetCore.Identity;

namespace SamTech.ExpenseTrack.Membership.Entities
{
    public class UserToken
        : IdentityUserToken<Guid>
    {
        public UserToken()
            : base()
        {

        }
    }
}
