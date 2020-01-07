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
    public class VTS_TOTALES
    {
        private Double TotVenta;

        private Double TotCMG_TOTAL;
        private Double TotCMG_porce;
        private Double ToCosto_TOTAL;
        private Double ToCosto_TOTAL2;

        private Double TotalMes;
        private Double ToCosto_sp_CTTAL_GRFCCST;
        private Double PLTF_CMG;
        private Double PLTF_CMG_PORCENTAGE;

        private String _TotVenta;
        private String _TotCMG_TOTAL;
        private String _TotCMG_porce;
        private String _ToCosto_TOTAL;
        private String _ToCosto_TOTAL2;

        private String _TotalMes;
        private String _ToCosto_sp_CTTAL_GRFCCST;
        private String _PLTF_CMG;
        private String _PLTF_CMG_PORCENTAGE;

        private SqlDataReader drd;

        public List<DataTable> _RES_TOTALES = null; 


      

        public Newtonsoft.Json.Linq.JArray VTS_TODAS_NORMALIZADAS()
        {
            DataTable dtvts = new DataTable();
            try
            {
                using (SqlConnection CONECT = new SqlConnection(@"Data Source=SRV-DBGW;Initial Catalog=INEFABLE;User ID=sa;Password=DB@gr0V3rs@"))
                {
                    CONECT.Open();
                    using (SqlCommand COMANDO = new SqlCommand("SP_TODAS_NORMALIZADA", CONECT))
                    {
                        drd = COMANDO.ExecuteReader();



                        if (drd.Read())
                        {
                            TotVenta = Convert.ToDouble(drd["VentaMes"]);
                            TotCMG_TOTAL = Convert.ToDouble(drd["COSTO_TOTAL"]);
                            ToCosto_TOTAL = Convert.ToDouble(drd["CMG_TOTAL"]);
                            TotCMG_porce = Convert.ToDouble(drd["PORCECMG"]);

                            _TotVenta = String.Format("$ #,###,##0.00", TotVenta);
                            _TotCMG_TOTAL = String.Format("$ #,###,##0.00", TotCMG_TOTAL);
                            _ToCosto_TOTAL = String.Format("$ #,###,##0.00", ToCosto_TOTAL);
                            _TotCMG_porce = String.Format("$ #,###,##0.00", TotCMG_porce);



                            object[] _objt_TotVenta = { "TotVenta", TotVenta };
                            object[] _objt_TotCMG_TOTAL = { "TotCMG_TOTAL", TotCMG_TOTAL };
                            object[] _objt_ToCosto_TOTAL = { "ToCosto_TOTAL", ToCosto_TOTAL };
                            object[] _objt_TotCMG_porce = { "TotCMG_porce", TotCMG_porce };

                            dtvts.Clear();

                            dtvts.Columns.Add("TotVenta", typeof(Double));
                            dtvts.Columns.Add("TotCMG_TOTAL", typeof(Double));
                            dtvts.Columns.Add("ToCosto_TOTAL", typeof(Double));
                            dtvts.Columns.Add("TotCMG_porce", typeof(Double));

                            dtvts.Rows.Add(TotVenta, TotCMG_TOTAL, ToCosto_TOTAL, TotCMG_porce);







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

        public Newtonsoft.Json.Linq.JArray VTS_TODAS_TTAL_GRAFIC_COSTOS()
        {
            ///sp_CASIILLAS_TOTAL_GRAFIC_COSTO
            DataTable RESULT = new DataTable();

            try
            {
                using (SqlConnection CONEC = new SqlConnection(@"Data Source=SRV-DBGW;Initial Catalog=JUPITER;User ID=sa;Password=DB@gr0V3rs@"))
                {
                    CONEC.Open();
                    using (SqlCommand COMAND = new SqlCommand("sp_CASIILLAS_TOTAL_GRAFIC_COSTO", CONEC))
                    {

                        drd = COMAND.ExecuteReader();
                        if (drd.Read())
                        {

                            //            TotVenta2 = drd2.Item("TOTAL_MES").ToString
                            //Me.Label5.Text = Format(TotVenta2, "$ #,###,##0.00")
                            //ToCosto_TOTAL2 = drd2.Item("TOTAL_COSTO").ToString
                            //Me.Label6.Text = Format(ToCosto_TOTAL2, "$ #,###,##0.00") PLATAFORMA COSTO TOTAL
                            //Me.Label7.Text = Format(TotVenta2 - ToCosto_TOTAL2, " #,###,##0.00") PLATAFORMA CMG
                            //' Me.Label8.Text=FormatPercent(((TotVenta2 - ToCosto_TOTAL2) / TotVenta2) * 100) PLATAFORMA %CMG
                            //Me.Label8.Text = Format(((TotVenta2 - ToCosto_TOTAL2) / TotVenta2) * 100, " #,#0.00")
                            TotalMes = Convert.ToDouble(drd["TOTAL_MES"]);
                            _TotalMes = String.Format("$ #,###,##0.00", TotalMes);

                            ToCosto_sp_CTTAL_GRFCCST = Convert.ToDouble(drd["TOTAL_COSTO"]);
                            _ToCosto_sp_CTTAL_GRFCCST = String.Format("$ #,###,##0.00", ToCosto_sp_CTTAL_GRFCCST);

                            PLTF_CMG = TotalMes - ToCosto_sp_CTTAL_GRFCCST;
                            _PLTF_CMG = String.Format("$ #,###,##0.00", PLTF_CMG);

                            PLTF_CMG_PORCENTAGE = (((TotalMes - ToCosto_sp_CTTAL_GRFCCST) / TotalMes) * 100);

                            _PLTF_CMG_PORCENTAGE = String.Format(" #,#0.00", PLTF_CMG_PORCENTAGE);


                            RESULT.Clear();

                            RESULT.Columns.Add("TOTAL_MES", typeof(Double));
                            RESULT.Columns.Add("TOTAL_COSTO", typeof(Double));
                            RESULT.Columns.Add("PLTF_CMG", typeof(Double));
                            RESULT.Columns.Add("PLTF_CMG_PORCENTAGE", typeof(Double));

                            RESULT.Rows.Add(TotalMes, ToCosto_sp_CTTAL_GRFCCST, PLTF_CMG, PLTF_CMG_PORCENTAGE);





                        }


                    }


                }


            }
            catch (Exception e)
            {

                RESULT = new DataTable();
            }

            var jsonresult = JsonConvert.SerializeObject(RESULT);
            JArray Areglo_JSON = JArray.Parse(jsonresult);

            return Areglo_JSON;


        }


    }
}