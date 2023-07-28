namespace Core.Interfaces;

    public interface IUnitOfWork
    {
        ITipoDocumento Documentos { get; }
        ITelefono Telefonos { get; }
        IEmail Emails { get; }
        int Save();
    }
