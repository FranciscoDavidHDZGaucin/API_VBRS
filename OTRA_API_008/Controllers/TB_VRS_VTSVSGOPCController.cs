﻿using OTRA_API_008.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace OTRA_API_008.Controllers
{
    public class TB_VRS_VTSVSGOPCController : ApiController
    {

        [EnableCors(origins: "http://192.168.101.128/", headers: "*", methods: "*")]
        public Newtonsoft.Json.Linq.JArray Get()
        {
            TB_VRS_VENTAS_VS_GOPC OBJETO_VENTAS = new TB_VRS_VENTAS_VS_GOPC();



            return OBJETO_VENTAS.CALL_SP_TB_VTSVSGOPC();

        }




    }
}
