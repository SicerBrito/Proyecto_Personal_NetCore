using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

    public class DocumentoController : BaseApiController
    {
        private readonly IUnitOfWork _unitofwork;
        
        public DocumentoController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Documento>>> Get()
        {
            var documentos = await _unitofwork.Documentos.GetAllAsync();
            return Ok(documentos);
        }

        //Traer Registro de la base de datos
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int id)
        {
            var documento = await _unitofwork.Documentos.GetByIdAsync(id);
            return Ok(documento);
        }


        //
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Documento>> Post(Documento documento)
        {
            this._unitofwork.Documentos.Add(documento);
            await _unitofwork.SaveAsync();
            if (documento == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post),new {id= documento.Id}, documento);
        }

    }
