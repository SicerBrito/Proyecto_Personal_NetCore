using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

    public class LoginController : BaseApiController
    {
        private readonly IUnitOfWork _unitofwork;
        
        public LoginController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Login>>> Get()
        {
            var logins = await _unitofwork.Logins!.GetAllAsync();
            return Ok(logins);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int id)
        {
            var login = await _unitofwork.Logins!.GetByIdAsync(id)!;
            return Ok(login);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Login>> Post(Login login)
        {
            _unitofwork.Logins!.Add(login);
            await _unitofwork.SaveAsync();
            if (login == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post),new {id= login.Id}, login);
        }
    }
