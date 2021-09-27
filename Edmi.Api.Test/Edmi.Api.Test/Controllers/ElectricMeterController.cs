using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using edmi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Edmi.Api.Services;

namespace edmi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElectricMeterController : ControllerBase
    {
        private readonly IElectricMeterService _electricMeterService;

        public ElectricMeterController(IElectricMeterService electricMeterService)
        {
            _electricMeterService = electricMeterService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<ElectricMeter> wms = null;
            try
            {
                wms = _electricMeterService.listElectricMeters();
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            return new JsonResult(wms);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ElectricMeter wm)
        {
            ElectricMeter res = null;
            try
            {
                res = _electricMeterService.insertElectricMeter(wm);
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            return new JsonResult(res);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(string Id)
        {
            string res = "";
            try
            {
                res = _electricMeterService.deleteElectricMeter(Id);
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            return new JsonResult(res);

        }
    }
}