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
    public class PermisosGenericosController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PermisosGenericosController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PermisosGenericosDTO>>> Get()
        {
            var permits = await _unitOfWork.PermisosGenericos.GetAllAsync();
            return _mapper.Map<List<PermisosGenericosDTO>>(permits);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PermisosGenericosDTO>> Get(int id)
        {
            var permits = await _unitOfWork.PermisosGenericos.GetByIdAsync(id);

            if (permits == null)
            {
                return NotFound();
            }

            return _mapper.Map<PermisosGenericosDTO>(permits);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PermisosGenericos>> Post(PermisosGenericosDTO permisosGenericosDTO)
        {
            var permits = _mapper.Map<PermisosGenericos>(permisosGenericosDTO);
            if (permits.FechaCreacion == DateOnly.MinValue)
            {
                permits.FechaCreacion = DateOnly.Parse(DateTime.Now.ToString());
            }

            this._unitOfWork.PermisosGenericos.Add(permits);
            await _unitOfWork.SaveAsync();

            if (permits == null)
            {
                return BadRequest();
            }
            permisosGenericosDTO.Id = permits.Id;
            return CreatedAtAction(nameof(Post), new { id = permisosGenericosDTO.Id }, permisosGenericosDTO);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PermisosGenericosDTO>> Put(int id, [FromBody] PermisosGenericosDTO permisosGenericosDTO)
        {
            if (permisosGenericosDTO.FechaModificacion == DateOnly.Parse("0001-01-01"))
            {
                permisosGenericosDTO.FechaModificacion = DateOnly.Parse(DateTime.Now.ToString());
            }

            if (permisosGenericosDTO.Id == 0)
            {
                permisosGenericosDTO.Id = id;
            }

            if (permisosGenericosDTO.Id != id)
            {
                return BadRequest();
            }

            if (permisosGenericosDTO == null)
            {
                return NotFound();
            }

            var permits = _mapper.Map<PermisosGenericos>(permisosGenericosDTO);
            _unitOfWork.PermisosGenericos.Update(permits);
            await _unitOfWork.SaveAsync();
            return permisosGenericosDTO;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var permits = await _unitOfWork.PermisosGenericos.GetByIdAsync(id);

            if (permits == null)
            {
                return NotFound();
            }

            _unitOfWork.PermisosGenericos.Remove(permits);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}