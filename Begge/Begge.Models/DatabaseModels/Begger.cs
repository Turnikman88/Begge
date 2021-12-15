using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Begge.Models.DatabaseModels
{
    public class Begger
    {
        public Guid Id { get; set; }

        [MinLength(2)]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [MinLength(2)]
        [MaxLength(20)]
        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string QrCodePath { get; set; }

        public virtual ProfilePicture ProfilePicture { get; set; }

        public virtual ICollection<Organization> Organizations { get; set; }

    }
}
