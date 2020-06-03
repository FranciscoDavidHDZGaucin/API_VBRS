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
    public class VWINVENTARIOController : ApiController
    {

        [EnableCors(origins: "http://192.168.101.128/", headers: "*", methods: "*")]
        public Newtonsoft.Json.Linq.JArray Get()
        {
            vw_INVENTARIO OBJETO_INVNETARIO = new vw_INVENTARIO();



            return OBJETO_INVNETARIO.VWINVENTARIO();

        }


    }
}
