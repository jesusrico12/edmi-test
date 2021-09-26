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
        public JsonResult Get()
        {
            List<WaterMeter> wms = null;
            try
            {
                 wms =_waterMeterService.listWaterMeters();
            }
            catch (Exception e) { 
            
            }
            return new JsonResult(wms);
        }

        [HttpPost]
        public JsonResult Post([FromBody]WaterMeter wm)
        {
            WaterMeter res = null;
            try
            {
                res = _waterMeterService.insertWaterMeter(wm);
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
                res = _waterMeterService.deleteWaterMeter(Id);
            }
            catch (Exception e)
            {

            }
            return new JsonResult(res);

        }
    }
}
