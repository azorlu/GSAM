using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GSAM.Models;
using GSAM.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GSAM.Controllers
{
    public class TournamentEventAdminController : Controller
    {
        public ITournamentEventRepository repository;
        public ITournamentRepository parentRepository;
        public int PageSize = 4;

        public TournamentEventAdminController(ITournamentEventRepository repo, ITournamentRepository parentRepo)
        {
            repository = repo;
            parentRepository = parentRepo;
        }

        public ViewResult List(int page = 1)
            => View(new TournamentEventsListViewModel
            {
                TournamentEvents = repository.TournamentEvents
                .OrderBy(e => e.Tournament.Name)
                .ThenBy(e => e.Name)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.TournamentEvents.Count()
                }
            });

        [HttpGet]
        public ViewResult Edit(int tournamentEventID)
        {
            GenerateTournamentsSelectList();

            return View(repository.TournamentEvents.FirstOrDefault(e => e.TournamentEventID == tournamentEventID));
        }

        private void GenerateTournamentsSelectList()
        {
            ViewBag.TournamentsList = parentRepository.Tournaments.OrderBy(t => t.Name)
                .Select(t => new SelectListItem()
                {
                    Value = t.TournamentID.ToString(),
                    Text = t.Name
                });
        }

        [HttpPost]
        public IActionResult Edit(TournamentEvent tournamentEvent)
        {
            if (ModelState.IsValid)
            {
                repository.SaveTournamentEvent(tournamentEvent);
                TempData["message"] = $"{tournamentEvent.Name} has been saved to database.";
                return RedirectToAction("List");
            }
            else
            {
                return View(tournamentEvent);
            }
        }

        public ViewResult Create()
        {
            GenerateTournamentsSelectList();

            return View("Edit", new TournamentEvent() { StartDate = DateTime.Today, EndDate = DateTime.Today });
        }

        [HttpPost]
        public IActionResult Delete(int tournamentEventID)
        {
            // TODO: tournament events with matches should not be deleted.
            TournamentEvent deletedTournamentEvent = repository.DeleteTournamentEvent(tournamentEventID);
            if (deletedTournamentEvent != null)
            {
                TempData["message"] = $"{deletedTournamentEvent.Name} has been deleted.";
            }
            return RedirectToAction("List");
        }

    }
}
