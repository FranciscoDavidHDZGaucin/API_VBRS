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
    public class api_Logistica_Fletes_TR_RF
    {
        private SqlDataReader drd;

        public List<DataTable> _RES_TOTALES = null;

        public Newtonsoft.Json.Linq.JArray Fletes()
        {

            DataTable dtvts = new DataTable();
            try
            {
                using (SqlConnection CONECT = new SqlConnection(@"Data Source=192.168.101.154;Initial Catalog=JUPITER;User ID=sa;Password=DB@gr0V3rs@"))
                {
                    CONECT.Open();
                    using (SqlCommand COMANDO = new SqlCommand("select t1.folio, t4.empresa, t1.comentarios, t1.km_prom, t1.km_prom_real, t1.flete_prov, t1.maniobras, t1.tot_peso, t1.tot_cajas, t1.tot_facturas, (t1.flete_prov*100)/t1.tot_facturas as gasto_flete, t1.flete_prov/t1.km_prom as costo_km, t1.envio_autoriza, t1.fecha, t2.fecha_entrega, t2.fecha_promesa, t2.fecha_salida, t2.fecha_promesa2, t2.tipo_doc from pedidos.envios_encabeza t1 join pedidos.envios_det_productos_rf t2 on t2.folio = t1.folio join pedidos.transferencias t3 on t3.movimiento = t2.factura join pedidos.transportes t4 on t4.id = t1.n_proveedor where t1.fecha>= 2021-09-01; ' )", CONECT))


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
}