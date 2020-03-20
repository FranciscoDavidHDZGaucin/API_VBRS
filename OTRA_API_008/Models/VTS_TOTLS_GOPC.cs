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
    public class VTS_TOTLS_GOPC
    {

        private double CANTIDAD_TOTL;
        private double MONTO_TOTL;
        private double MARGEN_TOTL;
        private double PORCECMG;


        private String _CANTIDAD_TOTL;
        private String _MONTO_TOTL;
        private String _MARGEN_TOTL;
        private String _PORCECMG;



        private SqlDataReader drd;

        public Newtonsoft.Json.Linq.JArray GOPC_TOTALES( DateTime  FECH_INI  , DateTime FIN_FECH )
        {
            DataTable dtvts = new DataTable();

            try
            {
                using (SqlConnection CONECT = new SqlConnection(@"Data Source=192.168.101.154;Initial Catalog=JUPITER;User ID=sa;Password=DB@gr0V3rs@"))
                {
                    CONECT.Open();
                    using (SqlCommand COMANDO = new SqlCommand("SP_GOPC_TOTATEL", CONECT))
                    {

                        COMANDO.CommandType = CommandType.StoredProcedure;
                        COMANDO.Parameters.Add("@INI_FECH", SqlDbType.DateTime);
                        COMANDO.Parameters["@INI_FECH"].Value = FECH_INI;
                        COMANDO.Parameters.Add("@FIN_FECH", SqlDbType.DateTime);
                        COMANDO.Parameters["@FIN_FECH"].Value = FIN_FECH;
                        drd = COMANDO.ExecuteReader();

                        while (drd.Read())
                        {
                            CANTIDAD_TOTL = Convert.ToDouble(drd["CANTIDAD_TOTL"]);
                            MONTO_TOTL = Convert.ToDouble(drd["MONTO_TOTL"]);
                            MARGEN_TOTL = Convert.ToDouble(drd["MARGEN_TOTL"]);
                            PORCECMG = Convert.ToDouble(drd["PORCECMG"]);


                            _CANTIDAD_TOTL = String.Format("$ #,###,##0.00", CANTIDAD_TOTL);
                            _MONTO_TOTL = String.Format("$ #,###,##0.00", MONTO_TOTL);
                            _MARGEN_TOTL = String.Format("$ #,###,##0.00", MARGEN_TOTL);
                            _PORCECMG = String.Format("#,#0.00", PORCECMG);


                            object[] _objt_CANTIDAD_TOTL = { "CANTIDAD_TOTL", CANTIDAD_TOTL };
                            object[] _objt_MONTO_TOTL = { "MONTO_TOTL", MONTO_TOTL };
                            object[] _objt_MARGEN_TOTL = { "TotCMG", MARGEN_TOTL };
                            object[] _objt_PORCECMG = { "TotPCTCMG", PORCECMG };

                            dtvts.Clear();

                            dtvts.Columns.Add("CANTIDAD_TOTL", typeof(Double));
                            dtvts.Columns.Add("MONTO_TOTL", typeof(Double));
                            dtvts.Columns.Add("MARGEN_TOTL", typeof(Double));
                            dtvts.Columns.Add("PORCECMG", typeof(Double));

                            dtvts.Rows.Add(CANTIDAD_TOTL,
                                MONTO_TOTL, MARGEN_TOTL,
                                PORCECMG);








                        }

                        ///######################################################################################################################

                    }

                }



            }
            catch (Exception e) {

                dtvts = new DataTable();
            }
            var jsonresult = JsonConvert.SerializeObject(dtvts);
            JArray Areglo_JSON = JArray.Parse(jsonresult);

            return Areglo_JSON;
        }

    }
}