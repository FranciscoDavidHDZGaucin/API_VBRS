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
    public class PLATAFORMA_EST_UNESController : ApiController
    {
        [EnableCors(origins: "http://192.168.101.128/", headers: "*", methods: "*")]
        public Newtonsoft.Json.Linq.JArray Get()
        {
            PLATFORMA_UNES obj_plat  = new PLATFORMA_UNES();



            return obj_plat.CALL_PLATAFORMA_UNES();

        }
    }
}
