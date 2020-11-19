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

        [EnableCors(origins: "http://192.168.101.128/", headers: "*", methods: "*")]
        public Newtonsoft.Json.Linq.JArray Get()
        {
            API_GOPC_FECHAS_AUTORIZADAS OBJETO_VENTAS = new API_GOPC_FECHAS_AUTORIZADAS();



            return OBJETO_VENTAS.CALL_PLATAFORMA_UNES();

        }
    }
}