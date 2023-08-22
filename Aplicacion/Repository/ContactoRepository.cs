using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.Repository;
    public class ContactoRepository : GenericRepository<Contacto>, IContactoRepository
    {
        public ContactoRepository(SicerContext context) : base(context){
            
        }
        
    }
