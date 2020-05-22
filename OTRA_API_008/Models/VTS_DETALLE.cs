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
    public class VTS_DETALLE
    {
    
       

        private SqlDataReader drd;

        public List<DataTable> _RES_TOTALES = null;

        public Newtonsoft.Json.Linq.JArray VTS_SP_DETALLE()
        {
            List<VTS_AND_DETALLE> LISTAREULTADO = new List<VTS_AND_DETALLE>();
            DataTable dtvts = new DataTable();
            try
            {
                using (SqlConnection CONECT = new SqlConnection(@"Data Source=SRV-DBGW;Initial Catalog=INEFABLE;User ID=sa;Password=DB@gr0V3rs@"))
                {
                    CONECT.Open();
                    using (SqlCommand COMANDO = new SqlCommand("SP_TODAS_NORMALIZADA_DETALLE", CONECT))
                    {
                        drd = COMANDO.ExecuteReader();

                        dtvts.Columns.Add("NUM_DOCTO", typeof(Int32));
                        dtvts.Columns.Add("SKU_PRODUCTO", typeof(String));
                        dtvts.Columns.Add("NOM_PRODUCTO", typeof(String));
                        dtvts.Columns.Add("COD_CLIENTE", typeof(String));
                        dtvts.Columns.Add("NOM_CLIENTE", typeof(String));
                        dtvts.Columns.Add("FECHA_DOCTO", typeof(DateTime));
                        dtvts.Columns.Add("DIVISION", typeof(String));
                        dtvts.Columns.Add("FAMILIA", typeof(String));
                        dtvts.Columns.Add("LINEA", typeof(String));
                        dtvts.Columns.Add("MARCA", typeof(String));
                        dtvts.Columns.Add("PORTAFOLIO", typeof(String));
                        dtvts.Columns.Add("MONTO", typeof(Double));
                        dtvts.Columns.Add("UN", typeof(String));
                        dtvts.Columns.Add("CMG", typeof(Double));
                        dtvts.Columns.Add("PCTCMG", typeof(Double));
                        dtvts.Columns.Add("COSTO", typeof(Double));

                        while (drd.Read())
                        {

                            VTS_AND_DETALLE ROW_OBJT = new VTS_AND_DETALLE
                            {
                            NUM_DOCTO = Convert.ToInt32(drd["NUM_DOCTO"]),
                            SKU_PRODUCTO = Convert.ToString(drd["SKU_PRODUCTO"]),
                            NOM_PRODUCTO = Convert.ToString(drd["NOM_PRODUCTO"]),
                            COD_CLIENTE = Convert.ToString(drd["COD_CLIENTE"]),
                            NOM_CLIENTE = Convert.ToString(drd["NOM_CLIENTE"]),
                            FECHA_DOCTO = Convert.ToDateTime(drd["FECHA_DOCTO"]),
                            DIVISION = Convert.ToString(drd["DIVISION"]),
                            FAMILIA = Convert.ToString(drd["FAMILIA"]),
                            LINEA = Convert.ToString(drd["LINEA"]),
                            MARCA = Convert.ToString(drd["MARCA"]),
                            PORTAFOLIO = Convert.ToString(drd["PORTAFOLIO"]),
                            MONTO = Convert.ToDouble(drd["MONTO"]),
                            UN = Convert.ToString(drd["UN"]),
                            CMG = Convert.ToDouble(drd["CMG"]),
                            PCTCMG = Convert.ToDouble(drd["PCTCMG"]),
                            COSTO = Convert.ToDouble(drd["COSTO"])
                            };
                            LISTAREULTADO.Add(ROW_OBJT);

                            dtvts.Rows.Add(ROW_OBJT.NUM_DOCTO, ROW_OBJT.SKU_PRODUCTO, ROW_OBJT.NOM_PRODUCTO, ROW_OBJT.COD_CLIENTE, ROW_OBJT.NOM_CLIENTE, ROW_OBJT.FECHA_DOCTO, ROW_OBJT.DIVISION,
                                ROW_OBJT.FAMILIA, ROW_OBJT.LINEA, ROW_OBJT.MARCA, ROW_OBJT.PORTAFOLIO, ROW_OBJT.MONTO, ROW_OBJT.UN, ROW_OBJT.CMG, ROW_OBJT.PCTCMG, ROW_OBJT.COSTO);
                        }
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

    public class VTS_AND_DETALLE
    {
        public Int32 NUM_DOCTO { get; set; }
        public string SKU_PRODUCTO { get; set; }
        public string NOM_PRODUCTO { get; set; }
        public string COD_CLIENTE { get; set; }
        public string NOM_CLIENTE { get; set; }
        public DateTime FECHA_DOCTO { get; set; }
        public string DIVISION { get; set; }
        public string FAMILIA { get; set; }
        public string LINEA { get; set; }
        public string MARCA { get; set; }
        public string PORTAFOLIO { get; set; }
        public double MONTO { get; set; }
        public string UN { get; set; }
        public double CMG { get; set; }
        public double PCTCMG { get; set; }
        public double COSTO { get; set; }
    }
}