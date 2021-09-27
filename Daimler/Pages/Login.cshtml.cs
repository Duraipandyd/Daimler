using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Daimler.Models;
using Daimler.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RestSharp;
using static Daimler.Services.DataReader;

namespace Daimler.Pages
{
    public class LoginModel : PageModel
    {
        //DaimlerContext _Context;
        //public LoginModel(DaimlerContext databasecontext)
        //{
        //    _Context = databasecontext;
        //}
        [BindProperty]
        public string Username { get; set; }
        public string Password { get; set; }
        public int PIN { get; set; }
        public bool RememberMe { get; set; }
        //public string Message { get; set; }
        
        public Toaster myToaster { get; set; }
        public void OnGet()
        {
        }


        public async Task<IActionResult> OnPostAsync()
        {
            IRestResponse restResponse = new RestResponse();
            DataReader datareader = new DataReader();

            string username = Request.Form["Username"].ToString();
            string password = Request.Form["Password"].ToString();

            //var login = await _Context.Login
            //    .FirstOrDefaultAsync(x => x.Username == username && x.Password == password);

            //if (login != null)
            //{
            //    return RedirectToPage("/Dashboard");
            //}
            //else
            //{
            //    if (restResponse.Content != "")
            //    {
            //        var error = JsonConvert.DeserializeObject(restResponse.Content);
            //        myToaster.Message = error.ToString();
            //        myToaster.CssClass = "alert-danger";
            //        //ModelState.AddModelError("Error", error.ToString());
            //    }
            //    else
            //    {
            //        myToaster.Message = restResponse.ErrorMessage;
            //        myToaster.CssClass = "alert-danger";
            //        // ModelState.AddModelError("Error", restResponse.ErrorMessage);
            //    }

            //    return Page();
            //    //if (restResponse.ResponseStatus == ResponseStatus.Error) return BadRequest(error);
            //}
            return null;
        }
    }
}
