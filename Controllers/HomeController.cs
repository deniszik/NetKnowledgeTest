using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetKnowledgeTest.Models;
using ServiceReference1;

namespace NetKnowledgeTest.Controllers
{
    /*public class LoginResultData
    {
        public int ResultCode { get; set; }
        public string ResultMessage { get; set; }
    }*/
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {           
            return View();
        }
        [HttpGet]
        public ContentResult UserLogin(string userName, string userPassword)
        {
            ICUTechClient svc = new ICUTechClient();
            LoginResponse result = svc.Login(new LoginRequest(userName, userPassword, "0.0.0.0"));
            
            // LoginResultData jsonSerializer = JsonSerializer.Deserialize<LoginResultData>(result.@return.Trim());            
                                   
            // return Json(jsonSerializer);
            
            ContentResult response = new ContentResult();
            response.Content = result.@return.Trim();
            response.ContentType = "application/json";
            return response;
        }

        public IActionResult Menu2()
        {
            return View();
        }
        public IActionResult Menu3()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
