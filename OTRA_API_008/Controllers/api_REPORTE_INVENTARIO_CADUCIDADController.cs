﻿using System;
using System.Collections.Generic;
using OTRA_API_008.Models;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Data.SqlClient;

namespace OTRA_API_008.Controllers
{
    public class api_REPORTE_INVENTARIO_CADUCIDADController : ApiController
    {

        public Newtonsoft.Json.Linq.JArray Get()
        {
            api_REPORTE_INVENTARIO_CADUCIDAD Progr = new api_REPORTE_INVENTARIO_CADUCIDAD();
            JArray result = new JArray();
            result = Progr.INVENTARIO();
            return result;
        }
    }
}