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
        public JsonResult Get()
        {
            List<ElectricMeter> wms = null;
            try
            {
                wms = _electricMeterService.listElectricMeters();
            }
            catch (Exception e)
            {

            }
            return new JsonResult(wms);
        }

        [HttpPost]
        public JsonResult Post([FromBody] ElectricMeter wm)
        {
            ElectricMeter res = null;
            try
            {
                res = _electricMeterService.insertElectricMeter(wm);
            }
            catch (Exception e)
            {

            }
            return new JsonResult(res);
        }

        [HttpDelete("{Id}")]
        public JsonResult Delete(string Id)
        {
            string res = "";
            try
            {
                res = _electricMeterService.deleteElectricMeter(Id);
            }
            catch (Exception e)
            {

            }
            return new JsonResult(res);

        }
    }
}