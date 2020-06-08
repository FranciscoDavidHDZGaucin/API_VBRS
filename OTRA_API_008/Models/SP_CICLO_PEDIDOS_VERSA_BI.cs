
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace OTRA_API_008.Models
{
    public class SP_CICLO_PEDIDOS_VERSA_BI
    {

        private SqlDataReader drd;

        public List<DataTable> _RES_TOTALES = null;

        public Newtonsoft.Json.Linq.JArray SP_CICLO_PEDIDOS()
        {

            DataTable dtvts = new DataTable();
            try
            {
                using (MySqlConnection myconec = new MySqlConnection(@"server=192.168.101.5; database=pedidos;user id=root; password=avsa0543;"))
                {
                    myconec.Open();
                    using (MySqlCommand Selecttb = new MySqlCommand("SP_CICLO_PEDIDOS_VERSA_BI", myconec))


                    {
                        dtvts.Load(Selecttb.ExecuteReader());




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