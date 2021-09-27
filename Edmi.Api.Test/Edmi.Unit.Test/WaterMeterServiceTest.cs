using edmi.Models;
using Edmi.Api.Repositories;
using Edmi.Api.Services;
using Edmi.Unit.Test.MockRepository;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace Edmi.Unit.Test
{
    [TestClass]
    public class WaterMeterServiceTest
    {
        private static IWaterMeterService _waterMeterService;

        [ClassInitialize()]
        public static void SetUp(TestContext context) {

            Mock<IWaterMeterRepository> _waterMeterRepository = new WaterMeterRepositoryMock()._wateMeterRepository;

            _waterMeterService = new WaterMeterService(_waterMeterRepository.Object);
        }
        [TestMethod]
        public void listWaterMeterTest()
        {
            //Arrange
            WaterMeter wm = new WaterMeter();
            //Act
            var result =  _waterMeterService.listWaterMeters();
            //Assert
            result.Should().NotBeNullOrEmpty();
            result.Should().HaveCountGreaterOrEqualTo(1);
        }
        [TestMethod]
        public void inserWaterMeterTest()
        {
            //Arrange
            WaterMeter wm1 = new WaterMeter();
            //Act
            var result = _waterMeterService.insertWaterMeter(wm1);
            //Assert
            result.serialNumber.Equals("224-123");
            result.state.Equals("Enabled");
            result.firmwareVersion.Should().BeNull();
            result.Id.Should().NotBeNull();

        }
    }
}
