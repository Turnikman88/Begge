using Braintree;
using System;
using System.Collections.Generic;
using System.Text;

namespace Begge.Services.Contracts
{
    public interface IBraintreeService
    {
        IBraintreeGateway CreateGateway();
        IBraintreeGateway GetGateway();
    }
}
