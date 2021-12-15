using Begge.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Begge.Models.DatabaseModels
{
    public class Role : BaseModel<Guid>
    {
        public string Name { get; set; }

        public virtual ICollection<Begger> Beggers { get; set; }
    }
}
