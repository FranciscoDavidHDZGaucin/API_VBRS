using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Data.SqlClient;
using System;

namespace OTRA_API_008.Models
{
    public class api_BI_PEDIDOS_PENDIENTES
    {

        public Newtonsoft.Json.Linq.JArray PEDIDOS_PENDIENTES_SAP(int agente )
        {

            DataTable dtvts = new DataTable();
            try
            {
                using (SqlConnection CONECT = new SqlConnection(@"Data Source=192.168.101.22;Initial Catalog=AGROVERSA_PRODUCTIVA;User ID=sa;Password=DB@gr0V3rs@"))
                {
                    CONECT.Open();
                    using (SqlCommand COMANDO = new SqlCommand("SP_DOCUMENTOS_PENDIENTES_SAP", CONECT))


                    {
                        COMANDO.CommandType = CommandType.StoredProcedure;
                        COMANDO.Parameters.Add("@agente", SqlDbType.VarChar).Value = agente;
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

        public Newtonsoft.Json.Linq.JArray  PEDIDOS_PENDIENTES_PLATAFORMA()
        {

            DataTable dtvts = new DataTable();
            try
            {
                using (SqlConnection CONECT = new SqlConnection(@"Data Source=192.168.101.154;Initial Catalog=JUPITER;User ID=sa;Password=DB@gr0V3rs@"))
                {
                    CONECT.Open();
                    using (SqlCommand COMANDO = new SqlCommand("SP_BI_PEDIDOS_PENDIETNES_REPORTES_REPORTES", CONECT))


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