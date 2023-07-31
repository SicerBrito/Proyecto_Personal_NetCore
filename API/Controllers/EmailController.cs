using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

    public class EmailController : BaseApiController
    {   
        private readonly IUnitOfWork _unitofwork;
        
        public EmailController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Email>>> Get()
        {
            var emails = await _unitofwork.Emails!.GetAllAsync();
            return Ok(emails);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int id)
        {
            var email = await _unitofwork.Emails!.GetByIdAsync(id)!;
            return Ok(email);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<InfoPersonal>> Post(Email email)
        {
            this._unitofwork.Emails!.Add(email);
            await _unitofwork.SaveAsync();
            if (email == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post),new {id= email.Id}, email);
        }
        
    }
