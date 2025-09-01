using Act_Practica_01.Data.Utils;
using Ej1_5_Facturacion.Domain;

namespace Act_Practica_01.Services
{
    public class ArticuloService
    {
        public ArticuloService() { }

        public List<Articulo> GetAllArticulos()
        {
            using var uow = new UnitOfWork();
            return uow.ArticuloRepository.GetAll();
        }

        public Articulo GetArticuloById(int id)
        {
            using var uow = new UnitOfWork();
            return uow.ArticuloRepository.GetById(id);
        }

        public bool SaveArticulo(Articulo articulo)
        {
            using var uow = new UnitOfWork();
            try
            {
                bool ok = uow.ArticuloRepository.Save(articulo);
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

        public bool DeleteArticuloByID(int id)
        {
            using var uow = new UnitOfWork();
            try
            {
                bool ok = uow.ArticuloRepository.Delete(id);
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
