using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Daimler.Controllers;
using Daimler.Models;
using Daimler.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Daimler.Pages
{
    public class UploadIscListModel : PageModel
    {
        private IHostingEnvironment _environment;

        [Obsolete]
        public UploadIscListModel(IHostingEnvironment environment)
        {
            _environment = environment;
        }
        public IFormFile Upload { get; set; }

        [Obsolete]
        public async Task OnPost()
        {
            if (Upload != null)
            {
                if (HttpContext.Session.GetString("filelist") == null)
                {

                    var file = Path.Combine(_environment.WebRootPath, @"assets\uploads", Upload.FileName);
                    HttpContext.Session.SetString("filelist", file);
                    var fileextension = Path.GetExtension(file);
                    file = file.Replace(fileextension, "");
                    file = file.Remove(file.Length - 1, 1);
                    file = file + "_" + DateTime.Now.ToString().Replace(":", "_").Replace(" ", "") + "." + fileextension;
                    var filelist = Request.Headers["filelist"];
                    using (var fileStream = new FileStream(file, FileMode.Create))
                    {
                        await Upload.CopyToAsync(fileStream);
                    }
                    DaimlerContext _context = new DaimlerContext();
                    var dutyPaymentRequest = new DutyPaymentRequestHeaderService(_context);
                    var dutyPayment = new DutyPaymentRequestHeaderController(_context);
                    var result = dutyPaymentRequest.ReadDatafromExcelWorkSheet(file);

                    var ss = dutyPayment.Create(result);



                }
                else
                {
                    var dd = HttpContext.Session.GetString("filelist").Split(";");

                    var file = Path.Combine(_environment.WebRootPath, @"assets\uploads", Upload.FileName);
                    var sessionvalue = HttpContext.Session.GetString("filelist");
                    HttpContext.Session.SetString("filelist", sessionvalue + ";" + file);

                    if (!dd.Contains(file))
                    {
                        var fileextension = Path.GetExtension(file);
                        file = file.Replace(fileextension, "");
                        file = file.Remove(file.Length - 1, 1);
                        file = file + "_" + DateTime.Now.ToString().Replace(":", "_").Replace(" ", "") + "." + fileextension;
                        using (var fileStream = new FileStream(file, FileMode.Create))
                        {
                            await Upload.CopyToAsync(fileStream);
                        }
                        DaimlerContext _context = new DaimlerContext();
                        var dutyPaymentRequest = new DutyPaymentRequestHeaderService(_context);
                        var dutyPayment = new DutyPaymentRequestHeaderController(_context);
                        var result = dutyPaymentRequest.ReadDatafromExcelWorkSheet(file);

                        var ss = dutyPayment.Create(result);



                    }
                    //OnGet();
                }
            }
        }
        public void OnGet(string id)
        {

        }
    }
}