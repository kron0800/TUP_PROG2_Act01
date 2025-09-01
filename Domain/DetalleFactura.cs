using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej1_5_Facturacion.Domain
{
    public class DetalleFactura
    {
        public int IdDetalleFactura { get; set; }
        public int IdFactura { get; set; }
        public int IdArticulo { get; set; }
        public int Cantidad { get; set; }

        public DetalleFactura() { }

        public DetalleFactura(DataRow row)
        {
            IdDetalleFactura = Convert.ToInt32(row["id_detalle_factura"]);
            IdFactura = Convert.ToInt32(row["id_factura"]);
            IdArticulo = Convert.ToInt32(row["id_articulo"]);
            Cantidad = Convert.ToInt32(row["cantidad"]);
        }

        // Navigation properties
        //public virtual Factura Factura { get; set; }
        //public virtual Articulo Articulo { get; set; }
    }
}
