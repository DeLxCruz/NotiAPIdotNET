using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiNotifications.Controllers;
using ApiNotifications.DTOs;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ApiNotifications.Controlelers
{
    public class RolControleler : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RolControleler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<RolDTO>>> Get()
        {
            var role = await _unitOfWork.Roles.GetAllAsync();
            return _mapper.Map<List<RolDTO>>(role);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RolDTO>> Get(int id)
        {
            var role = await _unitOfWork.Roles.GetByIdAsync(id);

            if (role == null)
            {
                return NotFound();
            }

            return _mapper.Map<RolDTO>(role);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Rol>> Post(RolDTO rolDTO)
        {
            var role = _mapper.Map<Rol>(rolDTO);
            if (role.FechaCreacion == DateOnly.MinValue)
            {
                role.FechaCreacion = DateOnly.Parse(DateTime.Now.ToString());
            }

            this._unitOfWork.Roles.Add(role);
            await _unitOfWork.SaveAsync();

            if (role == null)
            {
                return BadRequest();
            }
            rolDTO.Id = role.Id;
            return CreatedAtAction(nameof(Post), new { id = rolDTO.Id }, rolDTO);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RolDTO>> Put(int id, [FromBody] RolDTO rolDTO)
        {
            if (rolDTO.FechaModificacion == DateOnly.Parse("0001-01-01"))
            {
                rolDTO.FechaModificacion = DateOnly.Parse(DateTime.Now.ToString());
            }

            if (rolDTO.Id == 0)
            {
                rolDTO.Id = id;
            }

            if (rolDTO.Id != id)
            {
                return BadRequest();
            }

            if (rolDTO == null)
            {
                return NotFound();
            }

            var role = _mapper.Map<Rol>(rolDTO);
            _unitOfWork.Roles.Update(role);
            await _unitOfWork.SaveAsync();
            return rolDTO;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var role = await _unitOfWork.Roles.GetByIdAsync(id);

            if (role == null)
            {
                return NotFound();
            }

            _unitOfWork.Roles.Remove(role);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}