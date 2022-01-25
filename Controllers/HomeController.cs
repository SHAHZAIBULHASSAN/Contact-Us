using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaptchaMvc.Models;
using CaptchaMvc.HtmlHelpers;
using Contact_Us.Models;
using System.Net;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Contact_Us.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public ActionResult Contact()
        {

            return View();
        }
            public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

       
       [HttpPost]
      
        public ActionResult Contact(Contact_us contact )
        {


            var response = Request["g-recaptcha-response"];
            string secretKey = "6Lc_aDQeAAAAAJh4r5DNHxgTpqmUp7GT8rxAPBwM6Lc_aDQeAAAAAJh4r5DNHxgTpqmUp7GT8rxAPBwM";
            var client = new WebClient();
            var result = client.DownloadString(string.Format("https://www.goggle.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));
            var obj = JObject.Parse(result);
            var status = (bool)obj.SelectToken("success");
            ViewBag.Message = status ? "Google reCaptcha validation Success" : "Google reCaptcha validation Failed";
           


                if (this.IsCaptchaValid("Validate your captcha"))
            {
                ViewBag.ErrMessage = "Validation Message";
            }
            return View();


        }
    }
}