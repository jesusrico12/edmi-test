using edmi.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edmi.Api.Repositories
{
    public class ElectricMeterRepository : IElectricMeterRepository
    {
        private readonly IConfiguration _configuration;

        public ElectricMeterRepository(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        public string deleteElectricMeter(string id)
        {
            string res = "";
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("EdmiDB"));

            var wmDB = Builders<ElectricMeter>.Filter.Eq("Id", id);

            dbClient.GetDatabase("EdmiDB").GetCollection<ElectricMeter>("ElectricMeter").DeleteOne(wmDB);

            res = "Deleted succesfully";

            return res;
        }

        public async Task<ElectricMeter> insertElectricMeter(ElectricMeter wm)
        {
            string res = "";
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("EdmiDB"));

            Boolean existDevices = dbClient.GetDatabase("EdmiDB").GetCollection<ElectricMeter>("ElectricMeter").Find(x => x.serialNumber == wm.serialNumber).Any();


            //if (existDevices) return "There is another device with the same serial number.";

            await dbClient.GetDatabase("EdmiDB").GetCollection<ElectricMeter>("ElectricMeter").InsertOneAsync(wm);

            res = "Insertion succesfully";

            return wm;

        }

        public List<ElectricMeter> listElectricMeters()
        {

            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("EdmiDB"));

            var dbList = dbClient.GetDatabase("EdmiDB").GetCollection<ElectricMeter>("ElectricMeter").AsQueryable().ToList();

            return dbList;
        }
    }
}
