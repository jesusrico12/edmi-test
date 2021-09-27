using edmi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edmi.Api.Repositories
{
    public interface IElectricMeterRepository
    {
        List<ElectricMeter> listElectricMeters();
        Task<ElectricMeter> insertElectricMeter(ElectricMeter wm);
        string deleteElectricMeter(string id);
    }
}
