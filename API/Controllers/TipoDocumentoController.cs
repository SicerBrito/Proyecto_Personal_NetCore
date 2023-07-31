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
            var tipoDocumento = await _unitofwork.TipoDeDocumentos.GetAllAsync();
            return Ok(tipoDocumento);
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int id)
        {
            var tipodocumento = await _unitofwork.TipoDeDocumentos.GetByIdAsync(id);
            return Ok(tipodocumento);
        }
        
    }
