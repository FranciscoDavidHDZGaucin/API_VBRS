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
    public class apiCAT_CLIENTESController : ApiController
    {
        public Newtonsoft.Json.Linq.JArray Get()
        {
            vwCAT_CLIENTES CLIENTES = new vwCAT_CLIENTES();
            JArray result = new JArray();
            result = CLIENTES.CAT_CLIENTE();
            return result;
        }
        public Newtonsoft.Json.Linq.JArray Get(int vts_agente)
        {
            vwCAT_CLIENTES CLIENTES = new vwCAT_CLIENTES();
            JArray result = new JArray();
            result = CLIENTES.POST_DATABLE_CLIENTES(vts_agente);
            return result;


        }


    }
}