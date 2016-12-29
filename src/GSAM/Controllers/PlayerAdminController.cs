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

        public ViewResult Edit(int playerID) 
            => View(repository.Players.FirstOrDefault(p => p.PlayerID == playerID));
    }
}
