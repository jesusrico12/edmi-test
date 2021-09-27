using System;
using System.Collections.Generic;
using System.Text;
using edmi.Models;
using Edmi.Api.Repositories;
using Edmi.Unit.Test.Stubs;
using Moq;
namespace Edmi.Unit.Test.MockRepository
{
    public class WaterMeterRepositoryMock
    {
        public Mock<IWaterMeterRepository> _wateMeterRepository { get; set; }

        public WaterMeterRepositoryMock() {
            _wateMeterRepository = new Mock<IWaterMeterRepository>();
            SetUp();
        }

        private void SetUp() {

            _wateMeterRepository.Setup((x) => x.insertWaterMeter(It.IsAny<WaterMeter>())).ReturnsAsync(WaterMeterStub.wm3);
            _wateMeterRepository.Setup((x) => x.listWaterMeters()).Returns(WaterMeterStub.wmList);
        }
    }
}
