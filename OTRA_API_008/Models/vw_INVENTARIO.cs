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
    public class vw_INVENTARIO
    {

        public List<vw_prod_inventario> _ResObjeto = null;
        private SqlDataReader drd;
        // private SqlDataReader DRD;

        string fech_real = "";

        private DateTime NOWDAY = DateTime.Now;
        private DateTime YEARS_MENOS = DateTime.Now.AddYears(-1);


        const string SELECPLATFORM = "SELECT [SKU_PRODUCTO],[NOM_PRODUCTO],[UNIDAD_MEDIDA],[LOTE],[FECHA_CREACION],[FECHA_VENCIMIENTO],[FECHA_RECOMENDADA],[CLAVE_PROD_SAT],[CLASIFICACION],[DIVISION],[FAMILIA],[LINEA],[MARCA],[PORTAFOLIO],[PRESENTACION],[COD_ALMACEN],[NOM_ALMACEN],[CD_ALMACEN],[ZONA],[EDO_ALMACEN],[Status],[CANTIDAD_STOCK],[COSTO_PROMEDIO],[COSTO_TOTAL],[PRECIO_PROMEDIO],[PRECIO_TOTAL],[DIAS_PORVENCER],[ESTADO] FROM [JUPITER].[dbo].[VW_INVENTARIO_VRS_BI]";
        public Newtonsoft.Json.Linq.JArray VWINVENTARIO()
        {
            List<vw_prod_inventario> _res_json = new List<vw_prod_inventario>();
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
                            vw_prod_inventario OB_FECHAS = new vw_prod_inventario
                            {
                                SKU_PRODUCTO = Convert.ToString(drd["SKU_PRODUCTO"]),
                                NOM_PRODUCTO = Convert.ToString(drd["NOM_PRODUCTO"]),
                                UNIDAD_MEDIDA = Convert.ToString(drd["UNIDAD_MEDIDA"]),
                                LOTE = Convert.ToString(drd["LOTE"]),
                                FECHA_CREACION = Convert.ToDateTime(drd["FECHA_CREACION"]).Date.ToString(),
                                FECHA_VENCIMIENTO = Convert.ToDateTime(drd["FECHA_VENCIMIENTO"]).Date.ToString(),
                                FECHA_RECOMENDADA = Convert.ToDateTime(drd["FECHA_RECOMENDADA"]).Date.ToString(),
                                CLAVE_PROD_SAT = Convert.ToString(drd["CLAVE_PROD_SAT"]),
                                CLASIFICACION = Convert.ToString(drd["CLASIFICACION"]),
                                DIVISION = Convert.ToString(drd["DIVISION"]),
                                FAMILIA = Convert.ToString(drd["FAMILIA"]),
                                LINEA = Convert.ToString(drd["LINEA"]),
                                MARCA = Convert.ToString(drd["MARCA"]),
                                PORTAFOLIO = Convert.ToString(drd["PORTAFOLIO"]),
                                PRESENTACION = Convert.ToString(drd["PRESENTACION"]),
                                COD_ALMACEN = Convert.ToString(drd["COD_ALMACEN"]),
                                NOM_ALMACEN = Convert.ToString(drd["NOM_ALMACEN"]),
                                CD_ALMACEN = Convert.ToString(drd["CD_ALMACEN"]),
                                ZONA = Convert.ToString(drd["ZONA"]),
                                EDO_ALMACEN = Convert.ToString(drd["EDO_ALMACEN"]),
                                Status = Convert.ToString(drd["Status"]),
                                CANTIDAD_STOCK = Convert.ToInt32(drd["CANTIDAD_STOCK"]),
                                COSTO_PROMEDIO = Convert.ToDouble(drd["COSTO_PROMEDIO"]),
                                COSTO_TOTAL = Convert.ToDouble(drd["COSTO_TOTAL"]),
                                PRECIO_PROMEDIO = Convert.ToDouble(drd["PRECIO_PROMEDIO"]),
                                PRECIO_TOTAL = Convert.ToDouble(drd["PRECIO_TOTAL"]),
                                DIAS_PORVENCER = Convert.ToInt32(drd["DIAS_PORVENCER"]),
                                ESTADO = Convert.ToString(drd["ESTADO"])
                            };

                            _res_json.Add(OB_FECHAS);

                        }



                    }


                }
            }
            catch (Exception e)
            {
                _res_json = new List<vw_prod_inventario>();

            }

            var jsonresult = JsonConvert.SerializeObject(_res_json);
            JArray Areglo_JSON = JArray.Parse(jsonresult);

            return Areglo_JSON;

        }



    }

    public class  vw_prod_inventario
    {

        public string SKU_PRODUCTO { get; set; }
        public string NOM_PRODUCTO { get; set; }
        public string UNIDAD_MEDIDA { get; set; }
        public string LOTE { get; set; }
        public string FECHA_CREACION { get; set; }
        public string  FECHA_VENCIMIENTO { get; set; }
        public string FECHA_RECOMENDADA { get; set; }
        public string CLAVE_PROD_SAT { get; set; }
        public string CLASIFICACION { get; set; }
        public string DIVISION { get; set; }
        public string FAMILIA { get; set; }
        public string LINEA { get; set; }
        public string MARCA { get; set; }
        public string PORTAFOLIO { get; set; }
        public string PRESENTACION { get; set; }
        public string COD_ALMACEN { get; set; }
        public string NOM_ALMACEN { get; set; }
        public string CD_ALMACEN { get; set; }
        public string ZONA { get; set; }
        public string EDO_ALMACEN { get; set; }
        public string Status { get; set; }
        public int CANTIDAD_STOCK { get; set; }
        public double COSTO_PROMEDIO { get; set; }
        public double COSTO_TOTAL { get; set; }
        public double PRECIO_PROMEDIO { get; set; }
        public double PRECIO_TOTAL { get; set; }
        public int DIAS_PORVENCER     { get; set; }
        public string ESTADO { get; set; }


    }



}