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
    public class VRSVENTAS_YNC__RSGDController : ApiController
    {
        [EnableCors(origins: "http://192.168.101.128/", headers: "*", methods: "*")]
        public Newtonsoft.Json.Linq.JArray Get()
        {
            VERSA_VTS_VS_GOPC_SP OBJETO_VENTAS = new VERSA_VTS_VS_GOPC_SP();



            return OBJETO_VENTAS.CALL_SP_VENTASVRSNC(); 

        }



    }
}
