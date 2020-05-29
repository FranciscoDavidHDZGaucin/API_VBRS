using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using OTRA_API_008.Models;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace OTRA_API_008.Controllers
{
    public class Prueba_DAVIDVTS_VS_GOPCController : ApiController
    {
        public JArray Get()
        {
            apiPRUEBAVTS_VS_GOPC VTSFECHA = new apiPRUEBAVTS_VS_GOPC();
            JArray result = new JArray();
            
            result = VTSFECHA.VTS_COMPARATIVA();
            return result;
        }
    }
}