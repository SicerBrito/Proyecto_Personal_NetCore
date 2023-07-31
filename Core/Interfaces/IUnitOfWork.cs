namespace Core.Interfaces;

    public interface IUnitOfWork
    {
        ITipoDocumento ? TipoDeDocumentos { get; }
        ITelefono ? Telefonos { get; }
        IEmail ? Emails { get; }
        IDocumento ? Documentos { get; }
        ILogin ? Logins { get; }
        IInfoPersonal ? DatosPersonales{ get; }
        Task<int> SaveAsync();
    }
