using edmi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Edmi.Unit.Test.Stubs
{
    public static class WaterMeterStub
    {
        public static WaterMeter wm1 = new WaterMeter()
        {
            Id = "123qe2",
            serialNumber = "2834-ydgs",
            firmwareVersion = "12.1",
            state = "Enabled"
        };
        public static WaterMeter wm2 = new WaterMeter()
        {
            Id = "123qe21",
            serialNumber = "283224-ypps",
            firmwareVersion = "12.1.2",
            state = "Disabled"
        };

        public static WaterMeter wm3 = new WaterMeter()
        {
            Id = "1234",
            serialNumber = "224-123",
            firmwareVersion = null,
            state = "Enabled"
        };

        public static List<WaterMeter> wmList = new List<WaterMeter>() { wm1, wm2 };
    }
}
