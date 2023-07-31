using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

    public class InfoPersonalController :BaseApiController
    {
        private readonly IUnitOfWork _unitofwork;
        
        public InfoPersonalController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<InfoPersonal>>> Get()
        {
            var datosPersonales = await _unitofwork.DatosPersonales!.GetAllAsync();
            return Ok(datosPersonales);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int id)
        {
            var datoPersonal = await _unitofwork.DatosPersonales!.GetByIdAsync(id)!;
            return Ok(datoPersonal);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<InfoPersonal>> Post(InfoPersonal datopersonal)
        {
            _unitofwork.DatosPersonales!.Add(datopersonal);
            await _unitofwork.SaveAsync();
            if (datopersonal == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post),new {id= datopersonal.Id}, datopersonal);
        }
        
    }
