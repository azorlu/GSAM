using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Moq;
using GSAM.Components;
using GSAM.Models;
using Xunit;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;

namespace GSAM.Tests
{
    public class NavigationMenuViewComponentTests
    {
        public ITournamentRepository GetRepositoryStub()
        {
            Mock<ITournamentRepository> mock = new Mock<ITournamentRepository>();
            mock.Setup(m => m.Tournaments).Returns(new Tournament[]
            {
                new Tournament {TournamentID = 1, Name = "Championship A", Category = "M" },
                new Tournament {TournamentID = 2, Name = "Championship B", Category = "M" },
                new Tournament {TournamentID = 3, Name = "Championship C", Category = "K" },
                new Tournament {TournamentID = 4, Name = "Championship X", Category = "L" },
                new Tournament {TournamentID = 5, Name = "Championship Y", Category = "L" },
                new Tournament {TournamentID = 6, Name = "Championship Z", Category = "L" }
            });

            return mock.Object;
        }

        [Fact]
        public void Can_Select_Categories()
        {
            NavigationMenuViewComponent target = new NavigationMenuViewComponent(GetRepositoryStub());

            string[] result = ((IEnumerable<string>)(target.Invoke() as ViewViewComponentResult).ViewData.Model).ToArray();

            Assert.True(Enumerable.SequenceEqual(new string[] { "K", "L", "M" }, result));
        }

        [Fact]
        public void Indicates_Selected_Category()
        {
            
            string selectedCategory = "M";
            NavigationMenuViewComponent target = new NavigationMenuViewComponent(GetRepositoryStub());
            target.ViewComponentContext = new ViewComponentContext
            {
                ViewContext = new ViewContext
                {
                    RouteData = new RouteData()
                }
            };
            target.RouteData.Values["category"] = selectedCategory;
            
            string result = (string)(target.Invoke() as ViewViewComponentResult).ViewData["SelectedCategory"]; // ViewBag.SelectedCategory
            
            Assert.Equal(selectedCategory, result);
        }

    }
}
