using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Daimler.Controllers;
using Daimler.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using static Daimler.Controllers.DutyPaymentRequestHeaderController;

namespace Daimler.Pages
{
    public class Dashboard : PageModel
    {
        private readonly ILogger<Dashboard> _logger;

        public Dashboard(ILogger<Dashboard> logger)
        {
            _logger = logger;
        }
        public IList<paymentlist> dutyPaymentRequestHeaders { get; set; }
        public void OnGet()
        {
            DaimlerContext _context = new DaimlerContext();

            var dutyPayment = new DutyPaymentRequestHeaderController(_context);
            dutyPaymentRequestHeaders = dutyPayment.GetDutyPaymentRequestHeader();
        }
    }
}
