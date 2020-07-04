using System;

using Microsoft.AspNetCore.Identity;

namespace SamTech.ExpenseTrack.Membership.Entities
{
    public class UserClaim
        : IdentityUserClaim<Guid>
    {
        public UserClaim()
            : base()
        {

        }
    }
}
