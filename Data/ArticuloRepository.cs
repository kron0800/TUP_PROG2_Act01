using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Act_Practica_01.Data.Utils;
using Ej1_5_Facturacion.Domain;

namespace Act_Practica_01.Data
{
    public class ArticuloRepository : IGenericRepository<Articulo>
    {

        public List<Articulo> GetAll()
        {
            List<Articulo> lst = new List<Articulo>();
            var dt = DataHelper.GetInstance().ExecuteSPReader("SelectAllArticulos");
            foreach (DataRow row in dt.Rows)
            {
                lst.Add(new Articulo(row));
            }
            return lst;
        }

        public Articulo GetById(int id)
        {
            List<Parameters> lstParams = new List<Parameters>() { new Parameters("@IdArticulo", id) };
            var dt = DataHelper.GetInstance().ExecuteSPReader("SelectArticuloById", lstParams);
            if (dt.Rows.Count != 1) { return null; }
            return new Articulo(dt.Rows[0]);
        }

        public bool Save(Articulo entity)
        {
            List<Parameters> lstParams = new List<Parameters>()
            {
                new Parameters("@Nombre", entity.Nombre),
                new Parameters("@PrecioUnitario", entity.PrecioUnitario),
            };
            int result = 0;
            if (GetById(entity.IdArticulo) == null)
            {
                // Create new one
                result = DataHelper.GetInstance().ExecuteSPNonQuery("CreateNewArticulo", lstParams);
            }
            else
            {
                // Update existing one
                lstParams.Add(new Parameters("@IdArticulo", entity.IdArticulo));
                result = DataHelper.GetInstance().ExecuteSPNonQuery("UpdateArticulo", lstParams);
            }

            if (result == 1) { return true; } else { return false; }
        }
        public bool Delete(int id)
        {
            List<Parameters> lstParams = new List<Parameters>() { new Parameters("@IdArticulo", id) };
            int result = DataHelper.GetInstance().ExecuteSPNonQuery("DeleteArticuloById", lstParams);
            if (result == 1) { return true; } else { return false; }
        }
    }
}
