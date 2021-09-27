using edmi.Models;
using Edmi.Api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edmi.Api.Services
{
    public class GatewayService : IGatewayService
    {
        private readonly IGatewayRepository _gatewayRepository;

        public GatewayService(IGatewayRepository gatewayRepository)
        {
            _gatewayRepository = gatewayRepository;
        }

        public string deleteGateway(string id)
        {
            return _gatewayRepository.deleteGateway(id);
        }

        public Gateway insertGateway(Gateway wm)
        {
            //Retrieving object from DB
            var res = _gatewayRepository.insertGateway(wm).Result;
            return res;
        }

        public List<Gateway> listGateways()
        {
            return _gatewayRepository.listGateways();

        }
    }
}

