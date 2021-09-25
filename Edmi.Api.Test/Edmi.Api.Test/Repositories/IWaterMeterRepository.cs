using edmi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edmi.Api.Repositories
{
    public interface IWaterMeterRepository
    {
        List<WaterMeter> listWaterMeters();
        string insertWaterMeter(WaterMeter wm);
        string deleteWaterMeter(string id);
    }
}
