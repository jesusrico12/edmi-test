using edmi.Models;
using Edmi.Api.Utilities;
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
        private readonly IChecker _checker;
        public ElectricMeterRepository(IConfiguration configuration, IChecker checker)
        {
            _configuration = configuration;
            _checker = checker;
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
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("EdmiDB"));


            if (!_checker.IsUniqueDevice(dbClient, wm)) throw new System.ArgumentException("There is another device with the same serial number.", "Serial Number");

            await dbClient.GetDatabase("EdmiDB").GetCollection<ElectricMeter>("ElectricMeter").InsertOneAsync(wm);

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
