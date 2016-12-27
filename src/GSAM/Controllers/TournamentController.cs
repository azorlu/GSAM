using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GSAM.Models;
using GSAM.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace GSAM.Controllers
{
    public class TournamentController : Controller
    {
        private ITournamentRepository repository;
        public int PageSize = 2;

        public TournamentController(ITournamentRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(string category, int page = 1) 
            => View( new TournamentsListViewModel
            {
                Tournaments = repository.Tournaments
                .Where(t => category == null || t.Category == category)
                .OrderBy(t => t.Name)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ? repository.Tournaments.Count() 
                        : repository.Tournaments.Where(e => e.Category == category).Count()
                },
                CurrentCategory = category
            });

    }
}