using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

    public class LoginController : BaseApiController
    {
        private readonly PaginaContext _context;
        
        public LoginController(PaginaContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Login>>> Get()
        {
            var logins = await _context.Logins.ToListAsync();
            return Ok(logins);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int id)
        {
            var login = await _context.Logins.FindAsync(id);
            return Ok(login);
        }
    }
