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
    public class TipoNotificacionesController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TipoNotificacionesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<TipoNotificacionesDTO>>> Get()
        {
            var typeOfNoti = await _unitOfWork.TipoNotificaciones.GetAllAsync();
            return _mapper.Map<List<TipoNotificacionesDTO>>(typeOfNoti);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TipoNotificacionesDTO>> Get(int id)
        {
            var typeOfNoti = await _unitOfWork.TipoNotificaciones.GetByIdAsync(id);

            if (typeOfNoti == null)
            {
                return NotFound();
            }

            return _mapper.Map<TipoNotificacionesDTO>(typeOfNoti);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoNotificaciones>> Post(TipoNotificacionesDTO TipoNotificacionesDTO)
        {
            var typeOfNoti = _mapper.Map<TipoNotificaciones>(TipoNotificacionesDTO);
            if (typeOfNoti.FechaCreacion == DateOnly.MinValue)
            {
                typeOfNoti.FechaCreacion = DateOnly.Parse(DateTime.Now.ToString());
            }

            this._unitOfWork.TipoNotificaciones.Add(typeOfNoti);
            await _unitOfWork.SaveAsync();

            if (typeOfNoti == null)
            {
                return BadRequest();
            }
            TipoNotificacionesDTO.Id = typeOfNoti.Id;
            return CreatedAtAction(nameof(Post), new { id = TipoNotificacionesDTO.Id }, TipoNotificacionesDTO);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TipoNotificacionesDTO>> Put(int id, [FromBody] TipoNotificacionesDTO tipoNotificacionesDTO)
        {
            if (tipoNotificacionesDTO.FechaModificacion == DateOnly.Parse("0001-01-01"))
            {
                tipoNotificacionesDTO.FechaModificacion = DateOnly.Parse(DateTime.Now.ToString());
            }

            if (tipoNotificacionesDTO.Id == 0)
            {
                tipoNotificacionesDTO.Id = id;
            }

            if (tipoNotificacionesDTO.Id != id)
            {
                return BadRequest();
            }

            if (tipoNotificacionesDTO == null)
            {
                return NotFound();
            }

            var typeOfNoti = _mapper.Map<TipoNotificaciones>(tipoNotificacionesDTO);
            _unitOfWork.TipoNotificaciones.Update(typeOfNoti);
            await _unitOfWork.SaveAsync();
            return tipoNotificacionesDTO;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var typeOfNoti = await _unitOfWork.TipoNotificaciones.GetByIdAsync(id);

            if (typeOfNoti == null)
            {
                return NotFound();
            }

            _unitOfWork.TipoNotificaciones.Remove(typeOfNoti);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}