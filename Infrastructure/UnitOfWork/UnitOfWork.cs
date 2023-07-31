using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repository;

namespace Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly PaginaContext ? _context;
    private TipoDocumentoRepository ? _TipoDocumento;
    private TelefonoRepository ? _Telefono;
    private EmailRepository ?_Email;
    private DocumentoRepository ? _Documento;
    private LoginRepository ? _Login;
    private InfoPersonalRepository ? _DatoPersonal;


    public UnitOfWork(PaginaContext context)
    {
        _context = context;
    }

    public ITipoDocumento TipoDeDocumentos{
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

    public IEmail Emails {
        get{
            if (_Email is null)
            {
                _Email = new(_context);
            }
            return _Email;
        }
    }
    public IDocumento Documentos {
        get{
            if (_Documento is null)
            {
                _Documento = new(_context);
            }
            return _Documento;
        }
    }
    public ILogin Logins {
        get{
            if (_Login is null)
            {
                _Login = new(_context);
            }
            return _Login;
        }
    }
    public IInfoPersonal DatosPersonales {
        get{
            if (_DatoPersonal is null)
            {
                _DatoPersonal = new(_context);
            }
            return _DatoPersonal;
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task<int> SaveAsync()
    {
        throw new NotImplementedException();
    }
     
}
