using Begge.Common;
using Begge.Web.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Begge.Web.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Error()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
            var imageLink = $"{Constants.Domain}/images/";
            string message = "";
            if (exception != null)
            {
                imageLink += "500.png";
                message = exception.Message;
            }
            else
            {
                imageLink += "404.png";
            }
            var statuscode = HttpContext.Response.StatusCode;

            var model = new ErrorViewModel
            {
                ImageLink = imageLink,
                Message = message,
                StatusCode = statuscode
            };

            return this.View(model);
        }
    }
}
