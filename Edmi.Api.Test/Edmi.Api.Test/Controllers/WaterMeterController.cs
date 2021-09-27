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
using Microsoft.AspNetCore.Authorization;
using System.Net;

namespace edmi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WaterMeterController : ControllerBase
    {
        private readonly IWaterMeterService _waterMeterService;

        public WaterMeterController(IWaterMeterService waterMeterService) {
            _waterMeterService = waterMeterService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<WaterMeter> wms = null;
            try
            {
                wms =_waterMeterService.listWaterMeters();
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            return new JsonResult(wms);
        }

        [HttpPost]
        public IActionResult Post([FromBody]WaterMeter wm)
        {
            WaterMeter res = null;
            try
            {
                res = _waterMeterService.insertWaterMeter(wm);
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
                res = _waterMeterService.deleteWaterMeter(Id);
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            return new JsonResult(res);

        }
    }
}
