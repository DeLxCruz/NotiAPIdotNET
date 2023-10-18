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
    public class ModulosMaestrosController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ModulosMaestrosController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ModulosMaestrosDTO>>> Get()
        {
            var modules = await _unitOfWork.ModulosMaestros.GetAllAsync();
            return _mapper.Map<List<ModulosMaestrosDTO>>(modules);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ModulosMaestrosDTO>> Get(int id)
        {
            var modules = await _unitOfWork.ModulosMaestros.GetByIdAsync(id);

            if (modules == null)
            {
                return NotFound();
            }

            return _mapper.Map<ModulosMaestrosDTO>(modules);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ModulosMaestros>> Post(ModulosMaestrosDTO modulosMaestrosDTO)
        {
            var modules = _mapper.Map<ModulosMaestros>(modulosMaestrosDTO);
            if (modules.FechaCreacion == DateOnly.MinValue)
            {
                modules.FechaCreacion = DateOnly.Parse(DateTime.Now.ToString());
            }

            this._unitOfWork.ModulosMaestros.Add(modules);
            await _unitOfWork.SaveAsync();

            if (modules == null)
            {
                return BadRequest();
            }
            modulosMaestrosDTO.Id = modules.Id;
            return CreatedAtAction(nameof(Post), new { id = modulosMaestrosDTO.Id }, modulosMaestrosDTO);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ModulosMaestrosDTO>> Put(int id, [FromBody] ModulosMaestrosDTO modulosMaestrosDTO)
        {
            if (modulosMaestrosDTO.FechaModificacion == DateOnly.Parse("0001-01-01"))
            {
                modulosMaestrosDTO.FechaModificacion = DateOnly.Parse(DateTime.Now.ToString());
            }

            if (modulosMaestrosDTO.Id == 0)
            {
                modulosMaestrosDTO.Id = id;
            }

            if (modulosMaestrosDTO.Id != id)
            {
                return BadRequest();
            }

            if (modulosMaestrosDTO == null)
            {
                return NotFound();
            }

            var modules = _mapper.Map<ModulosMaestros>(modulosMaestrosDTO);
            _unitOfWork.ModulosMaestros.Update(modules);
            await _unitOfWork.SaveAsync();
            return modulosMaestrosDTO;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var modules = await _unitOfWork.ModulosMaestros.GetByIdAsync(id);

            if (modules == null)
            {
                return NotFound();
            }

            _unitOfWork.ModulosMaestros.Remove(modules);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}