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

namespace OTRA_API_008.Models
{
    public class FECHA_AUTORIZADASController : ApiController
    {

        [EnableCors(origins: "http://192.168.101.128/", headers: "*", methods: "*")]
        public Newtonsoft.Json.Linq.JArray Get()
        {
            FECHAS_AUTORIZADAS_RSGD OBJETO_VENTAS = new FECHAS_AUTORIZADAS_RSGD();



            return OBJETO_VENTAS.CALL_PLATAFORMA_UNES();

        }





    }



}
