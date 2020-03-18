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
    public class VRS_VTS_NOTA_CRED
    {

        private Double TotMontoCRED;
        

        private String _TotMontoCRED;
        


        private SqlDataReader drd;

        public List<DataTable> _RES_TOTALES = null;

        public Newtonsoft.Json.Linq.JArray VTS_NOTA_CRED(DateTime Fini, DateTime Ffin)
        {
            DataTable dtvts = new DataTable();
            try
            {
                using (SqlConnection CONECT = new SqlConnection(@"Data Source=192.168.101.22;Initial Catalog=AGROVERSA_PRODUCTIVA;User ID=sa;Password=DB@gr0V3rs@"))
                {
                    CONECT.Open();
                    using (SqlCommand COMANDO = new SqlCommand("SP_TOTAL_NOTAS_CREDITO", CONECT))
                    {

                        COMANDO.CommandType = CommandType.StoredProcedure;
                        COMANDO.Parameters.Add("@INI_FCH", SqlDbType.DateTime);
                        COMANDO.Parameters["@INI_FCH"].Value = Fini;
                        COMANDO.Parameters.Add("@FIN_FCH", SqlDbType.DateTime);
                        COMANDO.Parameters["@FIN_FCH"].Value = Ffin;
                        drd = COMANDO.ExecuteReader();

                        if (drd.Read())
                        {
                            TotMontoCRED = Convert.ToDouble(drd["TOTMONTONOTAS"]);
                           

                            _TotMontoCRED = String.Format("$ #,###,##0.00", TotMontoCRED);
                           

                            object[] _objt_TotMontoCRED = { "TotMontoCRED", TotMontoCRED };
                           

                            dtvts.Clear();

                            dtvts.Columns.Add("TotMontoCRED", typeof(Double));
                           

                            dtvts.Rows.Add(TotMontoCRED);








                        }

                        ///######################################################################################################################

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