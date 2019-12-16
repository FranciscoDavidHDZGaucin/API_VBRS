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
    [EnableCors(origins: "http://192.168.101.128/", headers: "*", methods: "*")]

    
    public class FolioTransprtController : ApiController
    {

        public Doc_ftrs tbla = new Doc_ftrs();
        /*RETORNAR TODOS  LOS ELEMENTOS*/
        public Newtonsoft.Json.Linq.JArray Get()
        {

            return tbla.Get_Json_data();

        }

    }
}
