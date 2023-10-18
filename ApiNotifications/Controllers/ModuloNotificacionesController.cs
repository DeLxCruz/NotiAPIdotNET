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
    public class ModuloNotificacionesController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ModuloNotificacionesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ModuloNotificacionesDTO>>> Get()
        {
            var moduleNoti = await _unitOfWork.ModuloNotificaciones.GetAllAsync();
            return _mapper.Map<List<ModuloNotificacionesDTO>>(moduleNoti);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ModuloNotificacionesDTO>> Get(int id)
        {
            var moduleNoti = await _unitOfWork.ModuloNotificaciones.GetByIdAsync(id);

            if (moduleNoti == null)
            {
                return NotFound();
            }

            return _mapper.Map<ModuloNotificacionesDTO>(moduleNoti);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ModuloNotificaciones>> Post(ModuloNotificacionesDTO moduloNotificacionesDTO)
        {
            var moduleNoti = _mapper.Map<ModuloNotificaciones>(moduloNotificacionesDTO);
            if (moduleNoti.FechaCreacion == DateOnly.MinValue)
            {
                moduleNoti.FechaCreacion = DateOnly.Parse(DateTime.Now.ToString());
            }

            this._unitOfWork.ModuloNotificaciones.Add(moduleNoti);
            await _unitOfWork.SaveAsync();

            if (moduleNoti == null)
            {
                return BadRequest();
            }
            moduloNotificacionesDTO.Id = moduleNoti.Id;
            return CreatedAtAction(nameof(Post), new { id = moduloNotificacionesDTO.Id }, moduloNotificacionesDTO);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ModuloNotificacionesDTO>> Put(int id, [FromBody] ModuloNotificacionesDTO moduloNotificacionesDTO)
        {
            if (moduloNotificacionesDTO.FechaModificacion == DateOnly.Parse("0001-01-01"))
            {
                moduloNotificacionesDTO.FechaModificacion = DateOnly.Parse(DateTime.Now.ToString());
            }

            if (moduloNotificacionesDTO.Id == 0)
            {
                moduloNotificacionesDTO.Id = id;
            }

            if (moduloNotificacionesDTO.Id != id)
            {
                return BadRequest();
            }

            if (moduloNotificacionesDTO == null)
            {
                return NotFound();
            }

            var moduleNoti = _mapper.Map<ModuloNotificaciones>(moduloNotificacionesDTO);
            _unitOfWork.ModuloNotificaciones.Update(moduleNoti);
            await _unitOfWork.SaveAsync();
            return moduloNotificacionesDTO;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var moduleNoti = await _unitOfWork.ModuloNotificaciones.GetByIdAsync(id);

            if (moduleNoti == null)
            {
                return NotFound();
            }

            _unitOfWork.ModuloNotificaciones.Remove(moduleNoti);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}