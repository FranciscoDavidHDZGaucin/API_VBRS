using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OTRA_API_008.Models
{
    public class FECHAS_AUTORIZADAS_RSGD
    {

        const string SELECPLATFORM = "";

        SqlDataReader drd;
        public Newtonsoft.Json.Linq.JArray CALL_PLATAFORMA_UNES()
        {
            List<AU_FECHAS> _res_json = new List<AU_FECHAS>();
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
                            AU_FECHAS OB_FECHAS = new AU_FECHAS
                            {
                                ID_DIA = Convert.ToString(drd["ID_DIA"]),
                                FECHCORTA = Convert.ToDateTime(drd["FECHCORTA"]),
                                FECH_LGMX = Convert.ToDateTime(drd["FECH_LGMX"]),
                                FECH_LGUS = Convert.ToDateTime(drd["FECH_LGUS"]),
                                FECH_INI_MES = Convert.ToDateTime(drd["FECH_INI_MES"]),
                                FECH_FINMES = Convert.ToDateTime(drd["FECH_FINMES"]),
                                DIAS_MES = Convert.ToDouble(drd["DIAS_MES"]),
                                ANIO = Convert.ToString(drd["ANIO"]),
                                NUM_MES = Convert.ToString(drd["NUM_MES"]),
                                DIA = Convert.ToString(drd["DIA"]),
                                MES = Convert.ToString(drd["MES"]),
                                SEMANA_EMPIEZADOM = Convert.ToDouble(drd["SEMANA_EMPIEZADOM"]),
                                SEMANA_EMPIEZAENLUN = Convert.ToDouble(drd["SEMANA_EMPIEZAENLUN"]),
                                DIA_SEMANA = Convert.ToString(drd["DIA_SEMANA"]),
                                TRIMESTRE = Convert.ToString(drd["TRIMESTRE"]),
                                SEMESTRE = Convert.ToString(drd["SEMESTRE"]),
                                ESTACION_NORTE = Convert.ToString(drd["ESTACION_NORTE"]),
                                ESTACION_SUR = Convert.ToString(drd["ESTACION_SUR"]),
                                SEMANARSGD = Convert.ToDouble(drd["SEMANARSGD"])

                            };

                            _res_json.Add(OB_FECHAS);

                        }



                    }


                }
            }
            catch (Exception e)
            {
                _res_json = new List<AU_FECHAS>();

            }

            var jsonresult = JsonConvert.SerializeObject(_res_json);
            JArray Areglo_JSON = JArray.Parse(jsonresult);

            return Areglo_JSON;

        }






    }

    public class AU_FECHAS
    {

        public string ID_DIA { get; set;}
        public DateTime FECHCORTA { get; set;}
        public DateTime FECH_LGMX { get; set;}
        public DateTime FECH_LGUS { get; set;}
        public DateTime FECH_INI_MES { get; set;}
        public DateTime FECH_FINMES { get; set;}
        public double DIAS_MES { get; set;}
        public string ANIO { get; set;}
        public string NUM_MES { get; set;}
        public string DIA { get; set;}
        public string MES { get; set;}
        public double SEMANA_EMPIEZADOM { get; set;}
        public double SEMANA_EMPIEZAENLUN { get; set;}
        public string DIA_SEMANA { get; set;}
        public string TRIMESTRE { get; set;}
        public string SEMESTRE { get; set;}
        public string ESTACION_NORTE { get; set;}
        public string ESTACION_SUR { get; set;}
        public double SEMANARSGD { get; set;}




}
}