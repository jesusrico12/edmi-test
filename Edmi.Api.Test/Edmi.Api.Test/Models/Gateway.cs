using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace edmi.Models
{
    public class Gateway : Device
    {
       public string Ip { get; set; }
       public int port { get; set; }

    }
}
