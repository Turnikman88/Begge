using Begge.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Begge.Models.DatabaseModels
{
    public class ProfilePicture : BaseModel<Guid>
    {
        public string ImageLink { get; set; }

        public Guid BeggerId { get; set; }

        public virtual Begger Begger{ get; set; }

        public Guid OrganizationId { get; set; }

        public virtual Organization Organization { get; set; }

    }
}
