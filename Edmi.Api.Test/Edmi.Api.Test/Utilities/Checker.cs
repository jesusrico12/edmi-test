using edmi.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edmi.Api.Utilities
{
    public class Checker:IChecker
    {
        public Checker()
        {
        }

        public Boolean IsUniqueDevice(MongoClient dbClient, Device d)
        {
            Boolean existWM = dbClient.GetDatabase("EdmiDB").GetCollection<WaterMeter>("WaterMeter").Find(x => x.serialNumber == d.serialNumber).Any();
            Boolean existEM = dbClient.GetDatabase("EdmiDB").GetCollection<ElectricMeter>("ElectricMeter").Find(x => x.serialNumber == d.serialNumber).Any();
            Boolean existG = dbClient.GetDatabase("EdmiDB").GetCollection<Gateway>("Gateway").Find(x => x.serialNumber == d.serialNumber).Any();

            if (existWM || existEM || existG) {
                return false;
            }

            return true;
        }
    }
}
