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
    public class GatewayController : ControllerBase
    {
        private readonly IGatewayService _gatewayService;

        public GatewayController(IGatewayService gatewayService)
        {
            _gatewayService = gatewayService;
        }

        [HttpGet]
        public JsonResult Get()
        {
            List<Gateway> wms = null;
            try
            {
                wms = _gatewayService.listGateways();
            }
            catch (Exception e)
            {

            }
            return new JsonResult(wms);
        }

        [HttpPost]
        public JsonResult Post([FromBody] Gateway wm)
        {
            Gateway res = null;
            try
            {
                res = _gatewayService.insertGateway(wm);
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
                res = _gatewayService.deleteGateway(Id);
            }
            catch (Exception e)
            {

            }
            return new JsonResult(res);

        }
    }
}
