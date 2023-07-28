using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

    public class TelefonoController : BaseApiController
    {
        private readonly PaginaContext _context;
        
        public TelefonoController(PaginaContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Telefono>>> Get()
        {
            var telefonos = await _context.Telefonos.ToListAsync();
            return Ok(telefonos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int id)
        {
            var telefono = await _context.Telefonos.FindAsync(id);
            return Ok(telefono);
        }
    }
