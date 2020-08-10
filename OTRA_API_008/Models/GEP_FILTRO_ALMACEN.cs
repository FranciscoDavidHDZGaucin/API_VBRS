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
    public class GEP_FILTRO_ALMACEN
    {
        public FILTRONOTAS _FILTRO_CNTRL = new FILTRONOTAS();
        public List<FIL_ALMACEN> _ResObjeto = null;
        private SqlDataReader drd;






        public Newtonsoft.Json.Linq.JArray FILTRO_ALMACEN(String SKU, String NOM, Int32 AGE)
        {

            DataTable ventas_vrs = new DataTable();
            List<FIL_ALMACEN> LISTAREULTADO = new List<FIL_ALMACEN>();
            try
            {
                using (SqlConnection CONECT = new SqlConnection(@"Data Source=192.168.101.154;Initial Catalog=JUPITER;User ID=sa;Password=DB@gr0V3rs@"))
                {
                    CONECT.Open();
                    using (SqlCommand COMANDO = new SqlCommand("SP_GEP_FILTRO_ALMACEN", CONECT))


                    {
                        COMANDO.CommandType = CommandType.StoredProcedure;
                        COMANDO.Parameters.Add("@SKU", SqlDbType.VarChar);
                        COMANDO.Parameters["@SKU"].Value = SKU;

                        COMANDO.Parameters.Add("@NOM", SqlDbType.VarChar);
                        COMANDO.Parameters["@NOM"].Value = NOM;

                        COMANDO.Parameters.Add("@AGE", SqlDbType.Int);
                        COMANDO.Parameters["@AGE"].Value = AGE;
                        drd = COMANDO.ExecuteReader();






                        while (drd.Read())
                        {



                            FIL_ALMACEN ROW_OBJT = new FIL_ALMACEN
                            {


                                CD_ALMA = Convert.ToString(drd["CD_ALMACEN"]),
                                NOMA = Convert.ToString(drd["NOM_ALMACEN"])
                            };
                            LISTAREULTADO.Add(ROW_OBJT);



                            //dtvts.Rows.Add(ROW_OBJT.SKUc, ROW_OBJT.NOMc);
                        }
                    }

                }
            }

            catch (Exception e)
            {
                ventas_vrs = new DataTable();
            }
            var jsonresult = JsonConvert.SerializeObject(LISTAREULTADO);
            JArray Areglo_JSON = JArray.Parse(jsonresult);

            return Areglo_JSON;
        }

        private List<FIL_ALMACEN> LIST_OBJETOS(DataTable ventas_vrs)
        {


            var _LISTA_VENTAS = (from DRD in ventas_vrs.AsEnumerable()
                                 select new FIL_ALMACEN()
                                 {

                                     CD_ALMA = Convert.ToString(DRD["CD_ALMACEN"]),
                                     NOMA = Convert.ToString(DRD["NOM_ALMACEN"])


                                 }



                                                 ).ToList();




            return _LISTA_VENTAS;


        }
    }
    public class FIL_ALMACEN
    {

        public string CD_ALMA { get; set; }
        public string NOMA { get; set; }
    }


}