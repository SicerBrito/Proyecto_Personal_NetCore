using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repository;

namespace Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly PaginaContext _context;
    private TipoDocumentoRepository _TipoDocumento;
    private TelefonoRepository _Telefono;
    private EmailRepository _Email;


    public UnitOfWork(PaginaContext context)
    {
        _context = context;
    }

    public ITipoDocumento TipoDocumentos{
        get{
            if (_TipoDocumento is null)
            {
                _TipoDocumento = new(_context);
            }
            return _TipoDocumento;
        }
    }

    public ITelefono Telefonos {
        get{
            if (_Telefono is null)
            {
                _Telefono = new(_context);
            }
            return _Telefono;
        }
    }

    public IEmail Emails => new emailRepository(context);

    public int Save()
    {
        throw new NotImplementedException();
    }
     
}
