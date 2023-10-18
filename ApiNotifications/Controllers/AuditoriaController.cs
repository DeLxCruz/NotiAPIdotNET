using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiNotifications.DTOs;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ApiNotifications.Controllers
{
    public class AuditoriaController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AuditoriaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<AuditoriaDTO>>> Get()
        {
            var auditory = await _unitOfWork.Auditorias.GetAllAsync();
            return _mapper.Map<List<AuditoriaDTO>>(auditory);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AuditoriaDTO>> Get(int id)
        {
            var auditory = await _unitOfWork.Auditorias.GetByIdAsync(id);

            if (auditory == null)
            {
                return NotFound();
            }

            return _mapper.Map<AuditoriaDTO>(auditory);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Auditoria>> Post(AuditoriaDTO auditoriaDTO)
        {
            var auditory = _mapper.Map<Auditoria>(auditoriaDTO);
            if (auditory.FechaCreacion == DateOnly.MinValue)
            {
                auditory.FechaCreacion = DateOnly.Parse(DateTime.Now.ToString());
            }

            this._unitOfWork.Auditorias.Add(auditory);
            await _unitOfWork.SaveAsync();

            if (auditory == null)
            {
                return BadRequest();
            }
            auditoriaDTO.Id = auditory.Id;
            return CreatedAtAction(nameof(Post), new { id = auditoriaDTO.Id }, auditoriaDTO);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AuditoriaDTO>> Put(int id, [FromBody] AuditoriaDTO auditoriaDTO)
        {
            if (auditoriaDTO.FechaModificacion == DateOnly.Parse("0001-01-01"))
            {
                auditoriaDTO.FechaModificacion = DateOnly.Parse(DateTime.Now.ToString());
            }

            if (auditoriaDTO.Id == 0)
            {
                auditoriaDTO.Id = id;
            }

            if (auditoriaDTO.Id != id)
            {
                return BadRequest();
            }

            if (auditoriaDTO == null)
            {
                return NotFound();
            }

            var auditory = _mapper.Map<Auditoria>(auditoriaDTO);
            _unitOfWork.Auditorias.Update(auditory);
            await _unitOfWork.SaveAsync();
            return auditoriaDTO;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var auditory = await _unitOfWork.Auditorias.GetByIdAsync(id);

            if (auditory == null)
            {
                return NotFound();
            }

            _unitOfWork.Auditorias.Remove(auditory);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}