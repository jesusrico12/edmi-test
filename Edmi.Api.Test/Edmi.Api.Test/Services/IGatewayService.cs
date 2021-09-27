using edmi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edmi.Api.Services
{
    public interface IGatewayService
    {
        List<Gateway> listGateways();
        Gateway insertGateway(Gateway wm);
        string deleteGateway(string id);

    }
}
