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
    public class EstadoNotificacionController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EstadoNotificacionController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<EstadoNotificacionDTO>>> Get()
        {
            var status = await _unitOfWork.EstadoNotificaciones.GetAllAsync();
            return _mapper.Map<List<EstadoNotificacionDTO>>(status);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EstadoNotificacionDTO>> Get(int id)
        {
            var status = await _unitOfWork.EstadoNotificaciones.GetByIdAsync(id);

            if (status == null)
            {
                return NotFound();
            }

            return _mapper.Map<EstadoNotificacionDTO>(status);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EstadoNotificacion>> Post(EstadoNotificacionDTO estadoNotificacionDTO)
        {
            var status = _mapper.Map<EstadoNotificacion>(estadoNotificacionDTO);
            if (status.FechaCreacion == DateOnly.MinValue)
            {
                status.FechaCreacion = DateOnly.Parse(DateTime.Now.ToString());
            }

            this._unitOfWork.EstadoNotificaciones.Add(status);
            await _unitOfWork.SaveAsync();

            if (status == null)
            {
                return BadRequest();
            }
            estadoNotificacionDTO.Id = status.Id;
            return CreatedAtAction(nameof(Post), new { id = estadoNotificacionDTO.Id }, estadoNotificacionDTO);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EstadoNotificacionDTO>> Put(int id, [FromBody] EstadoNotificacionDTO estadoNotificacionDTO)
        {
            if (estadoNotificacionDTO.FechaModificacion == DateOnly.Parse("0001-01-01"))
            {
                estadoNotificacionDTO.FechaModificacion = DateOnly.Parse(DateTime.Now.ToString());
            }

            if (estadoNotificacionDTO.Id == 0)
            {
                estadoNotificacionDTO.Id = id;
            }

            if (estadoNotificacionDTO.Id != id)
            {
                return BadRequest();
            }

            if (estadoNotificacionDTO == null)
            {
                return NotFound();
            }

            var status = _mapper.Map<EstadoNotificacion>(estadoNotificacionDTO);
            _unitOfWork.EstadoNotificaciones.Update(status);
            await _unitOfWork.SaveAsync();
            return estadoNotificacionDTO;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var status = await _unitOfWork.EstadoNotificaciones.GetByIdAsync(id);

            if (status == null)
            {
                return NotFound();
            }

            _unitOfWork.EstadoNotificaciones.Remove(status);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}