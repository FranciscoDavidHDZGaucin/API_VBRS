using OTRA_API_008.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OTRA_API_008.Controllers
{
    public class Fechas_Porcentuales_Controller : ApiController
    {

        public Newtonsoft.Json.Linq.JArray Get()
        {
            api_FECHAS_PORCENTUALES OBJETO_VENTAS = new api_FECHAS_PORCENTUALES();



            return OBJETO_VENTAS.FECHAS_PORCEN();

        }
    }
}
