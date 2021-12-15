using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Begge.Web.Models
{
    public class PayViewModel
    {
        public string Nonce { get; set; }
        public string  Secret { get; set; }
    }
}
