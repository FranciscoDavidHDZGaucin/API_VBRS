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
    public class api_PARTICIPACION_CULTIVOSController : ApiController
    {

        public Newtonsoft.Json.Linq.JArray Get()
        {
            api_PARTICIPACION_CULTIVOS TB = new api_PARTICIPACION_CULTIVOS();
            JArray result = new JArray();
            result = TB.REPORTE();
            return result;
        }
    }
}