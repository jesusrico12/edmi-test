using edmi.Models;
using Edmi.Api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edmi.Api.Services
{
    public class WaterMeterService : IWaterMeterService
    {
        private readonly IWaterMeterRepository _waterMeterRepository;

        public WaterMeterService(IWaterMeterRepository waterMeterRepository)
        {
            _waterMeterRepository = waterMeterRepository;
        }

        public string deleteWaterMeter(string id)
        {
            return _waterMeterRepository.deleteWaterMeter(id);
        }

        public WaterMeter insertWaterMeter(WaterMeter wm)
        {
            var res =  _waterMeterRepository.insertWaterMeter(wm).Result;
            return res;
        }

        public List<WaterMeter> listWaterMeters()
        {
           return _waterMeterRepository.listWaterMeters();
            
        }
    }
}
