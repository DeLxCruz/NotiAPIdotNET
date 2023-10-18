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
    public class SubModulosController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SubModulosController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<SubModulosDTO>>> Get()
        {
            var submodule = await _unitOfWork.SubModulos.GetAllAsync();
            return _mapper.Map<List<SubModulosDTO>>(submodule);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SubModulosDTO>> Get(int id)
        {
            var submodule = await _unitOfWork.SubModulos.GetByIdAsync(id);

            if (submodule == null)
            {
                return NotFound();
            }

            return _mapper.Map<SubModulosDTO>(submodule);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SubModulos>> Post(SubModulosDTO subModulosDTO)
        {
            var submodule = _mapper.Map<SubModulos>(subModulosDTO);
            if (submodule.FechaCreacion == DateOnly.MinValue)
            {
                submodule.FechaCreacion = DateOnly.Parse(DateTime.Now.ToString());
            }

            this._unitOfWork.SubModulos.Add(submodule);
            await _unitOfWork.SaveAsync();

            if (submodule == null)
            {
                return BadRequest();
            }
            subModulosDTO.Id = submodule.Id;
            return CreatedAtAction(nameof(Post), new { id = subModulosDTO.Id }, subModulosDTO);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SubModulosDTO>> Put(int id, [FromBody] SubModulosDTO subModulosDTO)
        {
            if (subModulosDTO.FechaModificacion == DateOnly.Parse("0001-01-01"))
            {
                subModulosDTO.FechaModificacion = DateOnly.Parse(DateTime.Now.ToString());
            }

            if (subModulosDTO.Id == 0)
            {
                subModulosDTO.Id = id;
            }

            if (subModulosDTO.Id != id)
            {
                return BadRequest();
            }

            if (subModulosDTO == null)
            {
                return NotFound();
            }

            var submodule = _mapper.Map<SubModulos>(subModulosDTO);
            _unitOfWork.SubModulos.Update(submodule);
            await _unitOfWork.SaveAsync();
            return subModulosDTO;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var submodule = await _unitOfWork.SubModulos.GetByIdAsync(id);

            if (submodule == null)
            {
                return NotFound();
            }

            _unitOfWork.SubModulos.Remove(submodule);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}