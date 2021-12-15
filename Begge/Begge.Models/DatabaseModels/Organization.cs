using Begge.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Begge.Models.DatabaseModels
{
    public class Organization : BaseModel<Guid>
    {
        [MinLength(2)]
        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        public virtual Guid BeggerId { get; set; }

        public virtual Begger Begger { get; set; }

        public virtual ProfilePicture ProfilePicture { get; set; }
    }
}
