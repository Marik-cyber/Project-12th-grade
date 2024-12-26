using ComputerInfoUploader.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ComputerInfoUploader.Controllers
{
    public class ComputerInfoController : Controller
    {
        private readonly ComputerInfoService _computerInfoService;

        public ComputerInfoController()
        {
            _computerInfoService = new ComputerInfoService();
        }

        [HttpGet]
        public IActionResult Index()
        {
            // Get computer details
            var details = _computerInfoService.GetComputerDetails();
            return Content(details); // אפשר גם לשלב View אם תרצה
        }
    }
}
    //< a asp - area = "" asp - controller = "ComputerInfo" asp - action = "index" > View Computer Details</a>