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
    public class VRS_VTS_FECHA
    {

        private Double TotMonto;
        private Double TotCosto;
        private Double TotCMG;
        private Double TotPCTCMG;
        private Double TotNOTACREDI;

        private String _TotMonto;
        private String _TotCMG_TOTAL;
        private String _TotCMG_porce;
        private String _ToCosto_TOTAL;


        private SqlDataReader drd;

        public List<DataTable> _RES_TOTALES = null;

        public Newtonsoft.Json.Linq.JArray VTS_TODAS_NORMALIZADAS(DateTime Fini, DateTime Ffin)
        {
            DataTable dtvts = new DataTable();
            try
            {
                using (SqlConnection CONECT = new SqlConnection(@"Data Source=192.168.101.22;Initial Catalog=AGROVERSA_PRODUCTIVA;User ID=sa;Password=DB@gr0V3rs@"))
                {
                    CONECT.Open();
                    using (SqlCommand COMANDO = new SqlCommand("SP_MONTO_TOTAL_FECHAS", CONECT))
                    {

                        COMANDO.CommandType = CommandType.StoredProcedure;
                        COMANDO.Parameters.Add("@INI_FCH", SqlDbType.DateTime);
                        COMANDO.Parameters["@INI_FCH"].Value = Fini;
                        COMANDO.Parameters.Add("@FIN_FCH", SqlDbType.DateTime);
                        COMANDO.Parameters["@FIN_FCH"].Value = Ffin;
                        drd = COMANDO.ExecuteReader();
                        
                        if (drd.Read())
                        {
                            TotMonto = Convert.ToDouble(drd["TOTMONTO"]);
                            TotCosto = Convert.ToDouble(drd["COSTOTOTAL"]);
                            TotCMG = Convert.ToDouble(drd["CMG"]);
                            TotPCTCMG = Convert.ToDouble(drd["PCTCMG"]);

                            _TotMonto = String.Format("$ #,###,##0.00", TotMonto);
                            _TotCMG_TOTAL = String.Format("$ #,###,##0.00", TotCMG);
                            _ToCosto_TOTAL = String.Format("$ #,###,##0.00", TotCosto);
                            _TotCMG_porce = String.Format("#,#0.00", TotPCTCMG);


                            object[] _objt_TotMonto = { "TotMonto", TotMonto };
                            object[] _objt_TotCosto = { "TotCosto", TotCosto };
                            object[] _objt_TotCMG = { "TotCMG", TotMonto };
                            object[] _objt_TotPCTCMG = { "TotPCTCMG", TotMonto };

                            dtvts.Clear();

                            dtvts.Columns.Add("TotMonto", typeof(Double));
                            dtvts.Columns.Add("TotCosto", typeof(Double));
                            dtvts.Columns.Add("TotCMG", typeof(Double));
                            dtvts.Columns.Add("TotPCTCMG", typeof(Double));

                            dtvts.Rows.Add(TotMonto, TotCosto, TotCMG, TotPCTCMG);
                            







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