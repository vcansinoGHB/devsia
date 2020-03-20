using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devSia.Modelos.Proveedor.Factura
{
    public class FacturaItem
    {
       public int facprov_ID { get; set; }
       public string facprov_UUID { get; set; }
       public string facprov_xml { get; set; }
       public string facprov_pdf { get; set; }
       public string facprov_fechaRegistro { get; set; }
       public string facprov_fecha { get; set; }
       public string facprov_factura { get; set; }
       public string facprov_facturanum { get; set; }
        public decimal facprov_tipocambio { get; set; }
        public decimal facprov_montototal { get; set; }
        public string facprov_moneda { get; set; }
        public int facprov_zonaparidad { get; set; }
        public decimal facprov_descuento { get; set; }
        public decimal facprov_subtotal { get; set; }
        public decimal facprov_IVA { get; set; }
        public decimal facprov_retIVA { get; set; }
        public decimal facprov_ISR { get; set; }
        public decimal facprov_retISR { get; set; }
        public decimal facprov_IEPS { get; set; }
        public decimal facprov_retotros { get; set; }
        public decimal facprov_otros { get; set; }
        public int facprov_proveedorID { get; set; }
        public int facprov_locacionID { get; set; }
        public int facprov_empresaID { get; set; }
        public int facprov_tipo { get; set; }
        public int totalResultados { get; set; }
    }
}
