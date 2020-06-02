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
    public class apiPRUEBAVTS_VS_GOPC
    {

        private Double TotMonto;
        private Double TotMontoReal;
        private Double TotCMGReal;
        private Double TotPCTCMGReal;
        private Double TotCosto;
        private Double TotCMG;
        private Double TotPCTCMG;
        private Double TotMontoGOPC;
        private Double TotCostoGOPC;
        private Double TotCMGGOPC;
        private Double TotPCTCMGGOPC;
        private Double TotNOTAS;
        private Double pctVts;
        private Double pctCMG;
        private Double pctPCTCMG;
        private String _TotMonto;
        private String _TotCMG_TOTAL;
        private String _TotCMG_porce;
        private String _ToCosto_TOTAL;
        private String _TotMontoGOPC;
        private String _TotCMG_TOTALGOPC;
        private String _TotCMG_porceGOPC;
        private String _ToCosto_TOTALGOPC;


        private SqlDataReader drd;

        public List<DataTable> _RES_TOTALES = null;

        public Newtonsoft.Json.Linq.JArray VTS_COMPARATIVA()
        {
            DataTable dtvts = new DataTable();
            try
            {
                using (SqlConnection CONECT = new SqlConnection(@"Data Source=192.168.101.22;Initial Catalog=AGROVERSA_PRODUCTIVA;User ID=sa;Password=DB@gr0V3rs@"))
                {
                    CONECT.Open();
                    using (SqlCommand COMANDO = new SqlCommand("SP_PRUEBA_VTS_GOPC", CONECT))
                    {

                        COMANDO.CommandType = CommandType.StoredProcedure;
                      
                        drd = COMANDO.ExecuteReader();

                        while (drd.Read())
                        {
                            TotMonto = Convert.ToDouble(drd["TOTMONTO"]);
                            TotCosto = Convert.ToDouble(drd["COSTOTOTAL"]);
                            TotCMG = Convert.ToDouble(drd["CMG"]);
                            TotPCTCMG = Convert.ToDouble(drd["PCTCMG"]);
                            TotMontoGOPC = Convert.ToDouble(drd["TOTMONTOGOPC"]);
                            TotCostoGOPC = Convert.ToDouble(drd["COSTOTOTALGOPC"]);
                            TotCMGGOPC = Convert.ToDouble(drd["CMGGOPC"]);
                            TotPCTCMGGOPC = Convert.ToDouble(drd["PCTCMGGOPC"]);
                            TotNOTAS = Convert.ToDouble(drd["NOTAS"]);

                            TotMontoReal = TotMonto;//+ TotNOTAS;
                            TotCMGReal = TotCMG;///+ TotNOTAS;

                            pctVts = (TotMontoReal * 100) / TotMontoGOPC;
                            pctCMG = (TotCMGReal * 100) / TotCMGGOPC;
                            pctPCTCMG = (TotCMG * TotPCTCMGGOPC) / TotCMGGOPC;

                            _TotMonto = String.Format("$ #,###,##0.00", TotMonto);
                            _TotCMG_TOTAL = String.Format("$ #,###,##0.00", TotCMG);
                            _ToCosto_TOTAL = String.Format("$ #,###,##0.00", TotCosto);
                            _TotCMG_porce = String.Format("#,#0.00", TotPCTCMG);


                            object[] _objt_TotMonto = { "TotMonto", TotMonto };
                            object[] _objt_TotCosto = { "TotCosto", TotCosto };
                            object[] _objt_TotCMG = { "TotCMG", TotMonto };
                            object[] _objt_TotPCTCMG = { "TotPCTCMG", TotMonto };
                            object[] _objt_TotMontoGOPC = { "TotMontoGOPC", TotMontoGOPC };
                            object[] _objt_TotCostoGOPC = { "TotCostoGOPC", TotCostoGOPC };
                            object[] _objt_TotCMGGOPC = { "TotCMGGOPC", TotCMGGOPC };
                            object[] _objt_TotPCTCMGGOPC = { "TotPCTCMGGOPC", TotPCTCMGGOPC };

                            dtvts.Clear();

                            dtvts.Columns.Add("TotMonto", typeof(Double));
                            dtvts.Columns.Add("TotCosto", typeof(Double));
                            dtvts.Columns.Add("TotCMG", typeof(Double));
                            dtvts.Columns.Add("TotPCTCMG", typeof(Double));
                            dtvts.Columns.Add("TotMontoGOPC", typeof(Double));
                            dtvts.Columns.Add("TotCostoGOPC", typeof(Double));
                            dtvts.Columns.Add("TotCMGGOPC", typeof(Double));
                            dtvts.Columns.Add("TotPCTCMGGOPC", typeof(Double));
                            dtvts.Columns.Add("PctVts", typeof(Double));
                            dtvts.Columns.Add("pctCMG", typeof(Double));
                            dtvts.Columns.Add("pctPCTCMG", typeof(Double));

                            dtvts.Rows.Add(TotMontoReal, TotCosto, TotCMGReal, TotPCTCMG, TotMontoGOPC, TotCostoGOPC, TotCMGGOPC, TotPCTCMGGOPC, pctVts, pctCMG, pctPCTCMG);








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