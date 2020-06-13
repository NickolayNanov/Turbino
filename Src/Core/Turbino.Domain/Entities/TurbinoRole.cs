namespace Turbino.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Identity;

    public class TurbinoRole : IdentityRole<string>
    {
        public TurbinoRole()
        {
            this.RoleUsers = new HashSet<TurbinoUserRole>();
        }

        public TurbinoRole(string name)
            : base(name)
        {
            this.Id = Guid.NewGuid().ToString();
            this.RoleUsers = new HashSet<TurbinoUserRole>();
        }

        public virtual ICollection<TurbinoUserRole> RoleUsers { get; set; }
    }
}
