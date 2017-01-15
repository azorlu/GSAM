using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GSAM.Models;
using GSAM.Controllers;
using Xunit;
using Moq;
using GSAM.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace GSAM.Tests
{
    public class PlayerAdminControllerTests
    {
        public IPlayerRepository GetRepositoryStub()
        {
            Mock<IPlayerRepository> mock = new Mock<IPlayerRepository>();
            mock.Setup(m => m.Players).Returns(new Player[]
            {
                new Player {PlayerID = 1, FirstName = "Amelia", LastName = "Berry", Gender = false,  CountryCode = "UK", DateOfBirth = new DateTime(1990, 1, 15) },
                new Player {PlayerID = 2, FirstName = "Irene", LastName = "Mills", Gender = false,  CountryCode = "CAN", DateOfBirth = new DateTime(1994, 7, 25) },
                new Player {PlayerID = 3, FirstName = "Abigail", LastName = "Clarkson", Gender = false,  CountryCode = "UK", DateOfBirth = new DateTime(1994, 9, 5) },
                new Player {PlayerID = 4, FirstName = "John", LastName = "Oliver", Gender = true,  CountryCode = "UK", DateOfBirth = new DateTime(1993, 12, 30) },
                new Player {PlayerID = 5, FirstName = "Evan", LastName = "Dyer", Gender = true,  CountryCode = "UK", DateOfBirth = new DateTime(1991, 8, 20) },
                new Player {PlayerID = 6, FirstName = "Dorothy", LastName = "Graham", Gender = false,  CountryCode = "UK", DateOfBirth = new DateTime(1995, 11, 10) },
                new Player {PlayerID = 7, FirstName = "Leonard", LastName = "Young", Gender = true,  CountryCode = "USA", DateOfBirth = new DateTime(1992, 2, 15) },
                new Player {PlayerID = 8, FirstName = "Joe", LastName = "Young", Gender = true,  CountryCode = "USA", DateOfBirth = new DateTime(1992, 2, 15) }
            });

            return mock.Object;
        }

        private T GetViewModel<T>(IActionResult result) where T : class
        {
            return (result as ViewResult)?.ViewData.Model as T;
        }

        [Fact]
       public void List_Contains_All_Players()
        {
            PlayerAdminController playerAdminController = new PlayerAdminController(GetRepositoryStub());
            playerAdminController.PageSize = 8;

            PlayersListViewModel result = playerAdminController.List(1).ViewData.Model as PlayersListViewModel;

            Player[] players = result.Players.ToArray();
            Assert.True(players.Length == 8); // 8 players in the first page
        }

        [Fact]
        public void Can_Edit_Player()
        {
            Player p = new Player { PlayerID = 1, FirstName = "Amelia", LastName = "Berry", Gender = false, CountryCode = "UK", DateOfBirth = new DateTime(1990, 1, 15) };

            Mock<IPlayerRepository> mock = new Mock<IPlayerRepository>();
            mock.Setup(m => m.Players).Returns(new Player[] { p });

            PlayerAdminController target = new PlayerAdminController(mock.Object);

            target.Edit(p.PlayerID);

            mock.Verify(m => m.FindPlayerByID(p.PlayerID));
        }

        [Fact]
        public void Cannot_Edit_NonExistent_Player()
        {
            PlayerAdminController playerAdminController = new PlayerAdminController(GetRepositoryStub());
            playerAdminController.PageSize = 8;

            Player player100 = GetViewModel<Player>(playerAdminController.Edit(100));

            Assert.Null(player100);
        }

        [Fact]
        public void Can_Save_Valid_Changes()
        {
            
            Mock<IPlayerRepository> mock = new Mock<IPlayerRepository>();
            
            Mock<ITempDataDictionary> tempData = new Mock<ITempDataDictionary>();
           
            PlayerAdminController target = new PlayerAdminController(mock.Object)
            {
                TempData = tempData.Object
            };
            
            Player player = new Player { FirstName = "Test" };
            
            IActionResult result = target.Edit(player);
            
            mock.Verify(m => m.SavePlayer(player));
            
            Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("List", (result as RedirectToActionResult).ActionName);
        }

        [Fact]
        public void Cannot_Save_Invalid_Changes()
        {
            
            Mock<IPlayerRepository> mock = new Mock<IPlayerRepository>();
            
            PlayerAdminController target = new PlayerAdminController(mock.Object);
            
            Player player = new Player { FirstName = "Test" };
           
            target.ModelState.AddModelError("error", "error");
            
            IActionResult result = target.Edit(player);
           
            mock.Verify(m => m.SavePlayer(It.IsAny<Player>()), Times.Never());
           
            Assert.IsType<ViewResult>(result);
        }

        public void Can_Delete_Player()
        {
            Player p = new Player { PlayerID = 1, FirstName = "Amelia", LastName = "Berry", Gender = false, CountryCode = "UK", DateOfBirth = new DateTime(1990, 1, 15) };

            Mock<IPlayerRepository> mock = new Mock<IPlayerRepository>();
            mock.Setup(m => m.Players).Returns(new Player[] { p });

            PlayerAdminController target = new PlayerAdminController(mock.Object);

            target.Delete(p.PlayerID);

            mock.Verify(m => m.DeletePlayer(p.PlayerID));
        }

    }
}
