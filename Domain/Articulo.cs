using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej1_5_Facturacion.Domain
{
    public class Articulo
    {
        public int IdArticulo { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioUnitario { get; set; }

        public Articulo() { }

        public Articulo(System.Data.DataRow row)
        {
            IdArticulo = Convert.ToInt32(row["id_articulo"]);
            Nombre = row["nombre"].ToString();
            PrecioUnitario = Convert.ToDecimal(row["precio_unitario"]);
        }
    }
}
