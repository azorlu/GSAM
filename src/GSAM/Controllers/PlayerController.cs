using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GSAM.Models;

namespace GSAM.Controllers
{
    public class PlayerController : Controller
    {

        private IPlayerRepository repository;

        public PlayerController(IPlayerRepository repo)
        {
            repository = repo;
        }

        public ViewResult List() => View(repository.Players);

        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}