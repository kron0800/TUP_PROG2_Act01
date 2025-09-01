using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej1_5_Facturacion.Domain
{
    public class Factura
    {
        public int IdFactura { get; set; } = 0;
        public int NroFactura { get; set; }
        public DateTime Fecha { get; set; }
        //public int IdFormaPago { get; set; }
        public FormaPago FormaPago { get; set; }
        public string Cliente { get; set; }

        public Factura() { }

        public Factura(DataRow data)
        {
            IdFactura = (int)(data["id_factura"]);
            NroFactura = (int)(data["nro_factura"]);
            Fecha = Convert.ToDateTime(data["fecha"]);
            FormaPago = new FormaPago
            {
                IdFormaPago = (int)(data["id_forma_pago"]),
                Nombre = data["nombre"].ToString()
            };
            Cliente = data["cliente"].ToString();
        }

        public override string ToString()
        {
            return $"Nro de factura: {NroFactura} - Cliente: {Cliente} - Fecha: {Fecha.ToString("dd/MM/yyyy")} - Metodo de pago: {FormaPago.Nombre}";
        }
    }
}
