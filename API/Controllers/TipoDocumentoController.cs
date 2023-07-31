using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

    public class TipoDocumentoController : BaseApiController
    {
        private readonly IUnitOfWork _unitofwork;
        
        public TipoDocumentoController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<TipoDocumento>>> Get()
        {
            var tipoDocumento = await _unitofwork.TipoDeDocumentos!.GetAllAsync();
            return Ok(tipoDocumento);
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int id)
        {
            var tipodocumento = await _unitofwork.TipoDeDocumentos!.GetByIdAsync(id)!;
            return Ok(tipodocumento);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoDocumento>> Post(TipoDocumento tipodocumento)
        {
            this._unitofwork.TipoDeDocumentos!.Add(tipodocumento);
            await _unitofwork.SaveAsync();
            if (tipodocumento == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post),new {id= tipodocumento.Id}, tipodocumento);
        }
        
    }
