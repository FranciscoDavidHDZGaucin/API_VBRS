using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Data.SqlClient;

namespace OTRA_API_008.Models
{
    public class vwCAT_CLIENTES
    {

        private SqlDataReader drd;

        public Newtonsoft.Json.Linq.JArray CAT_CLIENTE()
        {

            DataTable dtvts = new DataTable();
            try
            {
                using (SqlConnection CONECT = new SqlConnection(@"Data Source=192.168.101.154;Initial Catalog=INEFABLE;User ID=sa;Password=DB@gr0V3rs@"))
                {
                    CONECT.Open();
                    using (SqlCommand COMANDO = new SqlCommand("SELECT * FROM vwCAT_CLIENTES", CONECT))


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

        public Newtonsoft.Json.Linq.JArray POST_DATABLE_CLIENTES (int apiCAT_AGENTES )
        {
            DataTable Result = new DataTable();
            try {

                using (SqlConnection CONECT = new SqlConnection(@"Data Source=192.168.101.154;Initial Catalog=INEFABLE;User ID=sa;Password=DB@gr0V3rs@"))
                {
                    CONECT.Open();
                    using (SqlCommand COMANDO = new SqlCommand(" SELECT COD_CLIENTE,NOM_CLIENTE  FROM vwCAT_CLIENTES WHERE COD_AGENTE1= @_AGENTE OR  COD_AGENTE2 = @_AGENTE ", CONECT))
                      {

                        COMANDO.Parameters.AddWithValue("@_AGENTE", apiCAT_AGENTES);
                        Result.Load(COMANDO.ExecuteReader());



                    }
                }

            } catch (Exception e)
            {
                Result = new DataTable();

            }

            var jsonresult = JsonConvert.SerializeObject(Result);
            JArray Areglo_JSON = JArray.Parse(jsonresult);

            return Areglo_JSON;
        }


    }
}