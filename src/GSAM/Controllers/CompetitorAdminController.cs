using GSAM.Models;
using GSAM.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GSAM.Controllers
{
    public class CompetitorAdminController : Controller
    {
        public ICompetitorRepository repository;
        public ITournamentEventRepository parentRepository;
        public IPlayerRepository playerRepository;
        public int PageSize = 16;

        public CompetitorAdminController(ICompetitorRepository repo, 
            ITournamentEventRepository parentRepo, IPlayerRepository playerRepo)
        {
            repository = repo;
            parentRepository = parentRepo;
            playerRepository = playerRepo;
        }

        [HttpGet]
        public ViewResult List(int tournamentEventID, int page = 1)
        {
            return View(
                 new CompetitorsListViewModel
                 {
                     TournamentEvent = parentRepository.TournamentEvents
                .FirstOrDefault(e => e.TournamentEventID == tournamentEventID),
                     Competitors = repository.Competitors
                .Where(c => c.TournamentEventID == tournamentEventID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                     PagingInfo = new PagingInfo
                     {
                         CurrentPage = page,
                         ItemsPerPage = PageSize,
                         TotalItems = repository.Competitors.Count()
                     }
                 });
        }

        [HttpGet]
        public ViewResult Edit(int competitorID, int tournamentEventID)
        {
            GeneratePlayersSelectList(tournamentEventID);

            Competitor competitor = repository.Competitors.FirstOrDefault(c => c.CompetitorID == competitorID);
            
            return View(competitor);
        }

        [HttpPost]
        public IActionResult Edit(Competitor competitor)
        {
            // TODO :: check if same competitor already exists before editing competitor (remove from list)
            if (ModelState.IsValid)
            {
                repository.SaveCompetitor(competitor);
                TempData["message"] = $"Competitor {competitor.CompetitorID} has been saved to database.";
                return RedirectToAction("List", new { tournamentEventID = competitor.TournamentEventID });
            }
            else
            {
                return View(competitor);
            }
        }

        public ViewResult Create(int tournamentEventID)
        {
            GeneratePlayersSelectList(tournamentEventID);

            return View("Edit", new Competitor()
            {
                TournamentEventID = tournamentEventID,
                TournamentEvent = GetTournamentEvent(tournamentEventID),
                FirstPlayerID = 0,
                SecondPlayerID = 0
            });
        }

        [HttpPost]
        public IActionResult Delete(int competitorID)
        {
            // TODO: competitors with matches should not be deleted.
            Competitor deletedCompetitor = repository.DeleteCompetitor(competitorID);
            if (deletedCompetitor != null)
            {
                TempData["message"] = $"Competitor {deletedCompetitor.CompetitorID} has been deleted.";
            }
            return RedirectToAction("List", new { tournamentEventID = deletedCompetitor.TournamentEventID });
        }

        private void GeneratePlayersSelectList(int tournamentEventID)
        {
            // Filter out player ids already in the competitors list
            var alreadyAdded = GetCompetingPlayerIDs(GetTournamentEvent(tournamentEventID));

            ViewBag.PlayersList = playerRepository.Players
                .Where(p => !alreadyAdded.Contains(p.PlayerID))
                .OrderBy(p => p.FullName)
                .Select(p => new SelectListItem()
                {
                    Value = p.PlayerID.ToString(),
                    Text = $"{p.FullName} ({p.CountryCode})"
                });
        }

        private TournamentEvent GetTournamentEvent(int tournamentEventID)
        {
            return parentRepository.TournamentEvents
                .FirstOrDefault(e => e.TournamentEventID == tournamentEventID);
        }

        private HashSet<int> GetCompetingPlayerIDs(TournamentEvent tournamentEvent)
        {
            var playerIDs = new HashSet<int>();
            foreach(Competitor c in tournamentEvent.Competitors)
            {
                playerIDs.Add(c.FirstPlayerID);
                playerIDs.Add(c.SecondPlayerID);
            }
            return playerIDs;
        }

    }
}
