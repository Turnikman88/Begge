using Begge.Services.Contracts;
using Begge.Web.Models;
using Braintree;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Begge.Web.Controllers
{
    public class BraintreeController : Controller
    {
        private readonly IBraintreeService _bts;

        public BraintreeController(IBraintreeService bts)
        {
            this._bts = bts;
        }

        public async Task<IActionResult> Index()
        {
            var gateway = _bts.GetGateway();
            var clientToken = await gateway.ClientToken.GenerateAsync();
            var model = new PayViewModel();
            model.Secret = clientToken;
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PayViewModel model)
        {
            var gateway = _bts.GetGateway();
            var request = new TransactionRequest
            {
                Amount = Convert.ToDecimal("250"),
                PaymentMethodNonce = model.Nonce,
                Options = new TransactionOptionsRequest
                {
                    SubmitForSettlement = true
                }
            };

            Result<Transaction> result = await gateway.Transaction.SaleAsync(request);

            if (result.IsSuccess())
            {
                return View("Success");
            }
            return BadRequest();
        }
    }
}
