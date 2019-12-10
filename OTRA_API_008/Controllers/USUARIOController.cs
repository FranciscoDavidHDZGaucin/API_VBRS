using Newtonsoft.Json.Linq;
using OTRA_API_008.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OTRA_API_008.Controllers
{
    public class USUARIOController : ApiController
    {
        public String Get()
        {
            return "CONTROLADOR DE PANCHO :T";

        }
        public JObject Get( string usu,  string pass)
        {
            USUARIO user = new USUARIO(usu, pass);

            return user.F_RESUTADO_STRIGN;
        }
    }
}
