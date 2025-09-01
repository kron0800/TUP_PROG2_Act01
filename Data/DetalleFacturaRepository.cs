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
    public class DetalleFacturaRepository : IGenericRepository<DetalleFactura>
    {
        public List<DetalleFactura> GetAll()
        {
            List<DetalleFactura> lst = new List<DetalleFactura>();
            var dt = DataHelper.GetInstance().ExecuteSPReader("SelectAllDetallesFacturas");
            foreach(DataRow row in dt.Rows)
            {
                lst.Add(new DetalleFactura(row));
            }
            return lst;
        }

        public DetalleFactura GetById(int id)
        {
            List<Parameters> lstParams = new List<Parameters>() { new Parameters("@IdDetalleFactura", id) };
            var dt = DataHelper.GetInstance().ExecuteSPReader("GetDetallesFacturaById", lstParams);
            if (dt.Rows.Count != 1) { return null; }
            return new DetalleFactura(dt.Rows[0]);
        }

        public bool Save(DetalleFactura entity)
        {
            {
                List<Parameters> lstParams = new List<Parameters>()
            {
                new Parameters("@IdFactura", entity.IdFactura),
                new Parameters("@IdArticulo", entity.IdArticulo),
                new Parameters("@Cantidad", entity.Cantidad)
            };
                int result = 0;
                if (GetById(entity.IdDetalleFactura) == null)
                {
                    // Create new one
                    result = DataHelper.GetInstance().ExecuteSPNonQuery("CreateNewDetalleFactura", lstParams);
                }
                else
                {
                    // Update existing one
                    lstParams.Add(new Parameters("@IdDetalleFactura", entity.IdDetalleFactura));
                    result = DataHelper.GetInstance().ExecuteSPNonQuery("UpdateDetalleFactura", lstParams);
                }

                if (result == 1) { return true; } else { return false; }
            }
        }

        public bool Delete(int id)
        {
            List<Parameters> lstParams = new List<Parameters>() { new Parameters("@IdDetalleFactura", id) };
            int result = DataHelper.GetInstance().ExecuteSPNonQuery("DeleteFacturaById", lstParams);
            if (result == 1) { return true; } else { return false; }
        }
    }
}
