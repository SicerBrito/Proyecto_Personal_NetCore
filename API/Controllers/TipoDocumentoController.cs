using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

    public class TipoDocumentoController : BaseApiController
    {
        private readonly ITipoDocumento _tipodocumentoRepository;
        
        public TipoDocumentoController(ITipoDocumento tipodocumentoRepository)
        {
            _tipodocumentoRepository = tipodocumentoRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<TipoDocumento>>> Get()
        {
            var tipoDocumento = await _tipodocumentoRepository.GetAllAsync();
            return Ok(tipoDocumento);
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int id)
        {
            var tipodocumento = await _tipodocumentoRepository.GetByIdAsync(id);
            return Ok(tipodocumento);
        }
        
    }
