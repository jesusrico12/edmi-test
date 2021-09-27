using edmi.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edmi.Api.Utilities
{
    public interface IChecker
    {

        Boolean IsUniqueDevice(MongoClient dbClient, Device d);
    }
}
