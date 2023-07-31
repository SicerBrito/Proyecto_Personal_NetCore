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
            var documentos = await _unitofwork.Documentos!.GetAllAsync();
            return Ok(documentos);
        }

        //Traer Registro de la base de datos
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int id)
        {
            var documento = await _unitofwork.Documentos!.GetByIdAsync(id)!;
            return Ok(documento);
        }


        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Documento>> Post(DtoDoc data)
        {
            var doc = new Documento(){
                Id = data.Id,
                Numero = data.Numero,
                TipoId = data.TipoId,
            };
            _unitofwork.Documentos!.Add(doc);
            await _unitofwork.SaveAsync();
            if (data == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post),new {id= doc.Id}, doc);
        }

    }

    public class DtoDoc{
        public int Id { get; set; }
        public int Numero { get; set; }
        public int TipoId { get; set; }
    }
