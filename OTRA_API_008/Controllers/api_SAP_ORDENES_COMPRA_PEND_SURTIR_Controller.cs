using System;
using System.Collections.Generic;
using OTRA_API_008.Models;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Data.SqlClient;

namespace OTRA_API_008.Controllers
{
    public class api_SAP_ORDENES_COMPRA_PEND_SURTIR_Controller : ApiController
    {

        public Newtonsoft.Json.Linq.JArray Get()
        {
            api_SAP_ORDENES_COMPRA_PEND_SURTIR REPOR = new api_SAP_ORDENES_COMPRA_PEND_SURTIR();
            JArray result = new JArray();
            result = REPOR.ORDENES_COMPRA();
            return result;
        }
    }
}