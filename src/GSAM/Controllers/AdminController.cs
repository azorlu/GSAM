using GSAM.Models;
using GSAM.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GSAM.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        public AdminController()
        {   
        }
        public ViewResult Index () => View();
    }
}
