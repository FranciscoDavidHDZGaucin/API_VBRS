using OTRA_API_008.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace OTRA_API_008.Controllers
{
    public class VRSVENTAS_YNC__RSGD_2018Controller : ApiController
    {
        [EnableCors(origins: "http://192.168.101.128/", headers: "*", methods: "*")]
        public Newtonsoft.Json.Linq.JArray Get()
        {
            VERSA_VTS_VS_GOPC_SP_2018 OBJETO_VENTAS = new VERSA_VTS_VS_GOPC_SP_2018();



            return OBJETO_VENTAS.Vts_2018();

        }

    }
}