namespace Turbino.Domain.Entities
{
    using System;
    using Microsoft.AspNetCore.Identity;

    public class TurbinoRole : IdentityRole<string>
    {
        public TurbinoRole()
            : this(null)
        {
        }

        public TurbinoRole(string name)
            : base(name)
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
