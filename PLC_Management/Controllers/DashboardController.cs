﻿using Microsoft.AspNetCore.Mvc;
using PLC_Management.Models.ActivityModel;


namespace PLC_Management.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }



    }
    
}
