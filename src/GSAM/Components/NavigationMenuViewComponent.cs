using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GSAM.Models;

namespace GSAM.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private ITournamentRepository repository;

        public NavigationMenuViewComponent(ITournamentRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.Tournaments
            .Select(t => t.Category)
            .Distinct()
            .OrderBy(t => t));
        }
    }
}
