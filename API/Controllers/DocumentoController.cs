using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

    public class DocumentoController : BaseApiController
    {
        private readonly PaginaContext _context;
        
        public DocumentoController(PaginaContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Documento>>> Get()
        {
            var documentos = await _context.Documentos.ToListAsync();
            return Ok(documentos);
        }

        // .GetAllAsync();

        //Traer Registro de la base de datos
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int id)
        {
            var documento = await _context.Documentos.FindAsync(id);
            return Ok(documento);
        }

    }
