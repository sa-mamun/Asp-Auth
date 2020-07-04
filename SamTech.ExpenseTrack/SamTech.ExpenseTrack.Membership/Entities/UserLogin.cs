using System;

using Microsoft.AspNetCore.Identity;

namespace SamTech.ExpenseTrack.Membership.Entities
{
    public class UserLogin
        : IdentityUserLogin<Guid>
    {
        public UserLogin()
            : base()
        {

        }
    }
}
