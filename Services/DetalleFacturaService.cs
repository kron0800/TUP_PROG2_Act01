using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Act_Practica_01.Data.Utils;
using Ej1_5_Facturacion.Domain;

namespace Act_Practica_01.Services
{
    public class DetalleFacturaService
    {
        public DetalleFacturaService() { }

        public List<DetalleFactura> GetAllDetallesFacturas()
        {
            using var uow = new UnitOfWork();
            return uow.DetalleFacturaRepository.GetAll();
        }

        public DetalleFactura GetDetalleFacturaById(int id)
        {
            using var uow = new UnitOfWork();
            return uow.DetalleFacturaRepository.GetById(id);
        }

        public bool SaveDetalleFactura(DetalleFactura detalleFactura)
        {
            using var uow = new UnitOfWork();
            try
            {
                bool ok = uow.DetalleFacturaRepository.Save(detalleFactura);
                if (ok)
                {
                    uow.Commit();
                    return true;
                }
                else
                {
                    uow.Rollback();
                    return false;
                }
            }
            catch (Exception)
            {
                uow.Rollback();
                throw;
            }
        }

        public bool DeleteDetalleFacturaByID(int id)
        {
            using var uow = new UnitOfWork();
            try
            {
                bool ok = uow.DetalleFacturaRepository.Delete(id);
                if (ok)
                {
                    uow.Commit();
                    return true;
                }
                else
                {
                    uow.Rollback();
                    return false;
                }
            }
            catch (Exception)
            {
                uow.Rollback();
                throw;
            }
        }
    }
}
