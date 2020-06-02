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
    public class api_VTS_NOTAS_DE_CREDITOController : ApiController
    {
        [EnableCors(origins: "http://192.168.101.128/", headers: "*", methods: "*")]
        public Newtonsoft.Json.Linq.JArray Get()
        {
            apiVTS_NOTAS_DE_CREDITO OBJETO_VENTAS = new apiVTS_NOTAS_DE_CREDITO();



            return OBJETO_VENTAS.CALL_SP_VENTASVRSNC();

        }
    }
}