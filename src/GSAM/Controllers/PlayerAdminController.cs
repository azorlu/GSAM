using GSAM.Models;
using GSAM.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GSAM.Controllers
{
    public class PlayerAdminController : Controller
    {
        private IPlayerRepository repository;
        public int PageSize = 4;

        public PlayerAdminController(IPlayerRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(int page = 1)
           => View(new PlayersListViewModel
           {
               Players = repository.Players
               .OrderBy(p => p.PlayerID)
               .Skip((page - 1) * PageSize)
               .Take(PageSize),
               PagingInfo = new PagingInfo
               {
                   CurrentPage = page,
                   ItemsPerPage = PageSize,
                   TotalItems = repository.Players.Count()
               }
           });

        [HttpGet]
        public ViewResult Edit(int playerID) 
            => View(repository.Players.FirstOrDefault(p => p.PlayerID == playerID));

        [HttpPost]
        public IActionResult Edit(Player player)
        {
            if (ModelState.IsValid)
            {
                repository.SavePlayer(player);
                TempData["message"] = $"{player.FullName} has been saved to database.";
                return RedirectToAction("List");
            }
            else
            {
                return View(player);
            }
        }

        public ViewResult Create() => View("Edit", new Player());

        [HttpPost]
        public IActionResult Delete(int playerID)
        {
            Player deletedPlayer = repository.DeletePlayer(playerID);
            if (deletedPlayer != null)
            {
                TempData["message"] = $"{deletedPlayer.FullName} has been deleted.";
            }
            return RedirectToAction("List");
        }
    }
}
