using edmi.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edmi.Api.Repositories
{
    public class WaterMeterRepository : IWaterMeterRepository
    {
        private readonly IConfiguration _configuration;

        public WaterMeterRepository(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        public string deleteWaterMeter(string id)
        {
            string res = "";
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("EdmiDB"));

            var wmDB = Builders<WaterMeter>.Filter.Eq("Id", id);

            dbClient.GetDatabase("EdmiDB").GetCollection<WaterMeter>("WaterMeter").DeleteOne(wmDB);

            res = "Deleted succesfully";

            return res;
        }

        //public string insertWaterMeter(WaterMeter wm)
        public async Task<WaterMeter> insertWaterMeter(WaterMeter wm)
        {
            string res = "";
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("EdmiDB"));

            Boolean existDevices = dbClient.GetDatabase("EdmiDB").GetCollection<WaterMeter>("WaterMeter").Find(x => x.serialNumber == wm.serialNumber).Any();


            //if (existDevices) return "There is another device with the same serial number.";

            await dbClient.GetDatabase("EdmiDB").GetCollection<WaterMeter>("WaterMeter").InsertOneAsync(wm);

            res = "Insertion succesfully";

            return wm;

        }

        public List<WaterMeter> listWaterMeters()
        {

            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("EdmiDB"));

            var dbList = dbClient.GetDatabase("EdmiDB").GetCollection<WaterMeter>("WaterMeter").AsQueryable().ToList();
            
            return dbList;
        }
    }
}
