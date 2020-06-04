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
    public class vw_CARTERA_GRUPOS
    {
        public List<carter_group> _ResObjeto = null;
        private SqlDataReader drd;
        // private SqlDataReader DRD;

        string fech_real = "";

        private DateTime NOWDAY = DateTime.Now;
        private DateTime YEARS_MENOS = DateTime.Now.AddYears(-1);
        const string SELECPLATFORM = "SELECT  [COD_CLIENTE],[NOM_CLIENTE],AGENTE,[NUM_DOCTO],[SALDO_VENCIDO],[TIPO],[CONTABILIZACION],[VENCIMIENTO],[DIAS]      ,[0-30] as ct030,[31-60] as ts3160 ,[61-90] as sn6190,[91-120] as nu91120,[121-150] as unun121150,[+150] as ci150,[AL_CORRIENTE],[GRUPO],[SlpCode],[UN],CASE WHEN  PLAZO IS NULL THEN   0 ELSE   PLAZO  END  PLAZO FROM [JUPITER].[dbo].[VW_VERSA_BI_CARTERA_GRUPO]";


        public Newtonsoft.Json.Linq.JArray VWINVENTARIO()
        {
            List<carter_group> _res_json = new List<carter_group>();
            try
            {
                using (SqlConnection coneect = new SqlConnection(@"Data Source=SRV-DBGW;Initial Catalog=JUPITER;User ID=sa;Password=DB@gr0V3rs@"))
                {
                    coneect.Open();
                    using (SqlCommand comselect = new SqlCommand(SELECPLATFORM, coneect))
                    {
                        drd = comselect.ExecuteReader();
                        while (drd.Read())
                        {
                            carter_group carter = new carter_group
                            {
                               

                                COD_CLIENTE = Convert.ToString(drd["COD_CLIENTE"]),
                                NOM_CLIENTE = Convert.ToString(drd["NOM_CLIENTE"]),
                                AGENTE = Convert.ToString(drd["AGENTE"]),
                                NUM_DOCTO = Convert.ToInt32(drd["NUM_DOCTO"]),
                                SALDO_VENCIDO = Convert.ToDouble(drd["SALDO_VENCIDO"]),
                                TIPO = Convert.ToString(drd["TIPO"]),
                                CONTABILIZACION = Convert.ToString(drd["CONTABILIZACION"]),
                                DIAS = Convert.ToString(drd["DIAS"]),
                                ct030 = Convert.ToDouble(drd["ct030"]),
                                ts3160 = Convert.ToDouble(drd["ts3160"]),
                                sn6190 = Convert.ToDouble(drd["sn6190"]),
                                nu91120 = Convert.ToDouble(drd["nu91120"]),
                                unun121150 = Convert.ToDouble(drd["unun121150"]),
                                ci150 = Convert.ToDouble(drd["ci150"]),
                                AL_CORRIENTE = Convert.ToDouble(drd["AL_CORRIENTE"]),
                                GRUPO = Convert.ToString(drd["GRUPO"]),
                                SlpCode = Convert.ToInt32(drd["SlpCode"]),
                                UN = Convert.ToString(drd["UN"]),
                                PLAZO = Convert.ToInt32(drd["PLAZO"])









                            };

                            _res_json.Add(carter);

                        }



                    }


                }
            }
            catch (Exception e)
            {
                _res_json = new List<carter_group>();

            }

            var jsonresult = JsonConvert.SerializeObject(_res_json);
            JArray Areglo_JSON = JArray.Parse(jsonresult);

            return Areglo_JSON;

        }




    }
    public class carter_group
    {
        public string COD_CLIENTE { get; set; }
        public string NOM_CLIENTE { get; set; }
        public string AGENTE { get; set; }
        public int NUM_DOCTO { get; set; }
        public double SALDO_VENCIDO { get; set; }
        public string TIPO { get; set; }
        public string CONTABILIZACION { get; set; }
        public string DIAS { get; set; }
        public double ct030	{ get;set;}
        public double ts3160	{ get;set;}
        public double sn6190	{ get;set;}
        public double nu91120	{ get;set;}
        public double unun121150	{ get;set;}
        public double ci150	{ get;set;}
        public double AL_CORRIENTE { get; set; }
        public string GRUPO { get; set; }
        public int SlpCode { get; set; }
        public string UN { get; set; }
        public int PLAZO { get; set; }



    }


}