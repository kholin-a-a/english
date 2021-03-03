using English.BusinessLogic;
using English.WebApi.Controllers;
using English.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace English.WebApi.Tests.Controllers
{
    public class StatsControllerTests
    {
        private readonly Mock<IQueryService<GetUserStatsQuery, UserStats>> _statsQueryMock;

        public StatsControllerTests()
        {
            this._statsQueryMock = new Mock<IQueryService<GetUserStatsQuery, UserStats>>();
        }

        [Fact]
        public async Task GetStats_Default_OkObjectResult()
        {
            var controller = this.MakeController();

            var actionResult = await controller.GetStats();

            Assert.IsType<OkObjectResult>(actionResult.Result);
        }

        [Fact]
        public async Task GetStats_Default_ReturnsUserStats()
        {
            // Setup
            var controller = this.MakeController();

            var userStats = new UserStats
            {
                TotalLessons = 123
            };

            this._statsQueryMock.Setup(m =>
                    m.ExecuteAsync(It.IsAny<GetUserStatsQuery>())
                )
                .ReturnsAsync(userStats);

            // Action
            var actionResult = await controller.GetStats();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var stats = Assert.IsType<StatsOuputModel>(okResult.Value);

            Assert.Equal(userStats.TotalLessons, stats.TotalLessons);
        }

        private StatsController MakeController()
        {
            this._statsQueryMock.Setup(m =>
                    m.ExecuteAsync(It.IsAny<GetUserStatsQuery>())
                )
                .ReturnsAsync(
                    new UserStats()
                );

            return new StatsController(
                this._statsQueryMock.Object
                );
        }
    }
}
