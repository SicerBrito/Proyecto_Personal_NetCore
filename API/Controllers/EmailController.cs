using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

    public class EmailController : BaseApiController
    {   
        private readonly PaginaContext _context;
        
        public EmailController(PaginaContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Email>>> Get()
        {
            var emails = await _context.Emails.ToListAsync();
            return Ok(emails);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int id)
        {
            var email = await _context.Emails.FindAsync(id);
            return Ok(email);
        }
        
    }
