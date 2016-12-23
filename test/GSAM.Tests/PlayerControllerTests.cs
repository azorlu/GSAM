using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GSAM.Models;
using GSAM.Controllers;
using Xunit;
using Moq;
using GSAM.Models.ViewModels;

namespace GSAM.Tests
{
    public class PlayerControllerTests
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

        [Fact]
        public void Can_Paginate()
        {
            PlayerController playerController = new PlayerController(GetRepositoryStub());
            playerController.PageSize = 3;

            PlayersListViewModel result = playerController.List(3).ViewData.Model as PlayersListViewModel;

            Player[] players = result.Players.ToArray();
            Assert.True(players.Length == 2); // 2 players in the third page ( 3 + 3 + 2 )
            Assert.Equal(7, players[1].PlayerID); // order by last name then by first name
        }

        [Fact]
        public void Can_Send_Pagination_View_Model()
        {
            PlayerController playerController = new PlayerController(GetRepositoryStub());
            playerController.PageSize = 3;

            PlayersListViewModel result = playerController.List(3).ViewData.Model as PlayersListViewModel;

            PagingInfo pageInfo = result.PagingInfo;
            Assert.Equal(3, pageInfo.CurrentPage);
            Assert.Equal(3, pageInfo.ItemsPerPage);
            Assert.Equal(8, pageInfo.TotalItems);
            Assert.Equal(3, pageInfo.TotalPages);
        }

    }
}
