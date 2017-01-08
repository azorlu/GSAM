using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GSAM.Models;
using GSAM.Models.ViewModels;

namespace GSAM.Controllers
{
    public class TournamentAdminController : Controller
    {
        public ITournamentRepository repository;
        public int PageSize = 4;

        public TournamentAdminController(ITournamentRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(string category, int page = 1)
            => View(new TournamentsListViewModel
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

        [HttpGet]
        public ViewResult Edit(int tournamentID)
            => View(repository.Tournaments.FirstOrDefault(t => t.TournamentID == tournamentID));

        [HttpPost]
        public IActionResult Edit(Tournament tournament)
        {
            if (ModelState.IsValid)
            {
                repository.SaveTournament(tournament);
                TempData["message"] = $"{tournament.Name} has been saved to database.";
                return RedirectToAction("List");
            }
            else
            {
                return View(tournament);
            }
        }

        public ViewResult Create() => View("Edit", new Tournament());

        [HttpPost]
        public IActionResult Delete(int tournamentID)
        {
            // TODO: tournament with tournament events should not be deleted.
            Tournament deletedTournament = repository.DeleteTournament(tournamentID);
            if (deletedTournament != null)
            {
                TempData["message"] = $"{deletedTournament.Name} has been deleted.";
            }
            return RedirectToAction("List");
        }

    }
}
