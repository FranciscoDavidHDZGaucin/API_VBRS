using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OTRA_API_008.Controllers
{
    public class BI_PENDIENTES_PLATAFORMAController : ApiController
    {



        public JArray Get(string PENDIENTEPOR)
        {
            Models.api_BI_PEDIDOS_PENDIENTES PENDIENTES = new Models.api_BI_PEDIDOS_PENDIENTES();
            JArray result = new JArray();
            if (PENDIENTEPOR == "PLATAFORMA")
            {
                result = PENDIENTES.PEDIDOS_PENDIENTES_PLATAFORMA();
            }
            if (PENDIENTEPOR == "SAP")
            {
                result = PENDIENTES.PEDIDOS_PENDIENTES_SAP();
            }
            return result;
        }

    }
}
