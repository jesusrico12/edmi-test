using edmi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edmi.Api.Services
{
    public interface IElectricMeterService
    {
        List<ElectricMeter> listElectricMeters();
        ElectricMeter insertElectricMeter(ElectricMeter wm);
        string deleteElectricMeter(string id);
    }
}
