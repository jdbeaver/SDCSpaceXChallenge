using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using SpaceXSolution.Controllers;
using SpaceXSolution.Infrastructure;
using SpaceXSolution.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace XSpaceXSolution.Tests
{
    public class TestSpaceXLaunchPadController
    {
        private readonly SpaceXLaunchPadController _controller;
        private readonly ILogger _logger;
        //IShoppingCartService _service;


        public TestSpaceXLaunchPadController()
        {
            //_service = new ShoppingCartServiceFake();
            //_controller = new SpaceXLaunchPadController(;
        }

        [Fact]
        public async Task Get_ReturnsAllValues()
        {
            // Arrange
            SpaceXLaunchPadFilter filter = new SpaceXLaunchPadFilter()
            {
                Limit = "0",
                Status = "all"
            };
            var mockRepo = new Mock<ISpaceXLaunchPadData>();
            //mock the data returned by GetDataAsync
            mockRepo.Setup(rep => rep.GetDataAsync(filter))
                .ReturnsAsync(GetTestData());
            //mock the logger
            var mock = new Mock<ILoggerFactory>();
            ILoggerFactory logger = mock.Object;



            var controller = new SpaceXLaunchPadController(logger, mockRepo.Object);

            // Act
            IActionResult getresult = await controller.GetLPInfo(filter);

            // Assert
            Assert.NotNull(getresult);
            ObjectResult result = getresult as ObjectResult;
            Assert.NotNull(result);
            var resultlist = result.Value as List<SDCLaunchPadInfo>;
            Assert.NotNull(resultlist);
            Assert.Same("vafb_slc_3w", resultlist[0].Id);
            Assert.Same("ccafs_slc_40", resultlist[1].Id);
            Assert.Same("Vandenberg Air Force Base Space Launch Complex 3W", resultlist[0].Full_name);
            Assert.Same("Cape Canaveral Air Force Station Space Launch Complex 40", resultlist[1].Full_name);
            Assert.Same("retired", resultlist[0].Status);
            Assert.Same("active", resultlist[1].Status);
        }

        private List<SpaceXLaunchPad> GetTestData()
        {
            var testData = new List<SpaceXLaunchPad>();
            testData.Add(new SpaceXLaunchPad()
            {
                Padid = 5,
                Id = "vafb_slc_3w",
                Full_name = "Vandenberg Air Force Base Space Launch Complex 3W",
                Name = "VAFB SLC 3W",
                Status = "retired",
                Location = new Location()
                {
                    Name = "Vandenberg Air Force Base",
                    Latitude = 34.6440904,
                    Longitude = -120.59314380000001,
                    Region = "California"
                },
                Vehicles_launched = new List<string>() { "Falcon 1" },
                Attempted_launches = 0,
                Successful_launches = 0,
                Wikipedia = "https://en.wikipedia.org/wiki/Vandenberg_AFB_Space_Launch_Complex_3",
                Details = "SpaceX original west coast launch pad for Falcon 1. Performed a static fire but was never used for a launch and abandoned due to scheduling conflicts."
            });
            testData.Add(new SpaceXLaunchPad()
            {
                Padid = 2,
                Id = "ccafs_slc_40",
                Full_name = "Cape Canaveral Air Force Station Space Launch Complex 40",
                Name = "CCAFS SLC 40",
                Status = "active",
                Location = new Location()
                {
                    Name = "Cape Canaveral",
                    Latitude = 28.5618571,
                    Longitude = -80.577366,
                    Region = "Florida"
                },
                Vehicles_launched = new List<string>() { "Falcon 9" },
                Attempted_launches = 45,
                Successful_launches = 43,
                Wikipedia = "https://en.wikipedia.org/wiki/Cape_Canaveral_Air_Force_Station_Space_Launch_Complex_40",
                Details = "SpaceX primary Falcon 9 launch pad, where all east coast Falcon 9s launched prior to the AMOS-6 anomaly. Initially used to launch Titan rockets for Lockheed Martin. Back online since CRS-13 on 2017-12-15."
            });

            return testData;
        }
    }
}
