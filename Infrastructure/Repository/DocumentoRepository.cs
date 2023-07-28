using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class DocumentoRepository : IDocumento
{
    private PaginaContext context;

    public DocumentoRepository(PaginaContext context)
    {
        this.context = context;
    }
}
