using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using OTRA_API_008.Models;

namespace OTRA_API_008.Controllers
{
    public class API_GOPC_FECHAS_AUTORIZADASController : ApiController
    {

       
            public Newtonsoft.Json.Linq.JArray Get()
            {
                API_GOPC_FECHAS_AUTORIZADAS INV = new API_GOPC_FECHAS_AUTORIZADAS();
                JArray result = new JArray();
                result = INV.CALL_PLATAFORMA_UNES();
                return result;
            }
        }
}