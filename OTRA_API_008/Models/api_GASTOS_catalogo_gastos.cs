﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Data.SqlClient;

namespace OTRA_API_008.Models
{
    public class api_GASTOS_catalogo_gastos
    {
        private SqlDataReader drd;

        public List<DataTable> _RES_TOTALES = null;

        public Newtonsoft.Json.Linq.JArray catalogo()
        {

            DataTable dtvts = new DataTable();
            try
            {
                using (SqlConnection CONECT = new SqlConnection(@"Data Source=192.168.101.22;Initial Catalog=BDSALESFORCE20200526;User ID=sa;Password=DB@gr0V3rs@"))
                {
                    CONECT.Open();
                    using (SqlCommand COMANDO = new SqlCommand("select Code,Name,U_centro_costos,U_id_cuenta_contable,U_nombre_cuenta,U_clas_PG,U_cuenta_contable,U_nv1_NA,U_nv2_PC,U_UNES,U_MAM,U_direccion,U_gerencia,U_zona from [@CATALOGO_GASTOS2021]", CONECT))


                    {
                        dtvts.Load(COMANDO.ExecuteReader());




                    }
                }

            }
            catch (Exception e)
            {
                dtvts = new DataTable();
            }
            var jsonresult = JsonConvert.SerializeObject(dtvts);
            JArray Areglo_JSON = JArray.Parse(jsonresult);

            return Areglo_JSON;
        }
    }
}