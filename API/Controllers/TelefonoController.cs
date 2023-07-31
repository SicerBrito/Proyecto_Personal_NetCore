using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

    public class TelefonoController : BaseApiController
    {
        private readonly IUnitOfWork _unitofwork;
        
        public TelefonoController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Telefono>>> Get()
        {
            var telefonos = await _unitofwork.Telefonos.GetAllAsync();
            return Ok(telefonos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int id)
        {
            var telefono = await _unitofwork.Telefonos.GetByIdAsync(id);
            return Ok(telefono);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Telefono>> Post(Telefono telefono)
        {
            this._unitofwork.Telefonos.Add(telefono);
            await _unitofwork.SaveAsync();
            if (telefono == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post),new {id= telefono.Id}, telefono);
        }

    }
