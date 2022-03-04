using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OTRA_API_008.Models
{
    public class api_SAP_ORDENES_COMPRA_PEND_SURTIR
    {

        private SqlDataReader drd;
        private DateTime NOWDAY = DateTime.Now;
        private DateTime MONTHS_MENOS = DateTime.Now.AddMonths(-6);
        public List<DataTable> _RES_TOTALES = null;

        public Newtonsoft.Json.Linq.JArray ORDENES_COMPRA()
        {
  

        DataTable dtvts = new DataTable();
        try
        {
            using (SqlConnection CONECT = new SqlConnection(@"Data Source=192.168.101.22;Initial Catalog=AGROVERSA_PRODUCTIVA;User ID=sa;Password=DB@gr0V3rs@"))
            {
                CONECT.Open();

                using (SqlCommand COMANDO = new SqlCommand("SELECT * FROM VW_SAP_ORDENES_COMPRA_PENDIENTES;", CONECT))


                {
                    dtvts.Load(COMANDO.ExecuteReader());





//comentario



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
