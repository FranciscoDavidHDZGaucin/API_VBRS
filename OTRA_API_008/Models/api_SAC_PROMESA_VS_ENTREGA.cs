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
    public class api_SAC_PROMESA_VS_ENTREGA
    {
        private MySqlDataReader drd;

        public List<DataTable> _RES_TOTALES = null;

        public Newtonsoft.Json.Linq.JArray FECHAS()
        {

            DataTable dtvts = new DataTable();
            try
            {
                using (MySqlConnection CONECT = new MySqlConnection(@"server=192.168.101.5; database=pedidos;user id=root; password=avsa0543;"))
                {
                    CONECT.Open();
                    using (MySqlCommand COMANDO = new MySqlCommand("SP_NET_SAC_ps3", CONECT))


                    {
                        string date = DateTime.Now.ToString("yyyy'-'MM'-'dd");
                        COMANDO.CommandType = CommandType.StoredProcedure;

                        COMANDO.Parameters.AddWithValue("@INI_FECH", "2020-01-01");
                        COMANDO.Parameters["@INI_FECH"].Direction = ParameterDirection.Input;
                        COMANDO.Parameters.AddWithValue("@FIN_FECH",date);
                        COMANDO.Parameters["@FIN_FECH"].Direction = ParameterDirection.Input;
                        COMANDO.Parameters.AddWithValue("@FECH_TYPE", "FEALTA");
                        COMANDO.Parameters["@FECH_TYPE"].Direction = ParameterDirection.Input;
                        COMANDO.Parameters.AddWithValue("@CLI_OPCION", "$");
                        COMANDO.Parameters["@CLI_OPCION"].Direction = ParameterDirection.Input;
                        COMANDO.Parameters.AddWithValue("@AGENTE_OPCION", 0);
                        COMANDO.Parameters["@AGENTE_OPCION"].Direction = ParameterDirection.Input;
                        COMANDO.Parameters.AddWithValue("@typefech", "$");
                        COMANDO.Parameters["@typefech"].Direction = ParameterDirection.Input;
                        COMANDO.Parameters.AddWithValue("@fACUSE", 3);
                        COMANDO.Parameters["@fACUSE"].Direction = ParameterDirection.Input;
                        COMANDO.Parameters.AddWithValue("@OPCZONA", 0);
                        COMANDO.Parameters["@OPCZONA"].Direction = ParameterDirection.Input;
                        COMANDO.Parameters.AddWithValue("@OPC_TRANSPORTE", 0);
                        COMANDO.Parameters["@OPC_TRANSPORTE"].Direction = ParameterDirection.Input;
                       
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