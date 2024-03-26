using FootballClubBadgeAPI.Controllers;
using FootballClubBadgeAPI.Interfaces;
using System;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FootballClubBadgeAPI.Tests
{
    public class BadgeControllerTests
    {

        private readonly BadgeController _badgeController;
        private readonly Mock<IImageStorageService> _imageStorageService;


        public BadgeControllerTests()
        {

            _imageStorageService = new Mock<IImageStorageService>();
            _badgeController = new BadgeController(_imageStorageService.Object);
            
        }

        [Fact]
        public void GetTeams_ReturnsList()
        {

            //Arrange

            _imageStorageService.Setup(service => service.GetTeamBadgeFilenamesAsync())
                .Returns(new string[] { "Derby County", "Sheffield Wednesday" });

            //Act

            var result = _badgeController.GetTeams();

            //Assert

            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;

            Assert.NotNull(okResult.Value);
            Assert.Equal(new string[] { "Derby County", "Sheffield Wednesday" }, okResult.Value);


        } 
    }
}
