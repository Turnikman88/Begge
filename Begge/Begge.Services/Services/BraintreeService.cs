using Begge.Services.Contracts;
using Braintree;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Begge.Services.Services
{
    public class BraintreeService : IBraintreeService
    {
        private readonly IConfiguration _config;

        public BraintreeService(IConfiguration config)
        {
            this._config = config;
        }
        public IBraintreeGateway CreateGateway()
        {
            var newGateway = new BraintreeGateway
            {
                Environment = Braintree.Environment.SANDBOX,
                MerchantId = _config.GetValue<string>("BraintreeGateway:MerchantId"),
                PublicKey = _config.GetValue<string>("BraintreeGateway:PublicKey"),
                PrivateKey = _config.GetValue<string>("BraintreeGateway:PrivateKey")
            };
            return newGateway;
        }

        public IBraintreeGateway GetGateway()
        {
            return CreateGateway();
        }
    }
}
