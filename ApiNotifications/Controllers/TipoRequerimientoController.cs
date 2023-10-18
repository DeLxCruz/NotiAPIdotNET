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
    public class TipoRequerimientoController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TipoRequerimientoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<TipoRequerimientoDTO>>> Get()
        {
            var typeRequest = await _unitOfWork.TipoRequerimientos.GetAllAsync();
            return _mapper.Map<List<TipoRequerimientoDTO>>(typeRequest);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TipoRequerimientoDTO>> Get(int id)
        {
            var typeRequest = await _unitOfWork.TipoRequerimientos.GetByIdAsync(id);

            if (typeRequest == null)
            {
                return NotFound();
            }

            return _mapper.Map<TipoRequerimientoDTO>(typeRequest);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoRequerimiento>> Post(TipoRequerimientoDTO tipoRequerimientoDTO)
        {
            var typeRequest = _mapper.Map<TipoRequerimiento>(tipoRequerimientoDTO);
            if (typeRequest.FechaCreacion == DateOnly.MinValue)
            {
                typeRequest.FechaCreacion = DateOnly.Parse(DateTime.Now.ToString());
            }

            this._unitOfWork.TipoRequerimientos.Add(typeRequest);
            await _unitOfWork.SaveAsync();

            if (typeRequest == null)
            {
                return BadRequest();
            }
            tipoRequerimientoDTO.Id = typeRequest.Id;
            return CreatedAtAction(nameof(Post), new { id = tipoRequerimientoDTO.Id }, tipoRequerimientoDTO);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TipoRequerimientoDTO>> Put(int id, [FromBody] TipoRequerimientoDTO tipoRequerimientoDTO)
        {
            if (tipoRequerimientoDTO.FechaModificacion == DateOnly.Parse("0001-01-01"))
            {
                tipoRequerimientoDTO.FechaModificacion = DateOnly.Parse(DateTime.Now.ToString());
            }

            if (tipoRequerimientoDTO.Id == 0)
            {
                tipoRequerimientoDTO.Id = id;
            }

            if (tipoRequerimientoDTO.Id != id)
            {
                return BadRequest();
            }

            if (tipoRequerimientoDTO == null)
            {
                return NotFound();
            }

            var typeRequest = _mapper.Map<TipoRequerimiento>(tipoRequerimientoDTO);
            _unitOfWork.TipoRequerimientos.Update(typeRequest);
            await _unitOfWork.SaveAsync();
            return tipoRequerimientoDTO;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var typeRequest = await _unitOfWork.TipoRequerimientos.GetByIdAsync(id);

            if (typeRequest == null)
            {
                return NotFound();
            }

            _unitOfWork.TipoRequerimientos.Remove(typeRequest);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}