using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GSAM.Models;
using GSAM.Models.ViewModels;

namespace GSAM.Controllers
{
    public class PlayerController : Controller
    {

        private IPlayerRepository repository;
        public int PageSize = 2;

        public PlayerController(IPlayerRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(int page = 1)
            => View(new PlayersListViewModel {
                Players = repository.Players
                .OrderBy(p => p.LastName)
                .ThenBy(p => p.FirstName)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Players.Count()
                }
            });

        
    }
}