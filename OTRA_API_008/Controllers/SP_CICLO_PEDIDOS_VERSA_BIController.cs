using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using OTRA_API_008.Models;
using System.Web.Http;

namespace OTRA_API_008.Controllers
{
    public class SP_CICLO_PEDIDOS_VERSA_BIController : ApiController
    {
        public Newtonsoft.Json.Linq.JArray Get()
        {
            SP_CICLO_PEDIDOS_VERSA_BI SP_CICLO_PEDIDOS_VERSA_BI = new SP_CICLO_PEDIDOS_VERSA_BI();
            JArray result = new JArray();
            result = SP_CICLO_PEDIDOS_VERSA_BI.SP_CICLO_PEDIDOS();
            return result;
        }
    }
}
