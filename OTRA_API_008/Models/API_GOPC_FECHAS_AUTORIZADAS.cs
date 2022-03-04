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
    public class API_GOPC_FECHAS_AUTORIZADAS


    {


        private SqlDataReader drd;

        public List<DataTable> _RES_TOTALES = null;

        public Newtonsoft.Json.Linq.JArray CALL_PLATAFORMA_UNES()
        {

            DataTable dtvts = new DataTable();
            try
            {
                using (SqlConnection CONECT = new SqlConnection(@"Data Source=192.168.101.154;Initial Catalog=INEFABLE;User ID=sa;Password=DB@gr0V3rs@"))
                {
                    CONECT.Open();
                    using (SqlCommand COMANDO = new SqlCommand("select [ID_DIA] ,[FECHCORTA],[FECH_LGMX] ,[FECH_LGUS],[FECH_INI_MES],[FECH_FINMES] ,[DIAS_MES] ,[ANIO] ,[NUM_MES],[DIA] ,[MES]  ,[SEMANA_EMPIEZADOM]   ,[SEMANA_EMPIEZAENLUN] ,[DIA_SEMANA],[TRIMESTRE] ,[SEMESTRE],[ESTACION_NORTE],[ESTACION_SUR] ,[SEMANA RSGD] as SEMANARSGD FROM [JUPITER].[dbo].[TB_PERIODO_RSGD_AUTO]", CONECT))


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
        //    const string SELECPLATFORM = "SELECT * FROM [JUPITER].[dbo].[TB_PERIODO_RSGD_AUTO]";

        //    SqlDataReader drd;
        //    public Newtonsoft.Json.Linq.JArray CALL_PLATAFORMA_UNES()
        //    {
        //        List<AUT_FECHAS> _res_json = new List<AUT_FECHAS>();
        //        try
        //        {
        //            using (SqlConnection coneect = new SqlConnection(@"Data Source=SRV-DBGW;Initial Catalog=JUPITER;User ID=sa;Password=DB@gr0V3rs@"))
        //            {
        //                coneect.Open();
        //                using (SqlCommand comselect = new SqlCommand(SELECPLATFORM, coneect))
        //                {
        //                    drd = comselect.ExecuteReader();
        //                    while (drd.Read())
        //                    {
        //                        AUT_FECHAS OB_FECHAS = new AUT_FECHAS
        //                        {
        //                            ID_DIA = Convert.ToString(drd["ID_DIA"]),
        //                            FECHCORTA = Convert.ToDateTime(drd["FECHCORTA"]).Date.ToString("yyyy-MM-dd"),
        //                            FECH_LGMX = Convert.ToDateTime(drd["FECH_LGMX"]).Date.ToString("yyyy-MM-dd"),
        //                            FECH_LGUS = Convert.ToDateTime(drd["FECH_LGUS"]).Date.ToString("yyyy-MM-dd"),
        //                            FECH_INI_MES = Convert.ToDateTime(drd["FECH_INI_MES"]).Date.ToString("yyyy-MM-dd"),
        //                            FECH_FINMES = Convert.ToDateTime(drd["FECH_FINMES"]).Date.ToString("yyyy-MM-dd"),
        //                            DIAS_MES = Convert.ToDouble(drd["DIAS_MES"]),
        //                            ANIO = Convert.ToString(drd["ANIO"]),
        //                            NUM_MES = Convert.ToString(drd["NUM_MES"]),
        //                            DIA = Convert.ToString(drd["DIA"]),
        //                            MES = Convert.ToString(drd["MES"]),
        //                            SEMANA_EMPIEZADOM = Convert.ToDouble(drd["SEMANA_EMPIEZADOM"]),
        //                            SEMANA_EMPIEZAENLUN = Convert.ToDouble(drd["SEMANA_EMPIEZAENLUN"]),
        //                            DIA_SEMANA = Convert.ToString(drd["DIA_SEMANA"]),
        //                            TRIMESTRE = Convert.ToString(drd["TRIMESTRE"]),
        //                            SEMESTRE = Convert.ToString(drd["SEMESTRE"]),
        //                            ESTACION_NORTE = Convert.ToString(drd["ESTACION_NORTE"]),
        //                            ESTACION_SUR = Convert.ToString(drd["ESTACION_SUR"]),
        //                            SEMANARSGD = Convert.ToDouble(drd["SEMANA RSGD"])

        //                        };

        //                        _res_json.Add(OB_FECHAS);

        //                    }



        //                }


        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            _res_json = new List<AUT_FECHAS>();

        //        }

        //        var jsonresult = JsonConvert.SerializeObject(_res_json);
        //        JArray Areglo_JSON = JArray.Parse(jsonresult);

        //        return Areglo_JSON;
        //    }
        //}

        //public class AUT_FECHAS
        //{

        //    public string ID_DIA { get; set; }

        //    public string FECHCORTA { get; set; }
        //    public string FECH_LGMX { get; set; }
        //    public string FECH_LGUS { get; set; }
        //    public string FECH_INI_MES { get; set; }
        //    public string FECH_FINMES { get; set; }
        //    public double DIAS_MES { get; set; }
        //    public string ANIO { get; set; }
        //    public string NUM_MES { get; set; }
        //    public string DIA { get; set; }
        //    public string MES { get; set; }
        //    public double SEMANA_EMPIEZADOM { get; set; }
        //    public double SEMANA_EMPIEZAENLUN { get; set; }
        //    public string DIA_SEMANA { get; set; }
        //    public string TRIMESTRE { get; set; }
        //    public string SEMESTRE { get; set; }
        //    public string ESTACION_NORTE { get; set; }
        //    public string ESTACION_SUR { get; set; }
        //    public double SEMANARSGD { get; set; }




    }
}