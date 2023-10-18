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
    public class HiloRespuestaNotificacionController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HiloRespuestaNotificacionController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<HiloRespuestaNotificacionDTO>>> Get()
        {
            var thread = await _unitOfWork.HiloRespuestaNotificaciones.GetAllAsync();
            return _mapper.Map<List<HiloRespuestaNotificacionDTO>>(thread);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<HiloRespuestaNotificacionDTO>> Get(int id)
        {
            var thread = await _unitOfWork.HiloRespuestaNotificaciones.GetByIdAsync(id);

            if (thread == null)
            {
                return NotFound();
            }

            return _mapper.Map<HiloRespuestaNotificacionDTO>(thread);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<HiloRespuestaNotificacion>> Post(HiloRespuestaNotificacionDTO hiloRespuestaNotificacionDTO)
        {
            var thread = _mapper.Map<HiloRespuestaNotificacion>(hiloRespuestaNotificacionDTO);
            if (thread.FechaCreacion == DateOnly.MinValue)
            {
                thread.FechaCreacion = DateOnly.Parse(DateTime.Now.ToString());
            }

            this._unitOfWork.HiloRespuestaNotificaciones.Add(thread);
            await _unitOfWork.SaveAsync();

            if (thread == null)
            {
                return BadRequest();
            }
            hiloRespuestaNotificacionDTO.Id = thread.Id;
            return CreatedAtAction(nameof(Post), new { id = hiloRespuestaNotificacionDTO.Id }, hiloRespuestaNotificacionDTO);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<HiloRespuestaNotificacionDTO>> Put(int id, [FromBody] HiloRespuestaNotificacionDTO hiloRespuestaNotificacionDTO)
        {
            if (hiloRespuestaNotificacionDTO.FechaModificacion == DateOnly.Parse("0001-01-01"))
            {
                hiloRespuestaNotificacionDTO.FechaModificacion = DateOnly.Parse(DateTime.Now.ToString());
            }

            if (hiloRespuestaNotificacionDTO.Id == 0)
            {
                hiloRespuestaNotificacionDTO.Id = id;
            }

            if (hiloRespuestaNotificacionDTO.Id != id)
            {
                return BadRequest();
            }

            if (hiloRespuestaNotificacionDTO == null)
            {
                return NotFound();
            }

            var thread = _mapper.Map<HiloRespuestaNotificacion>(hiloRespuestaNotificacionDTO);
            _unitOfWork.HiloRespuestaNotificaciones.Update(thread);
            await _unitOfWork.SaveAsync();
            return hiloRespuestaNotificacionDTO;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var thread = await _unitOfWork.HiloRespuestaNotificaciones.GetByIdAsync(id);

            if (thread == null)
            {
                return NotFound();
            }

            _unitOfWork.HiloRespuestaNotificaciones.Remove(thread);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}