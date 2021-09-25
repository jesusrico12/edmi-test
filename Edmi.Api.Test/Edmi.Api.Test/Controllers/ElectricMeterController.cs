using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using edmi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace edmi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElectricMeterController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ElectricMeterController(IConfiguration configuration) {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("EdmiDB"));

            var dbList = dbClient.GetDatabase("EdmiDB").GetCollection<ElectricMeter>("ElectricMeter").AsQueryable().ToList();


            
            return new JsonResult(dbList);
        }

        [HttpPost]
        public JsonResult Post([FromBody]ElectricMeter wm)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("EdmiDB"));

            Boolean existDevices = dbClient.GetDatabase("EdmiDB").GetCollection<ElectricMeter>("ElectricMeter").Find(x=>x.serialNumber == wm.serialNumber).Any();

            
            if(existDevices) return new JsonResult("There is another device with the same serial number.");
            
            dbClient.GetDatabase("EdmiDB").GetCollection<ElectricMeter>("ElectricMeter").InsertOne(wm);

            return new JsonResult("Insertion succesfully");
        }

        [HttpDelete("{Id}")]
        public JsonResult Delete(string Id)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("EdmiDB"));

            var wmDB = Builders<ElectricMeter>.Filter.Eq("Id",Id);
            //Añadir excepcion si no existe el Id

            dbClient.GetDatabase("EdmiDB").GetCollection<ElectricMeter>("ElectricMeter").DeleteOne(wmDB);

            return new JsonResult("Deleted succesfully");
        }
    }
}
