using edmi.Models;
using Edmi.Api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edmi.Api.Services
{
    public class ElectricMeterService : IElectricMeterService
    {
        private readonly IElectricMeterRepository _electricMeterRepository;

    public ElectricMeterService(IElectricMeterRepository electricMeterRepository)
    {
        _electricMeterRepository = electricMeterRepository;
    }

    public string deleteElectricMeter(string id)
    {
        return _electricMeterRepository.deleteElectricMeter(id);
    }

    public ElectricMeter insertElectricMeter(ElectricMeter wm)
    {
        //Retrieving object from DB
        var res = _electricMeterRepository.insertElectricMeter(wm).Result;
        return res;
    }

    public List<ElectricMeter> listElectricMeters()
    {
        return _electricMeterRepository.listElectricMeters();

    }
}
}
