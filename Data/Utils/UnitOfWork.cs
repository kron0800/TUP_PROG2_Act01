namespace Act_Practica_01.Data.Utils
{
    public class UnitOfWork : IDisposable
    {
        public FacturaRepository FacturaRepository { get; }
        public DetalleFacturaRepository DetalleFacturaRepository { get; }
        public ArticuloRepository ArticuloRepository { get; }


        public UnitOfWork()
        {
            FacturaRepository = new FacturaRepository();
            DetalleFacturaRepository = new DetalleFacturaRepository();
            ArticuloRepository = new ArticuloRepository();
            DataHelper.GetInstance().BeginTransaction();
        }

        public void Commit() => DataHelper.GetInstance().Commit();
        public void Rollback() => DataHelper.GetInstance().Rollback();
        public void Dispose() => DataHelper.GetInstance().CloseConnection();
    }
}
