using edmi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edmi.Api.Repositories
{
    public interface IGatewayRepository
    {
        List<Gateway> listGateways();
        Task<Gateway> insertGateway(Gateway wm);
        string deleteGateway(string id);
    }
}
