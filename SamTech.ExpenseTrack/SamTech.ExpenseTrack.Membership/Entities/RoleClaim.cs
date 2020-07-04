using System;

using Microsoft.AspNetCore.Identity;

namespace SamTech.ExpenseTrack.Membership.Entities
{
    public class RoleClaim
        : IdentityRoleClaim<Guid>
    {
        public RoleClaim()
            : base()
        {

        }
    }
}
