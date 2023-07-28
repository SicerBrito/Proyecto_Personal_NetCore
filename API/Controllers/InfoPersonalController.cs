using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

    public class InfoPersonalController :BaseApiController
    {
        private readonly PaginaContext _context;
        
        public InfoPersonalController(PaginaContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<InfoPersonal>>> Get()
        {
            var datosPersonales = await _context.DatosPersonales.ToListAsync();
            return Ok(datosPersonales);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int id)
        {
            var datoPersonal = await _context.DatosPersonales.FindAsync(id);
            return Ok(datoPersonal);
        }
    }
