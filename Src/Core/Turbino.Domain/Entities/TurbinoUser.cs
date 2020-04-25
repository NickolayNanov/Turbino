namespace Turbino.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Identity;

    public class TurbinoUser : IdentityUser<string>
    {
        public TurbinoUser()
        {
            this.Id = Guid.NewGuid().ToString();

            this.Reviews = new HashSet<Review>();
            this.UserDestinations = new HashSet<UserDestination>();
            this.UserRoles = new HashSet<TurbinoUserRole>();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
        }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

        public virtual ICollection<Review> Reviews { get; private set; }

        public virtual ICollection<CreditCard> Cards { get; private set; }

        public virtual ICollection<UserDestination> UserDestinations { get; private set; }

        public virtual ICollection<TurbinoUserRole> UserRoles { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; private set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; private set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; private set; }
    }
}
