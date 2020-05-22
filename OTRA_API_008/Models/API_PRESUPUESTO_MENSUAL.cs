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

   
    public class API_PRESUPUESTO_MENSUAL
    {

        private SqlDataReader drd;

        public List<DataTable> _RES_TOTALES = null;

        public Newtonsoft.Json.Linq.JArray PRESUPUESTO()
        {
            List<PRESUPUESTO_MENSUAL> LISTAREULTADO = new List<PRESUPUESTO_MENSUAL>();
            DataTable dtvts = new DataTable();
            try
            {
                using (SqlConnection CONECT = new SqlConnection(@"Data Source=192.168.101.22;Initial Catalog=AGROVERSA_PRODUCTIVA;User ID=sa;Password=DB@gr0V3rs@"))
                {
                    CONECT.Open();
                    using (SqlCommand COMANDO = new SqlCommand("SELECT * FROM vwPresupuesto_Mensual", CONECT))

                        
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
    }



    public class PRESUPUESTO_MENSUAL
    {
        public string Origen { get; set; }
        public Int32 Year { get; set; }
        public string Estatus { get; set; }
        public Int32 Centro_Costos { get; set; }
        public string CC_Descripcion { get; set; }
        public Int32 AcctCode { get; set; }
        public string AcctName { get; set; }
        public string Nombre { get; set; }
        public double Total { get; set; }
        public double Febrero { get; set; }
        public double Enero { get; set; }
        public double Marzo { get; set; }
        public double Abril { get; set; }
        public double Mayo { get; set; }
        public double Junio { get; set; }
        public double Julio { get; set; }
        public double Agosto { get; set; }
        public double Septiembre { get; set; }
        public double Octubre { get; set; }
        public double Noviembre { get; set; }
        public double Diciembre { get; set; }
    }


}