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
    public class GatewayController : ControllerBase
    {
        private readonly IConfiguration _configuration;


        public GatewayController(IConfiguration configuration) {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("EdmiDB"));

            var dbList = dbClient.GetDatabase("EdmiDB").GetCollection<Gateway>("Gateway").AsQueryable().ToList();


            
            return new JsonResult(dbList);
        }

        [HttpPost]
        public JsonResult Post([FromBody]Gateway wm)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("EdmiDB"));

            Boolean existDevices = dbClient.GetDatabase("EdmiDB").GetCollection<Gateway>("Gateway").Find(x=>x.serialNumber == wm.serialNumber).Any();

            
            if(existDevices) return new JsonResult("There is another device with the same serial number.");
            
            dbClient.GetDatabase("EdmiDB").GetCollection<Gateway>("Gateway").InsertOne(wm);

            return new JsonResult("Insertion succesfully");
        }

        [HttpDelete("{Id}")]
        public JsonResult Delete(string Id)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("EdmiDB"));

            var wmDB = Builders<Gateway>.Filter.Eq("Id",Id);
            //Añadir excepcion si no existe el Id

            dbClient.GetDatabase("EdmiDB").GetCollection<Gateway>("Gateway").DeleteOne(wmDB);

            return new JsonResult("Deleted succesfully");
        }
    }
}
