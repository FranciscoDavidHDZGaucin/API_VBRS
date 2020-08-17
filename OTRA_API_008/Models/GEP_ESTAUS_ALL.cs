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
    public class GEP_ESTAUS_ALL
    {

        private SqlDataReader drd;



        public Newtonsoft.Json.Linq.JArray  GEP_ESTATUS_PEDIDOS ()
        {
            DataTable Result = new DataTable();
            try
            {

                using (SqlConnection CONECT = new SqlConnection(@"Data Source=192.168.101.154;Initial Catalog=JUPITER;User ID=sa;Password=DB@gr0V3rs@"))
                {
                    CONECT.Open();
                    using (SqlCommand COMANDO = new SqlCommand(" SELECT ESTATUS_PEDIDO  FROM VW_GEP_ESTATUS_PEDIDOS_TB_MAIN ", CONECT))
                    {

                       
                        Result.Load(COMANDO.ExecuteReader());



                    }
                }

            }
            catch (Exception e)
            {
                Result = new DataTable();

            }

            var jsonresult = JsonConvert.SerializeObject(Result);
            JArray Areglo_JSON = JArray.Parse(jsonresult);

            return Areglo_JSON;
        }

        public Newtonsoft.Json.Linq.JArray GEP_ESTATUS_LOGISTICA ()
        {
            DataTable Result = new DataTable();
            try
            {

                using (SqlConnection CONECT = new SqlConnection(@"Data Source=192.168.101.154;Initial Catalog=JUPITER;User ID=sa;Password=DB@gr0V3rs@"))
                {
                    CONECT.Open();
                    using (SqlCommand COMANDO = new SqlCommand("SELECT  ESTATUS_LOGISTICA   FROM VW_GEP_ESTATUS_LOGISTICA_TB_MAIN ", CONECT))
                    {


                        Result.Load(COMANDO.ExecuteReader());



                    }
                }

            }
            catch (Exception e)
            {
                Result = new DataTable();

            }

            var jsonresult = JsonConvert.SerializeObject(Result);
            JArray Areglo_JSON = JArray.Parse(jsonresult);

            return Areglo_JSON;
        }
        public Newtonsoft.Json.Linq.JArray GEP_ESTATUS_TRASNPORTE()
        {
            DataTable Result = new DataTable();
            try
            {

                using (SqlConnection CONECT = new SqlConnection(@"Data Source=192.168.101.154;Initial Catalog=JUPITER;User ID=sa;Password=DB@gr0V3rs@"))
                {
                    CONECT.Open();
                    using (SqlCommand COMANDO = new SqlCommand("SELECT  TRANSPORTE  FROM VW_GEP_TRANSPORTE_TB_MAIN ", CONECT))
                    {


                        Result.Load(COMANDO.ExecuteReader());



                    }
                }

            }
            catch (Exception e)
            {
                Result = new DataTable();

            }

            var jsonresult = JsonConvert.SerializeObject(Result);
            JArray Areglo_JSON = JArray.Parse(jsonresult);

            return Areglo_JSON;
        }

    }
}