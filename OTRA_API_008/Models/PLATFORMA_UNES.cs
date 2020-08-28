using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OTRA_API_008.Models
{
    public class PLATFORMA_UNES
    {
        const string SELECPLATFORM = "SELECT [REMISION]  ,[ZONA] ,[FECHA_ALTA] ,[NOMBRE_CLIENTE] ,[SKU_PRODUCTO] ,[NOM_PRODUCTO]    ,[CANT_FALTA]  ,[PRECIO_PROD]  ,[TOTAL_PROD]    ,[IMPORTE]    ,[XCESTATUS_PEDIDO]   ,[CATEGORIA]  ,[DIVISION]   ,[FAMILIA]    ,[LINEA]    ,[MARCA]    ,[PORTAFOLIO]      ,[PRESENTACION]     ,[U_UNE]   ,[U_ClasCMG]  ,[U_ClasMKT],[NUM_AGE],  NOM_AGE, CVE_CLIENTE  FROM[JUPITER].[dbo].[VW__VRSBI_PEDIDOS_PENDIENTES_FINCOMER_C_UNES]";  

        SqlDataReader drd;
        public Newtonsoft.Json.Linq.JArray CALL_PLATAFORMA_UNES()
        {
            List<EST_PEDIDO> _res_json = new List<EST_PEDIDO>();
            try
            {
                using (SqlConnection coneect = new SqlConnection(@"Data Source=SRV-DBGW;Initial Catalog=JUPITER;User ID=sa;Password=DB@gr0V3rs@" ))
                {
                    coneect.Open();
                    using (SqlCommand comselect = new SqlCommand(SELECPLATFORM, coneect))
                    {
                        drd = comselect.ExecuteReader();
                        while (drd.Read())
                        {
                            EST_PEDIDO PEDIDO = new EST_PEDIDO
                            {
                                REMISION = Convert.ToInt32(drd["REMISION"]),
                                ZONA = Convert.ToString(drd["ZONA"]),
                                FECHA_ALTA = Convert.ToDateTime(drd["FECHA_ALTA"]).Date.ToString(),
                                NOMBRE_CLIENTE = Convert.ToString(drd["NOMBRE_CLIENTE"]),
                                SKU_PRODUCTO = Convert.ToString(drd["SKU_PRODUCTO"]),
                                NOM_PRODUCTO = Convert.ToString(drd["NOM_PRODUCTO"]),

                                //CAN_PROD = Convert.ToDouble(drd["CAN_PROD"]),
                                CANT_FALTA = Convert.ToDouble(drd["CANT_FALTA"]),
                                PRECIO_PROD = Convert.ToDouble(drd["PRECIO_PROD"]),
                                TOTAL_PROD = Convert.ToDouble(drd["TOTAL_PROD"]),
                                IMPORTE = Convert.ToDouble(drd["IMPORTE"]),


                                XCESTATUS_PEDIDO = Convert.ToString(drd["XCESTATUS_PEDIDO"]),
                                CATEGORIA = Convert.ToString(drd["CATEGORIA"]),
                                DIVISION = Convert.ToString(drd["DIVISION"]),
                                FAMILIA = Convert.ToString(drd["FAMILIA"]),
                                LINEA = Convert.ToString(drd["LINEA"]),
                                MARCA = Convert.ToString(drd["MARCA"]),
                                PORTAFOLIO = Convert.ToString(drd["PORTAFOLIO"]),
                                PRESENTACION = Convert.ToString(drd["PRESENTACION"]),

                                U_UNE = Convert.ToString(drd["U_UNE"]),
                                U_ClasCMG = Convert.ToString(drd["U_ClasCMG"]),
                                U_ClasMKT = Convert.ToString(drd["U_ClasMKT"]),
                                MES =  Convert.ToDateTime(drd["FECHA_ALTA"]).Month,
                          NUM_AGE = Convert.ToInt32(drd["NUM_AGE"]) ,
                                NOM_AGE = Convert.ToString(drd["NOM_AGE"]),
                                CVE_CLIENTE = Convert.ToString(drd["CVE_CLIENTE"])
                            };

                            _res_json.Add(PEDIDO);

                        }



                    }


                }
            }
            catch (Exception e)
            {
                _res_json = new List<EST_PEDIDO>(); 

            }

            var jsonresult = JsonConvert.SerializeObject(_res_json);
            JArray Areglo_JSON = JArray.Parse(jsonresult);

            return Areglo_JSON;

        }





    }
    public class EST_PEDIDO
    {


        public int REMISION { get; set; }
        public string   ZONA { get; set; }
        public  string  FECHA_ALTA { get; set; }
        public string NOMBRE_CLIENTE { get; set; }
        public string SKU_PRODUCTO { get; set; }
        public string NOM_PRODUCTO { get; set; }

        //public double CAN_PROD { get; set; }
        public double CANT_FALTA { get; set; }
        public double PRECIO_PROD { get; set; }
        public double TOTAL_PROD { get; set; }
        public double IMPORTE { get; set; }


        public string XCESTATUS_PEDIDO { get; set; }
        public string CATEGORIA { get; set; }
        public string DIVISION { get; set; }
        public string FAMILIA { get; set; }
        public string LINEA { get; set; }
        public string MARCA { get; set; }
        public string PORTAFOLIO { get; set; }
        public string PRESENTACION { get; set; }

        public string U_UNE { get; set; }
        public string U_ClasCMG { get; set; }
        public string U_ClasMKT { get; set; }
        public int MES { get; set;   } 
        public int NUM_AGE { get; set; }

        public string NOM_AGE { get; set; }
        public string CVE_CLIENTE { get; set; }



    }




}