namespace Turbino.Domain.Entities
{
    using System;
    using Interfaces;
    using Microsoft.AspNetCore.Identity;

    public class TurbinoRole : IdentityRole, IAuditableEntity, IDeletableEntity
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

        public DateTime CreatedOn { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string LastModifiedBy { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
