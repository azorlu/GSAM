using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Moq;
using GSAM.Models.ViewModels;
using GSAM.Models;
using GSAM.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace GSAM.Tests
{
    public class TournamentControllerTests
    {
        public ITournamentRepository GetRepositoryStub()
        {
            Mock<ITournamentRepository> mock = new Mock<ITournamentRepository>();
            mock.Setup(m => m.Tournaments).Returns(new Tournament[]
            {
                new Tournament {TournamentID = 1, Name = "Championship A", Category = "A" },
                new Tournament {TournamentID = 2, Name = "Championship B", Category = "A" },
                new Tournament {TournamentID = 3, Name = "Championship C", Category = "A" },
                new Tournament {TournamentID = 4, Name = "Championship X", Category = "B" },
                new Tournament {TournamentID = 5, Name = "Championship Y", Category = "C" },
                new Tournament {TournamentID = 6, Name = "Championship Z", Category = "C" }
            });

            return mock.Object;
        }

        [Fact]
        public void Can_Paginate()
        {
            TournamentController tournamentController = new TournamentController(GetRepositoryStub());
            tournamentController.PageSize = 2;

            TournamentsListViewModel result = tournamentController.List(null, 3).ViewData.Model as TournamentsListViewModel;

            Tournament[] tournaments = result.Tournaments.ToArray();
            Assert.True(tournaments.Length == 2); // 2 tournaments in the third page ( 2 + 2 + 2 )
            Assert.Equal(5, tournaments[0].TournamentID); // order by tournament name
        }

        [Fact]
        public void Can_Send_Pagination_View_Model()
        {
            TournamentController tournamentController = new TournamentController(GetRepositoryStub());
            tournamentController.PageSize = 2;

            TournamentsListViewModel result = tournamentController.List(null, 3).ViewData.Model as TournamentsListViewModel;

            PagingInfo pageInfo = result.PagingInfo;
            Assert.Equal(3, pageInfo.CurrentPage);
            Assert.Equal(2, pageInfo.ItemsPerPage);
            Assert.Equal(6, pageInfo.TotalItems);
            Assert.Equal(3, pageInfo.TotalPages);
        }

        [Fact]
        public void Can_Filter_Tournaments()
        {
            TournamentController tournamentController = new TournamentController(GetRepositoryStub());
            tournamentController.PageSize = 2;

            TournamentsListViewModel result = tournamentController.List("C", 1).ViewData.Model as TournamentsListViewModel;

            Tournament[] tournaments = result.Tournaments.ToArray();
            Assert.True(tournaments.Length == 2); // 2 tournaments in the "C" category
            Assert.True(tournaments[0].TournamentID == 5 && tournaments[0].Category == "C");
            Assert.True(tournaments[1].TournamentID == 6 && tournaments[0].Category == "C");
        }

        [Fact]
        public void Can_Generate_Category_Specific_Tournament_Count()
        {
            TournamentController tournamentController = new TournamentController(GetRepositoryStub());
            tournamentController.PageSize = 2;

            Func<ViewResult, TournamentsListViewModel> GetModel = result => result?.ViewData?.Model as TournamentsListViewModel;
  
            int? count1 = GetModel(tournamentController.List("A"))?.PagingInfo.TotalItems;
            int? count2 = GetModel(tournamentController.List("B"))?.PagingInfo.TotalItems;
            int? count3 = GetModel(tournamentController.List("C"))?.PagingInfo.TotalItems;
            int? countAll = GetModel(tournamentController.List(null))?.PagingInfo.TotalItems;
            // Assert
            Assert.Equal(3, count1);
            Assert.Equal(1, count2);
            Assert.Equal(2, count3);
            Assert.Equal(6, countAll);
        }

    }
}
