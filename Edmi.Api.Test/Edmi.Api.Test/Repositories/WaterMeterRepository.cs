using edmi.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Edmi.Api.Utilities;
namespace Edmi.Api.Repositories
{
    public class WaterMeterRepository : IWaterMeterRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IChecker _checker;

        public WaterMeterRepository(IConfiguration configuration, IChecker checker)
        {
            _configuration = configuration;
            _checker = checker;
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

        public async Task<WaterMeter> insertWaterMeter(WaterMeter wm)
        {
            
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("EdmiDB"));

            if (!_checker.IsUniqueDevice(dbClient,wm)) throw new System.ArgumentException("There is another device with the same serial number.", "Serial Number"); 

            await dbClient.GetDatabase("EdmiDB").GetCollection<WaterMeter>("WaterMeter").InsertOneAsync(wm);


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
